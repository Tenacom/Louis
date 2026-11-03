// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using Louis.Threading;

// ReSharper disable SuspiciousTypeConversion.Global // Equals(object) with a value of another type is the case under test
internal sealed partial class InterlockedReferenceTests
{
    [Test]
    public async Task Constructor_SetsValue()
    {
        var item = new TestItem(1);

        var reference = new InterlockedReference<TestItem>(item);

        await Assert.That(reference.Value).IsSameReferenceAs(item);
        await Assert.That(reference.IsNull).IsFalse();
    }

    [Test]
    public async Task Constructor_WithNull_SetsNull()
    {
        var reference = new InterlockedReference<TestItem>(null);

        await Assert.That(reference.Value).IsNull();
        await Assert.That(reference.IsNull).IsTrue();
    }

    [Test]
    public async Task DefaultValue_IsNull()
    {
        var reference = default(InterlockedReference<TestItem>);

        await Assert.That(reference.Value).IsNull();
        await Assert.That(reference.IsNull).IsTrue();
    }

    [Test]
    public async Task Value_Set_ChangesValue()
    {
        var reference = new InterlockedReference<TestItem>(new TestItem(1));
        var item = new TestItem(2);

        reference.Value = item;

        await Assert.That(reference.Value).IsSameReferenceAs(item);
    }

    [Test]
    public async Task Value_SetToNull_ClearsValue()
    {
        var reference = new InterlockedReference<TestItem>(new TestItem(1));

        reference.Value = null;

        await Assert.That(reference.Value).IsNull();
        await Assert.That(reference.IsNull).IsTrue();
    }

    [Test]
    public async Task Equality_WithSameInstance_ReturnsTrue()
    {
        var item = new TestItem(1);
        var a = new InterlockedReference<TestItem>(item);
        var b = new InterlockedReference<TestItem>(item);

        await Assert.That(a == b).IsTrue();
        await Assert.That(a != b).IsFalse();
        await Assert.That(a.Equals(b)).IsTrue();
        await Assert.That(a.Equals((object)b)).IsTrue();
        await Assert.That(a == item).IsTrue();
        await Assert.That(a != item).IsFalse();
        await Assert.That(a.Equals(item)).IsTrue();
        await Assert.That(a.Equals((object)item)).IsTrue();
    }

    [Test]
    public async Task Equality_WithEqualButDistinctInstance_ReturnsFalse()
    {
        var item = new TestItem(1);
        var otherItem = new TestItem(1);
        await Assert.That(item).IsEqualTo(otherItem);
        await Assert.That(item).IsNotSameReferenceAs(otherItem);
        var a = new InterlockedReference<TestItem>(item);
        var b = new InterlockedReference<TestItem>(otherItem);

        await Assert.That(a == b).IsFalse();
        await Assert.That(a != b).IsTrue();
        await Assert.That(a.Equals(b)).IsFalse();
        await Assert.That(a.Equals((object)b)).IsFalse();
        await Assert.That(a == otherItem).IsFalse();
        await Assert.That(a != otherItem).IsTrue();
        await Assert.That(a.Equals(otherItem)).IsFalse();
        await Assert.That(a.Equals((object)otherItem)).IsFalse();
    }

    [Test]
    public async Task Equality_WithBothNull_ReturnsTrue()
    {
        TestItem? nullItem = null;
        var a = new InterlockedReference<TestItem>(null);
        var b = default(InterlockedReference<TestItem>);

        await Assert.That(a == b).IsTrue();
        await Assert.That(a != b).IsFalse();
        await Assert.That(a.Equals(b)).IsTrue();
        await Assert.That(a.Equals((object)b)).IsTrue();
        await Assert.That(a == nullItem).IsTrue();
        await Assert.That(a != nullItem).IsFalse();
        await Assert.That(a.Equals(nullItem)).IsTrue();
        await Assert.That(a.Equals((object?)null)).IsTrue();
    }

