// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using Louis.Diagnostics;

namespace Louis.Threading;

/// <summary>
/// Represents an instant on a clock, after which an operation gives up.
/// </summary>
/// <remarks>
/// <para>The clock of a deadline is a <see cref="System.TimeProvider"/>.
/// A deadline measures time with <see cref="System.TimeProvider.GetTimestamp"/>, which is monotonic,
/// so a change of the system date does not move a deadline.</para>
/// <para>A deadline is a value. A method copies it, and passes it down a call chain, without an allocation.</para>
/// <para>The default value is <see cref="Eternal"/>, a deadline that never expires,
/// as the default <see cref="CancellationToken"/> is never canceled.</para>
/// <para>Two deadlines are equal when they have the same clock and the same instant.
/// <see cref="Eternal"/> and <see cref="Expired"/> have no instant, and each is equal to itself alone.
/// A deadline that has expired on a clock is not equal to <see cref="Expired"/>.</para>
/// </remarks>
public readonly struct Deadline : IEquatable<Deadline>
{
    private const ulong TicksPerSecond = TimeSpan.TicksPerSecond;

    private const string NegativeDurationMessage = "{0} ({1}) must be TimeSpan.Zero or greater, or Timeout.InfiniteTimeSpan.";

    // A deadline without a clock is Eternal when _timestamp is zero, and Expired otherwise.
    // The default value is therefore Eternal.
    private const long ExpiredTimestamp = 1;

    private readonly TimeProvider? _timeProvider;
    private readonly long _timestamp;

    private Deadline(TimeProvider? timeProvider, long timestamp)
    {
        _timeProvider = timeProvider;
        _timestamp = timestamp;
    }

    /// <summary>
    /// Gets a deadline that never expires.
    /// </summary>
    /// <value>
    /// A deadline that never expires, which is also the default value of <see cref="Deadline"/>.
    /// </value>
    public static Deadline Eternal => default;

    /// <summary>
    /// Gets a deadline that has expired.
    /// </summary>
    /// <value>
    /// A deadline that has expired, and depends on no clock.
    /// </value>
    public static Deadline Expired => new(null, ExpiredTimestamp);

    /// <summary>
    /// Gets a value indicating whether this deadline never expires.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if this deadline never expires; otherwise, <see langword="false"/>.
    /// </value>
    public bool IsEternal => _timeProvider is null && _timestamp == 0;

    /// <summary>
    /// Gets a value indicating whether this deadline has expired.
    /// </summary>
    /// <value>
    /// <see langword="true"/> if the clock of this deadline has reached its instant; otherwise, <see langword="false"/>.
    /// </value>
    public bool HasExpired => _timeProvider is null ? _timestamp != 0 : _timeProvider.GetTimestamp() >= _timestamp;

    /// <summary>
    /// Gets the time that remains until this deadline expires.
    /// </summary>
    /// <value>
    /// The time until this deadline expires; <see cref="TimeSpan.Zero"/> if it has expired;
    /// <see cref="Timeout.InfiniteTimeSpan"/> if it never expires.
    /// </value>
    /// <remarks>
    /// <para>The value follows the rules of the BCL for a timeout. It goes as it is to a member that takes a timeout
    /// and a <see cref="System.TimeProvider"/>, such as <c>Task.Delay</c> and <c>Task.WaitAsync</c>.</para>
    /// <para>The value is rounded up to a tick, so it is <see cref="TimeSpan.Zero"/> only if <see cref="HasExpired"/>
    /// is <see langword="true"/>.</para>
    /// <para>A time longer than <see cref="TimeSpan.MaxValue"/> is reported as <see cref="TimeSpan.MaxValue"/>.</para>
    /// </remarks>
    public TimeSpan RemainingTime
    {
        get
        {
            if (_timeProvider is null)
            {
                return _timestamp == 0 ? Timeout.InfiniteTimeSpan : TimeSpan.Zero;
            }

            var now = _timeProvider.GetTimestamp();
            if (now >= _timestamp)
            {
                return TimeSpan.Zero;
            }

            // The distance between two timestamps can exceed long.MaxValue, and always fits in a ulong.
            var units = unchecked((ulong)(_timestamp - now));
            return ToTimeSpan(units, (ulong)_timeProvider.TimestampFrequency);
        }
    }

    /// <summary>
    /// Gets the clock of this deadline.
    /// </summary>
    /// <value>
    /// The <see cref="System.TimeProvider"/> that this deadline measures time with.
    /// For <see cref="Eternal"/> and <see cref="Expired"/>, which depend on no clock,
    /// the value is <see cref="System.TimeProvider.System"/>.
    /// </value>
    public TimeProvider TimeProvider => _timeProvider ?? TimeProvider.System;

    /// <summary>
    /// Determines whether two specified deadlines are equal.
    /// </summary>
    /// <param name="a">The first deadline to compare.</param>
    /// <param name="b">The second deadline to compare.</param>
    /// <returns><see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> have the same clock
    /// and the same instant; otherwise, <see langword="false"/>.</returns>
    public static bool operator ==(Deadline a, Deadline b) => a.Equals(b);

    /// <summary>
    /// Determines whether two specified deadlines are different.
    /// </summary>
    /// <param name="a">The first deadline to compare.</param>
    /// <param name="b">The second deadline to compare.</param>
    /// <returns><see langword="true"/> if <paramref name="a"/> and <paramref name="b"/> differ in their clock
    /// or in their instant; otherwise, <see langword="false"/>.</returns>
    public static bool operator !=(Deadline a, Deadline b) => !a.Equals(b);

    /// <summary>
    /// Creates a deadline that expires a specified time after the call, on the system clock.
    /// </summary>
    /// <param name="duration">The time from the call to the instant of the deadline,
    /// or <see cref="Timeout.InfiniteTimeSpan"/> for a deadline that never expires.</param>
    /// <returns>A deadline on <see cref="System.TimeProvider.System"/>,
    /// or <see cref="Eternal"/> if <paramref name="duration"/> is <see cref="Timeout.InfiniteTimeSpan"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="duration"/> is negative,
    /// and is not <see cref="Timeout.InfiniteTimeSpan"/>.</exception>
    /// <remarks>
    /// <para>This method follows the rules of the BCL for a timeout.
    /// If <paramref name="duration"/> is <see cref="TimeSpan.Zero"/>, the deadline has expired.</para>
    /// <para>If the clock has no timestamp for the instant, because <paramref name="duration"/> is too long,
    /// this method returns <see cref="Eternal"/>.</para>
    /// </remarks>
    public static Deadline SetIn(TimeSpan duration) => SetIn(duration, TimeProvider.System);

    /// <summary>
    /// Creates a deadline that expires a specified time after the call, on a specified clock.
    /// </summary>
    /// <param name="duration">The time from the call to the instant of the deadline,
    /// or <see cref="Timeout.InfiniteTimeSpan"/> for a deadline that never expires.</param>
    /// <param name="timeProvider">The clock of the deadline.</param>
    /// <returns>A deadline on <paramref name="timeProvider"/>,
    /// or <see cref="Eternal"/> if <paramref name="duration"/> is <see cref="Timeout.InfiniteTimeSpan"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="timeProvider"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">The <see cref="System.TimeProvider.TimestampFrequency"/>
    /// of <paramref name="timeProvider"/> is zero or negative.</exception>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="duration"/> is negative,
    /// and is not <see cref="Timeout.InfiniteTimeSpan"/>.</exception>
    /// <remarks>
    /// <para>This method follows the rules of the BCL for a timeout.
    /// If <paramref name="duration"/> is <see cref="TimeSpan.Zero"/>, the deadline has expired.</para>
    /// <para>If <paramref name="timeProvider"/> has no timestamp for the instant, because <paramref name="duration"/>
    /// is too long, this method returns <see cref="Eternal"/>.</para>
    /// </remarks>
    public static Deadline SetIn(TimeSpan duration, TimeProvider timeProvider)
    {
        Param.NotNull(timeProvider);
        var frequency = GetFrequency(timeProvider);
        if (duration == Timeout.InfiniteTimeSpan)
        {
            return Eternal;
        }

        Param.Check(duration).GreaterThanOrEqualTo(TimeSpan.Zero, NegativeDurationMessage);
        return After(timeProvider, timeProvider.GetTimestamp(), frequency, (ulong)duration.Ticks);
    }

    /// <summary>
    /// Creates a deadline that expires at a specified date and time, as the system clock reads them at the call.
    /// </summary>
    /// <param name="instant">The date and time at which the deadline expires.</param>
    /// <returns>A deadline on <see cref="System.TimeProvider.System"/>.</returns>
    /// <remarks>
    /// <para>This method reads the date and time of the clock once, and sets the deadline in the time
    /// that remains until <paramref name="instant"/>. If <paramref name="instant"/> is not in the future,
    /// the deadline has expired.</para>
    /// <para>The deadline does not follow a later change of the system date.
    /// After such a change, the deadline no longer expires at <paramref name="instant"/>.
    /// For example, a device without a real-time clock corrects its date when it first reaches a time server.
    /// A deadline set before the correction is wrong by the size of the correction.</para>
    /// <para>If the clock has no timestamp for <paramref name="instant"/>, this method returns
    /// <see cref="Eternal"/> for an instant in the future, and <see cref="Expired"/> for an instant in the past.</para>
    /// </remarks>
    public static Deadline SetAt(DateTimeOffset instant) => SetAt(instant, TimeProvider.System);

    /// <summary>
    /// Creates a deadline that expires at a specified date and time, as a specified clock reads them at the call.
    /// </summary>
    /// <param name="instant">The date and time at which the deadline expires.</param>
    /// <param name="timeProvider">The clock of the deadline.</param>
    /// <returns>A deadline on <paramref name="timeProvider"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="timeProvider"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentException">The <see cref="System.TimeProvider.TimestampFrequency"/>
    /// of <paramref name="timeProvider"/> is zero or negative.</exception>
    /// <remarks>
    /// <para>This method reads the date and time of <paramref name="timeProvider"/> once, and sets the deadline in the time
    /// that remains until <paramref name="instant"/>. If <paramref name="instant"/> is not in the future,
    /// the deadline has expired.</para>
    /// <para>The deadline does not follow a later change of the date of <paramref name="timeProvider"/>.
    /// After such a change, the deadline no longer expires at <paramref name="instant"/>.
    /// For example, a device without a real-time clock corrects its date when it first reaches a time server.
    /// A deadline set before the correction is wrong by the size of the correction.</para>
    /// <para>If <paramref name="timeProvider"/> has no timestamp for <paramref name="instant"/>, this method returns
    /// <see cref="Eternal"/> for an instant in the future, and <see cref="Expired"/> for an instant in the past.</para>
    /// </remarks>
    public static Deadline SetAt(DateTimeOffset instant, TimeProvider timeProvider)
    {
        Param.NotNull(timeProvider);
        var frequency = GetFrequency(timeProvider);
        var timeLeft = instant - timeProvider.GetUtcNow();
        var timestamp = timeProvider.GetTimestamp();
        return timeLeft >= TimeSpan.Zero
            ? After(timeProvider, timestamp, frequency, (ulong)timeLeft.Ticks)
            : Before(timeProvider, timestamp, frequency, (ulong)-timeLeft.Ticks);
    }

    /// <summary>
    /// Creates a deadline that expires a specified time after a specified deadline, on the same clock.
    /// </summary>
    /// <param name="deadline">The deadline that the new deadline follows.</param>
    /// <param name="duration">The time from the instant of <paramref name="deadline"/> to the instant of the new deadline,
    /// or <see cref="Timeout.InfiniteTimeSpan"/> for a deadline that never expires.</param>
    /// <returns>A deadline on the clock of <paramref name="deadline"/>,
    /// or <see cref="Eternal"/> if <paramref name="duration"/> is <see cref="Timeout.InfiniteTimeSpan"/>.
    /// If <paramref name="deadline"/> is <see cref="Eternal"/> or <see cref="Expired"/>,
    /// the return value is <paramref name="deadline"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="duration"/> is negative,
    /// and is not <see cref="Timeout.InfiniteTimeSpan"/>.</exception>
    /// <remarks>
    /// <para>This method adds <paramref name="duration"/> to the instant of <paramref name="deadline"/>,
    /// and does not read the clock. If <paramref name="duration"/> is <see cref="TimeSpan.Zero"/>,
    /// the new deadline is equal to <paramref name="deadline"/>.</para>
    /// <para><see cref="Eternal"/> and <see cref="Expired"/> have no instant.
    /// This method returns each of them as it is, even if <paramref name="duration"/>
    /// is <see cref="Timeout.InfiniteTimeSpan"/>.</para>
    /// <para>If the clock has no timestamp for the new instant, because <paramref name="duration"/> is too long,
    /// this method returns <see cref="Eternal"/>.</para>
    /// <para>For a deadline that expires before <paramref name="deadline"/>, call <see cref="SetBefore"/>.</para>
    /// </remarks>
    public static Deadline SetAfter(Deadline deadline, TimeSpan duration)
    {
        if (duration == Timeout.InfiniteTimeSpan)
        {
            return deadline._timeProvider is null ? deadline : Eternal;
        }

        Param.Check(duration).GreaterThanOrEqualTo(TimeSpan.Zero, NegativeDurationMessage);
        return deadline._timeProvider is { } timeProvider
            ? After(timeProvider, deadline._timestamp, (ulong)timeProvider.TimestampFrequency, (ulong)duration.Ticks)
            : deadline;
    }

    /// <summary>
    /// Creates a deadline that expires a specified time before a specified deadline, on the same clock.
    /// </summary>
    /// <param name="deadline">The deadline that the new deadline precedes.</param>
    /// <param name="duration">The time from the instant of the new deadline to the instant of <paramref name="deadline"/>,
    /// or <see cref="Timeout.InfiniteTimeSpan"/> for a deadline that has expired.</param>
    /// <returns>A deadline on the clock of <paramref name="deadline"/>,
    /// or <see cref="Expired"/> if <paramref name="duration"/> is <see cref="Timeout.InfiniteTimeSpan"/>.
    /// If <paramref name="deadline"/> is <see cref="Eternal"/> or <see cref="Expired"/>,
    /// the return value is <paramref name="deadline"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="duration"/> is negative,
    /// and is not <see cref="Timeout.InfiniteTimeSpan"/>.</exception>
    /// <remarks>
    /// <para>This method subtracts <paramref name="duration"/> from the instant of <paramref name="deadline"/>,
    /// and does not read the clock. The new deadline may have expired already.
    /// If <paramref name="duration"/> is <see cref="TimeSpan.Zero"/>,
    /// the new deadline is equal to <paramref name="deadline"/>.</para>
    /// <para><see cref="Eternal"/> and <see cref="Expired"/> have no instant.
    /// This method returns each of them as it is, even if <paramref name="duration"/>
    /// is <see cref="Timeout.InfiniteTimeSpan"/>.</para>
    /// <para>If the clock has no timestamp for the new instant, because <paramref name="duration"/> is too long,
    /// this method returns <see cref="Expired"/>.</para>
    /// <para>For a deadline that expires after <paramref name="deadline"/>, call <see cref="SetAfter"/>.</para>
    /// </remarks>
    public static Deadline SetBefore(Deadline deadline, TimeSpan duration)
    {
        if (duration == Timeout.InfiniteTimeSpan)
        {
            return deadline._timeProvider is null ? deadline : Expired;
        }

        Param.Check(duration).GreaterThanOrEqualTo(TimeSpan.Zero, NegativeDurationMessage);
        return deadline._timeProvider is { } timeProvider
            ? Before(timeProvider, deadline._timestamp, (ulong)timeProvider.TimestampFrequency, (ulong)duration.Ticks)
            : deadline;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is Deadline other && Equals(other);

    /// <summary>
    /// Determines whether this deadline and a specified deadline are equal.
    /// </summary>
    /// <param name="other">The deadline to compare with this deadline.</param>
    /// <returns><see langword="true"/> if the two deadlines have the same clock and the same instant;
    /// otherwise, <see langword="false"/>.</returns>
    public bool Equals(Deadline other)
        => ReferenceEquals(_timeProvider, other._timeProvider) && _timestamp == other._timestamp;

    /// <inheritdoc/>
    public override int GetHashCode() => (RuntimeHelpers.GetHashCode(_timeProvider), _timestamp).GetHashCode();

    /// <summary>
    /// Returns a string that describes the state of this deadline.
    /// </summary>
    /// <returns><c>Eternal</c> if this deadline never expires; <c>Expired</c> if it has expired;
    /// otherwise, <see cref="RemainingTime"/> in the constant format of <see cref="TimeSpan"/>.</returns>
    public override string ToString()
    {
        var remainingTime = RemainingTime;
        return remainingTime == Timeout.InfiniteTimeSpan ? nameof(Eternal)
            : remainingTime == TimeSpan.Zero ? nameof(Expired)
            : remainingTime.ToString("c", CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Throws a <see cref="TimeoutException"/> if this deadline has expired.
    /// </summary>
    /// <exception cref="TimeoutException">This deadline has expired.</exception>
    public void ThrowIfExpired()
    {
        if (HasExpired)
        {
            TimeoutException.ThrowNew("The deadline has expired.");
        }
    }

    private static ulong GetFrequency(TimeProvider timeProvider)
    {
        var frequency = timeProvider.TimestampFrequency;
        return frequency > 0
            ? (ulong)frequency
            : ArgumentException.ThrowNew<ulong>(
                $"The {nameof(TimeProvider.TimestampFrequency)} of {nameof(timeProvider)} must be positive.",
                nameof(timeProvider));
    }

    private static Deadline After(TimeProvider timeProvider, long timestamp, ulong frequency, ulong ticks)
    {
        // The distance between two timestamps can exceed long.MaxValue, and always fits in a ulong.
        var maxUnits = unchecked((ulong)(long.MaxValue - timestamp));
        return TryConvertToUnits(ticks, frequency, maxUnits, out var units)
            ? new(timeProvider, unchecked(timestamp + (long)units))
            : Eternal;
    }

    private static Deadline Before(TimeProvider timeProvider, long timestamp, ulong frequency, ulong ticks)
    {
        // The distance between two timestamps can exceed long.MaxValue, and always fits in a ulong.
        var maxUnits = unchecked((ulong)(timestamp - long.MinValue));
        return TryConvertToUnits(ticks, frequency, maxUnits, out var units)
            ? new(timeProvider, unchecked(timestamp - (long)units))
            : Expired;
    }

    // Converts a duration from ticks to the units of a clock, and rounds it up, so that the duration never gets shorter.
    // Returns false when the result exceeds maxUnits.
    private static bool TryConvertToUnits(ulong ticks, ulong frequency, ulong maxUnits, out ulong units)
    {
        // The result is ticks * frequency / TicksPerSecond. The product can exceed a ulong where the result does not.
        // With both factors split by TicksPerSecond, every product below fits.
        var seconds = ticks / TicksPerSecond;
        var subsecondTicks = ticks % TicksPerSecond;
        var unitsPerTick = frequency / TicksPerSecond;
        var subtickFrequency = frequency % TicksPerSecond;
        var subsecondUnits = (subsecondTicks * unitsPerTick) + DivideRoundingUp(subsecondTicks * subtickFrequency, TicksPerSecond);
        var fits = subsecondUnits <= maxUnits && seconds <= (maxUnits - subsecondUnits) / frequency;
        units = fits ? (seconds * frequency) + subsecondUnits : 0;
        return fits;
    }

    // Converts a duration from the units of a clock to a TimeSpan, and rounds it up to a tick,
    // so that only an expired deadline has no remaining time.
    private static TimeSpan ToTimeSpan(ulong units, ulong frequency)
    {
        const ulong MaxTicks = long.MaxValue;
        const ulong MaxUnitsForUInt64Product = ulong.MaxValue / TicksPerSecond;

        var seconds = units / frequency;
        var subsecondUnits = units % frequency;

        // A decimal holds the product that a ulong cannot, and enough decimal places of the quotient to round it up.
        var subsecondTicks = subsecondUnits <= MaxUnitsForUInt64Product
            ? DivideRoundingUp(subsecondUnits * TicksPerSecond, frequency)
            : (ulong)decimal.Ceiling((decimal)subsecondUnits * TicksPerSecond / frequency);

        var fits = seconds <= (MaxTicks - subsecondTicks) / TicksPerSecond;
        return fits ? new((long)((seconds * TicksPerSecond) + subsecondTicks)) : TimeSpan.MaxValue;
    }

    private static ulong DivideRoundingUp(ulong dividend, ulong divisor)
    {
        var quotient = dividend / divisor;
        return dividend % divisor == 0 ? quotient : quotient + 1;
    }
}
