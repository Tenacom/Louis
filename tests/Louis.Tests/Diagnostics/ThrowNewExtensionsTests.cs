// Copyright (c) Tenacom and contributors. Licensed under the MIT license.
// See the LICENSE file in the project root for full license information.

using System.ComponentModel;
using System.Reflection;
using Louis.Diagnostics;

// The source generator of Louis adds the ThrowNew methods under test when the compiler builds Louis.
internal sealed class ThrowNewExtensionsTests
{
    // The properties of an exception that depend on the code that throws it, and not on its constructor.
    private static readonly string[] ThrowSiteProperties = [
        nameof(Exception.Data),
        nameof(Exception.Source),
        nameof(Exception.StackTrace),
        nameof(Exception.TargetSite),
    ];

    public static IEnumerable<(Type ExceptionType, Action Act)> Statements() => [
        (typeof(ArgumentException), static () => ArgumentException.ThrowNew()),
        (typeof(ArgumentNullException), static () => ArgumentNullException.ThrowNew()),
        (typeof(ArgumentOutOfRangeException), static () => ArgumentOutOfRangeException.ThrowNew()),
        (typeof(DirectoryNotFoundException), static () => DirectoryNotFoundException.ThrowNew()),
        (typeof(EndOfStreamException), static () => EndOfStreamException.ThrowNew()),
        (typeof(FileNotFoundException), static () => FileNotFoundException.ThrowNew()),
        (typeof(FormatException), static () => FormatException.ThrowNew()),
        (typeof(InvalidDataException), static () => InvalidDataException.ThrowNew()),
        (typeof(InvalidOperationException), static () => InvalidOperationException.ThrowNew()),
        (typeof(IOException), static () => IOException.ThrowNew()),
        (typeof(KeyNotFoundException), static () => KeyNotFoundException.ThrowNew()),
        (typeof(NotImplementedException), static () => NotImplementedException.ThrowNew()),
        (typeof(NotSupportedException), static () => NotSupportedException.ThrowNew()),
        (typeof(ObjectDisposedException), static () => ObjectDisposedException.ThrowNew("stream")),
        (typeof(OperationCanceledException), static () => OperationCanceledException.ThrowNew()),
        (typeof(PlatformNotSupportedException), static () => PlatformNotSupportedException.ThrowNew()),
        (typeof(TimeoutException), static () => TimeoutException.ThrowNew()),
        (typeof(UnauthorizedAccessException), static () => UnauthorizedAccessException.ThrowNew()),
        (typeof(Win32Exception), static () => Win32Exception.ThrowNew()),
    ];

    public static IEnumerable<(Type ExceptionType, Func<int> Act)> Expressions() => [
        (typeof(ArgumentException), static () => ArgumentException.ThrowNew<int>()),
        (typeof(ArgumentNullException), static () => ArgumentNullException.ThrowNew<int>()),
        (typeof(ArgumentOutOfRangeException), static () => ArgumentOutOfRangeException.ThrowNew<int>()),
        (typeof(DirectoryNotFoundException), static () => DirectoryNotFoundException.ThrowNew<int>()),
        (typeof(EndOfStreamException), static () => EndOfStreamException.ThrowNew<int>()),
        (typeof(FileNotFoundException), static () => FileNotFoundException.ThrowNew<int>()),
        (typeof(FormatException), static () => FormatException.ThrowNew<int>()),
        (typeof(InvalidDataException), static () => InvalidDataException.ThrowNew<int>()),
        (typeof(InvalidOperationException), static () => InvalidOperationException.ThrowNew<int>()),
        (typeof(IOException), static () => IOException.ThrowNew<int>()),
        (typeof(KeyNotFoundException), static () => KeyNotFoundException.ThrowNew<int>()),
        (typeof(NotImplementedException), static () => NotImplementedException.ThrowNew<int>()),
        (typeof(NotSupportedException), static () => NotSupportedException.ThrowNew<int>()),
        (typeof(ObjectDisposedException), static () => ObjectDisposedException.ThrowNew<int>("stream")),
        (typeof(OperationCanceledException), static () => OperationCanceledException.ThrowNew<int>()),
        (typeof(PlatformNotSupportedException), static () => PlatformNotSupportedException.ThrowNew<int>()),
        (typeof(TimeoutException), static () => TimeoutException.ThrowNew<int>()),
        (typeof(UnauthorizedAccessException), static () => UnauthorizedAccessException.ThrowNew<int>()),
        (typeof(Win32Exception), static () => Win32Exception.ThrowNew<int>()),
    ];

    public static IEnumerable<Type> ExceptionTypes() => Statements().Select(static row => row.ExceptionType);

    [Test]
    [MethodDataSource(nameof(Statements))]
    public async Task ThrowNew_ThrowsExceptionOfTheTypeItIsCalledOn(Type exceptionType, Action act)
    {
        var exception = Assert.Throws<Exception>(act);

        await Assert.That(exception.GetType()).IsEqualTo(exceptionType);
    }

    [Test]
    [MethodDataSource(nameof(Expressions))]
    public async Task ThrowNewWithTypeArgument_ThrowsExceptionOfTheTypeItIsCalledOn(Type exceptionType, Func<int> act)
    {
        var exception = Assert.Throws<Exception>(() => _ = act());

        await Assert.That(exception.GetType()).IsEqualTo(exceptionType);
    }

