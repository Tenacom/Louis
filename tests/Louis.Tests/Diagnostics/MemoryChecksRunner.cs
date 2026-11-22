// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Diagnostics;

/// <summary>
/// Runs the chain checks on a <see cref="Memory{T}"/> parameter, for <see cref="ParamCollectionChecksTests"/>.
/// </summary>
internal sealed class MemoryChecksRunner : CollectionChecksRunner
{
    public override string GetValueText(int count) => $"System.Memory<Int32>[{count}]";

    public override CheckOutcome Empty(int count, string? message)
    {
        Memory<int> items = new int[count];
        var param = Param.Check(items).Empty(message);
        return new(param.Value.Equals(items), param.Name);
    }

    public override CheckOutcome NotEmpty(int count, string? message)
    {
        Memory<int> items = new int[count];
        var param = Param.Check(items).NotEmpty(message);
        return new(param.Value.Equals(items), param.Name);
    }

    public override CheckOutcome HasSizeEqualTo(int count, int size, string? message)
    {
        Memory<int> items = new int[count];
        var param = Param.Check(items).HasSizeEqualTo(size, message);
        return new(param.Value.Equals(items), param.Name);
    }

    public override CheckOutcome HasSizeNotEqualTo(int count, int size, string? message)
    {
        Memory<int> items = new int[count];
        var param = Param.Check(items).HasSizeNotEqualTo(size, message);
        return new(param.Value.Equals(items), param.Name);
    }

    public override CheckOutcome HasSizeGreaterThan(int count, int size, string? message)
    {
        Memory<int> items = new int[count];
        var param = Param.Check(items).HasSizeGreaterThan(size, message);
        return new(param.Value.Equals(items), param.Name);
    }

    public override CheckOutcome HasSizeGreaterThanOrEqualTo(int count, int size, string? message)
    {
        Memory<int> items = new int[count];
        var param = Param.Check(items).HasSizeGreaterThanOrEqualTo(size, message);
        return new(param.Value.Equals(items), param.Name);
    }

    public override CheckOutcome HasSizeLessThan(int count, int size, string? message)
    {
        Memory<int> items = new int[count];
        var param = Param.Check(items).HasSizeLessThan(size, message);
        return new(param.Value.Equals(items), param.Name);
    }

    public override CheckOutcome HasSizeLessThanOrEqualTo(int count, int size, string? message)
    {
        Memory<int> items = new int[count];
        var param = Param.Check(items).HasSizeLessThanOrEqualTo(size, message);
        return new(param.Value.Equals(items), param.Name);
    }

    public override CheckOutcome HasSizeEqualToOther(int count, int otherCount, string? message)
    {
        Memory<int> items = new int[count];
        var param = Param.Check(items).HasSizeEqualTo(new int[otherCount], message);
        return new(param.Value.Equals(items), param.Name);
    }

    public override CheckOutcome HasSizeLessThanOrEqualToOther(int count, int otherCount, string? message)
    {
        Memory<int> items = new int[count];
        var param = Param.Check(items).HasSizeLessThanOrEqualTo(new int[otherCount], message);
        return new(param.Value.Equals(items), param.Name);
    }

    public override Param<int> InRangeFor(int index, int count, string? message)
    {
        Memory<int> items = new int[count];
        return Param.Check(index).InRangeFor(items, message);
    }

    public override Param<int> NotInRangeFor(int index, int count, string? message)
    {
        Memory<int> items = new int[count];
        return Param.Check(index).NotInRangeFor(items, message);
    }
}