    [Test]
    public async Task Equality_WithNullAndInstance_ReturnsFalse()
    {
        TestItem? nullItem = null;
        var item = new TestItem(1);
        var a = new InterlockedReference<TestItem>(item);
        var b = new InterlockedReference<TestItem>(null);

        await Assert.That(a == b).IsFalse();
        await Assert.That(a != b).IsTrue();
        await Assert.That(a.Equals(b)).IsFalse();
        await Assert.That(a.Equals((object)b)).IsFalse();
        await Assert.That(a == nullItem).IsFalse();
        await Assert.That(a != nullItem).IsTrue();
        await Assert.That(a.Equals(nullItem)).IsFalse();
        await Assert.That(a.Equals((object?)null)).IsFalse();
        await Assert.That(b == item).IsFalse();
        await Assert.That(b != item).IsTrue();
        await Assert.That(b.Equals(item)).IsFalse();
        await Assert.That(b.Equals((object)item)).IsFalse();
    }

    [Test]
    public async Task Equals_WithOtherObject_ReturnsFalse()
    {
        var reference = new InterlockedReference<TestItem>(new TestItem(1));

        await Assert.That(reference.Equals("1")).IsFalse();
        await Assert.That(reference.Equals(1)).IsFalse();
    }

    [Test]
    public async Task GetHashCode_ReturnsHashCodeOfValue()
    {
        var item = new TestItem(42);
        var reference = new InterlockedReference<TestItem>(item);

        await Assert.That(reference.GetHashCode()).IsEqualTo(item.GetHashCode());
    }

    [Test]
    public async Task GetHashCode_WithNull_ReturnsZero()
    {
        var reference = new InterlockedReference<TestItem>(null);

        await Assert.That(reference.GetHashCode()).IsEqualTo(0);
    }

    [Test]
    public async Task ToString_ReturnsToStringOfValue()
    {
        var item = new TestItem(42);
        var reference = new InterlockedReference<TestItem>(item);

        await Assert.That(reference.ToString()).IsEqualTo(item.ToString());
    }

    [Test]
    public async Task ToString_WithNull_ReturnsEmptyString()
    {
        var reference = new InterlockedReference<TestItem>(null);

        await Assert.That(reference.ToString()).IsEmpty();
    }

    [Test]
    public async Task Exchange_SetsValueAndReturnsPreviousValue()
    {
        var item = new TestItem(1);
        var newItem = new TestItem(2);
        var reference = new InterlockedReference<TestItem>(item);

        var previousValue = reference.Exchange(newItem);

        await Assert.That(previousValue).IsSameReferenceAs(item);
        await Assert.That(reference.Value).IsSameReferenceAs(newItem);
    }

    [Test]
    public async Task CompareExchange_WithMatchingComparand_SetsValueAndReturnsPreviousValue()
    {
        var item = new TestItem(1);
        var newItem = new TestItem(2);
        var reference = new InterlockedReference<TestItem>(item);

        var previousValue = reference.CompareExchange(newItem, item);

        await Assert.That(previousValue).IsSameReferenceAs(item);
        await Assert.That(reference.Value).IsSameReferenceAs(newItem);
    }

    [Test]
    public async Task CompareExchange_WithEqualButDistinctComparand_KeepsValue()
    {
        var item = new TestItem(1);
        var comparand = new TestItem(1);
        var newItem = new TestItem(2);
        var reference = new InterlockedReference<TestItem>(item);

        var previousValue = reference.CompareExchange(newItem, comparand);

        await Assert.That(previousValue).IsSameReferenceAs(item);
        await Assert.That(reference.Value).IsSameReferenceAs(item);
    }

    [Test]
    public async Task CompareExchange_WithNullComparandOnNull_SetsValue()
    {
        var item = new TestItem(1);
        var reference = new InterlockedReference<TestItem>(null);

        var previousValue = reference.CompareExchange(item, null);

        await Assert.That(previousValue).IsNull();
        await Assert.That(reference.Value).IsSameReferenceAs(item);
    }
}

// ReSharper restore SuspiciousTypeConversion.Global