    [Test]
    [MethodDataSource(nameof(ExceptionTypes))]
    public async Task ExtensionClass_HasTwoPublicMethodsForEachPublicConstructor(Type exceptionType)
    {
        var extensionClass = GetExtensionClass(exceptionType);
        var attribute = await Assert.That(extensionClass.GetCustomAttribute<ThrowNewForAttribute>()).IsNotNull();
        var constructors = exceptionType.GetConstructors();
        var methods = GetThrowNewMethods(extensionClass);
        var constructorsWithTwoMethods = constructors.Count(constructor
            => methods.Count(method => HaveSameParameters(method, constructor)) == 2);

        await Assert.That(attribute.ExceptionType).IsEqualTo(exceptionType);
        await Assert.That(attribute.Public).IsTrue();
        await Assert.That(methods).IsNotEmpty();
        await Assert.That(methods).ContainsOnly(static method => method.IsPublic);
        await Assert.That(methods.Length).IsEqualTo(2 * constructorsWithTwoMethods);

        // A build of Louis for .NET Standard has the methods of the constructors of .NET Standard.
        // The runtime that runs this test may have more constructors: .NET 11 added two to DirectoryNotFoundException.
#if !NETSTANDARD
        await Assert.That(constructorsWithTwoMethods).IsEqualTo(constructors.Length);
#endif
    }

    [Test]
    [MethodDataSource(nameof(ExceptionTypes))]
    public async Task ThrowNew_PassesItsArgumentsToTheConstructor(Type exceptionType)
    {
        // A method without parameters is left out: two instances that its constructor initializes may differ.
        // The constructor of Win32Exception without parameters reads the last error of the thread.
        var methods = GetThrowNewMethods(GetExtensionClass(exceptionType)).Where(static method => method.GetParameters().Length > 0);
        foreach (var method in methods)
        {
            var parameterTypes = GetParameterTypes(method);
            object[] arguments = [.. parameterTypes.Select(CreateArgument)];
            var constructor = await Assert.That(exceptionType.GetConstructor(parameterTypes)).IsNotNull();
            var callable = method.IsGenericMethodDefinition ? method.MakeGenericMethod(typeof(int)) : method;
            var expected = (Exception)constructor.Invoke(arguments);
            var invocationException = Assert.Throws<TargetInvocationException>(() => _ = callable.Invoke(null, arguments));
            var actual = await Assert.That(invocationException.InnerException).IsNotNull();

            await Assert.That(actual.GetType()).IsEqualTo(exceptionType);
            await Assert.That(GetConstructorState(actual)).IsEquivalentTo(GetConstructorState(expected));
        }
    }

    [Test]
    [MethodDataSource(nameof(ExceptionTypes))]
    public async Task ThrowNew_HasAttributesForCompilerAndStackTraces(Type exceptionType)
    {
        const string doesNotReturn = "System.Diagnostics.CodeAnalysis.DoesNotReturnAttribute";
        const string stackTraceHidden = "System.Diagnostics.StackTraceHiddenAttribute";
        var methods = GetThrowNewMethods(GetExtensionClass(exceptionType));

        await Assert.That(methods).ContainsOnly(static method => HasAttribute(method, doesNotReturn));
        await Assert.That(methods).ContainsOnly(static method => HasAttribute(method, stackTraceHidden));
    }

    private static Type GetExtensionClass(Type exceptionType)
    {
        var name = $"Louis.Diagnostics.{exceptionType.Name}Extensions";
        return typeof(ThrowNewForAttribute).Assembly.GetType(name)
            ?? throw new InvalidOperationException($"Louis has no class named {name}.");
    }

    // The compiler writes each static member of an extension block as a static method of the class that holds the block.
    private static MethodInfo[] GetThrowNewMethods(Type extensionClass)
    {
        const BindingFlags anyStatic = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
        return [.. extensionClass.GetMethods(anyStatic).Where(static method => method.Name == "ThrowNew")];
    }

    // The test compares names, because a build of Louis for an older framework declares the attribute itself.
    private static bool HasAttribute(MethodInfo method, string attributeName)
        => method.CustomAttributes.Any(attribute => attribute.AttributeType.FullName == attributeName);

    private static bool HaveSameParameters(MethodBase first, MethodBase second)
        => GetParameterTypes(first).SequenceEqual(GetParameterTypes(second));

    private static Type[] GetParameterTypes(MethodBase method)
        => [.. method.GetParameters().Select(static parameter => parameter.ParameterType)];

    private static object CreateArgument(Type type, int index)
        => type == typeof(string) ? $"text {index}"
            : type == typeof(int) ? index + 5
            : type == typeof(object) ? new Version(1, index)
            : type == typeof(Exception) ? new InvalidOperationException()
            : type == typeof(CancellationToken) ? new CancellationToken(canceled: true)
            : throw new InvalidOperationException($"The test has no argument for a parameter of type {type}.");

    private static (string Name, object? Value)[] GetConstructorState(Exception exception)
    {
        var properties = exception.GetType().GetProperties().Where(static property => !ThrowSiteProperties.Contains(property.Name));
        return [.. properties.Select(property => (property.Name, property.GetValue(exception)))];
    }
}
