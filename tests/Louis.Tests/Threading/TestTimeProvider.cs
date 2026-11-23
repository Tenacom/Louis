// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Microsoft.Extensions.Time.Testing;

// A FakeTimeProvider derives its timestamp from its date and time, at one unit per tick.
// This clock has the timestamp frequency that a test chooses, and a timestamp that only the test changes.
internal sealed class TestTimeProvider(long timestampFrequency) : FakeTimeProvider
{
    public long Timestamp { get; set; }

    public override long TimestampFrequency => timestampFrequency;

    public override long GetTimestamp() => Timestamp;
}
