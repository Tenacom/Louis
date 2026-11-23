---
title: Diagnostics
description: The diagnostics that the analyzers of the Louis package report.
---

The `Louis` package contains a source generator and two analyzers.
The analyzers report the diagnostics that this page describes.

## List of diagnostics

| ID                        | Severity | Title                                                                  |
| ------------------------- | -------- | ---------------------------------------------------------------------- |
| [`LOUIS0001`](#louis0001) | Warning  | A ThrowNew call throws a base type of the type it names                |
| [`LOUIS0002`](#louis0002) | Error    | ThrowNewAttribute is in a class that is not partial                    |
| [`LOUIS0003`](#louis0003) | Error    | ThrowNewAttribute is on a constructor that cannot get ThrowNew methods |
| [`LOUIS0004`](#louis0004) | Error    | ThrowNewForAttribute is on a class that cannot get ThrowNew methods    |
| [`LOUIS0005`](#louis0005) | Error    | ThrowNewForAttribute names a type that cannot get ThrowNew methods     |
| [`LOUIS0006`](#louis0006) | Warning  | A public class with ThrowNewForAttribute has internal ThrowNew methods |
| [`LOUIS0007`](#louis0007) | Error    | ThrowNew methods need a later version of C#                            |

## `ThrowNew` calls

The source generator adds `ThrowNew` methods to exception types.
[`ThrowNewAttribute`](cref:T:Louis.Diagnostics.ThrowNewAttribute) and [`ThrowNewForAttribute`](cref:T:Louis.Diagnostics.ThrowNewForAttribute) say which types get them.

### `LOUIS0001`

A `ThrowNew` call names an exception type that has no `ThrowNew` method with the parameters of the call.
The call compiles, because the type takes the `ThrowNew` methods of its base types.
The call then throws a base type, and not the type it names.

```csharp
[ThrowNewFor(typeof(ArgumentException))]
internal static partial class ArgumentExceptionExtensions;

// LOUIS0001: this call throws an ArgumentException.
ArgumentNullException.ThrowNew("The value is null.");
```

Give the type a `ThrowNew` method with those parameters, or call `ThrowNew` on the base type.

## `ThrowNewAttribute`

### `LOUIS0002`

A constructor has `ThrowNewAttribute`, and its class is not partial.
The source generator adds the `ThrowNew` methods in a second declaration of the class, which only a partial class admits.
The same holds for each type that contains the class.

Add the `partial` modifier to the class, and to each type that contains it.

### `LOUIS0003`

A constructor has `ThrowNewAttribute`, and cannot get `ThrowNew` methods.
The message states one of these reasons:

- The constructor is static.
- The type is not a class that derives from `System.Exception`.
- The class is abstract, so no code can create an instance of it.
- The constructor has a parameter of a pointer type.

Remove the attribute, or remove the reason.

## `ThrowNewForAttribute`

### `LOUIS0004`

A class has `ThrowNewForAttribute`, and cannot get `ThrowNew` methods.
The source generator adds the methods in an extension block.
The compiler admits an extension block in a static class that is neither nested nor generic.
The class must also be partial, because the source generator adds a second declaration of it.

Declare the class as `static partial`, outside any other type, and without type parameters.

### `LOUIS0005`

`ThrowNewForAttribute` names a type that cannot get `ThrowNew` methods.
The message states one of these reasons:

- The type is not `System.Exception`, nor a class that derives from it.
- The type is an unbound generic type, such as `MyException<>`.
- The type is abstract, so no code can create an instance of it.
- The type is not public, and `Public` is `true`.
  A public method cannot extend a type that other assemblies cannot see.
- The type has no public constructor that can get a method.
  A constructor with a parameter of a pointer type gets none.

Name another type, or remove the reason.

### `LOUIS0006`

A public class has `ThrowNewForAttribute`, and its `ThrowNew` methods are internal.
The class then adds an empty type to the public API of its assembly.

Make the class internal.
When other assemblies need the methods, set `Public` to `true` instead.

## Language version

### `LOUIS0007`

An attribute is in a project whose language version is older than the `ThrowNew` methods need.
The methods for `ThrowNewAttribute` need C# 8 or later.
The methods for `ThrowNewForAttribute` need C# 14 or later, because they are in an extension block.

Set the `LangVersion` property of the project to a later version.
