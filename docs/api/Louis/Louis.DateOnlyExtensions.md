#### [Louis](README.md 'README')
### [Louis](Louis.md 'Louis')

## DateOnlyExtensions Class

Provides extension methods for instances of [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly')\.

```csharp
public static class DateOnlyExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → DateOnlyExtensions
### Methods

<a name='Louis.DateOnlyExtensions.GetEndOfMonth(thisSystem.DateOnly)'></a>

## DateOnlyExtensions\.GetEndOfMonth\(this DateOnly\) Method

Given a date, returns the last day of the same month\.

```csharp
public static System.DateOnly GetEndOfMonth(this System.DateOnly @this);
```
#### Parameters

<a name='Louis.DateOnlyExtensions.GetEndOfMonth(thisSystem.DateOnly).this'></a>

`this` [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly')

The instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') on which this method is called\.

#### Returns
[System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly')  
An instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') whose value represents the last day of the month of [this](Louis.DateOnlyExtensions.md#Louis.DateOnlyExtensions.GetEndOfMonth(thisSystem.DateOnly).this 'Louis\.DateOnlyExtensions\.GetEndOfMonth\(this System\.DateOnly\)\.this')\.

<a name='Louis.DateOnlyExtensions.GetEndOfWeek(thisSystem.DateOnly)'></a>

## DateOnlyExtensions\.GetEndOfWeek\(this DateOnly\) Method

Given a date, returns the last day of the same week, according to the current culture\.

```csharp
public static System.DateOnly GetEndOfWeek(this System.DateOnly @this);
```
#### Parameters

<a name='Louis.DateOnlyExtensions.GetEndOfWeek(thisSystem.DateOnly).this'></a>

`this` [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly')

The instance of [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly') on which this method is called\.

#### Returns
[System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly')  
An instance of [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly') whose value represents the last day of the week of [this](Louis.DateOnlyExtensions.md#Louis.DateOnlyExtensions.GetEndOfWeek(thisSystem.DateOnly).this 'Louis\.DateOnlyExtensions\.GetEndOfWeek\(this System\.DateOnly\)\.this'),
            according to the current culture\.

### See Also
- [System\.Globalization\.CultureInfo\.CurrentCulture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.currentculture 'System\.Globalization\.CultureInfo\.CurrentCulture')
- [System\.Globalization\.CultureInfo\.DateTimeFormat](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.datetimeformat 'System\.Globalization\.CultureInfo\.DateTimeFormat')
- [System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo.firstdayofweek 'System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek')

<a name='Louis.DateOnlyExtensions.GetEndOfWeek(thisSystem.DateOnly,System.DayOfWeek)'></a>

## DateOnlyExtensions\.GetEndOfWeek\(this DateOnly, DayOfWeek\) Method

Returns the earliest date, greater or equal to a given date, whose day of the week is the one preceding a specified day of the week\.

```csharp
public static System.DateOnly GetEndOfWeek(this System.DateOnly @this, System.DayOfWeek firstDayOfWeek);
```
#### Parameters

<a name='Louis.DateOnlyExtensions.GetEndOfWeek(thisSystem.DateOnly,System.DayOfWeek).this'></a>

`this` [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly')

The instance of [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly') on which this method is called\.

<a name='Louis.DateOnlyExtensions.GetEndOfWeek(thisSystem.DateOnly,System.DayOfWeek).firstDayOfWeek'></a>

`firstDayOfWeek` [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek')

A [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek') value representing the day that starts the week\.

#### Returns
[System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly')  
An instance of [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly') whose value represents the last day of the week of [this](Louis.DateOnlyExtensions.md#Louis.DateOnlyExtensions.GetEndOfWeek(thisSystem.DateOnly,System.DayOfWeek).this 'Louis\.DateOnlyExtensions\.GetEndOfWeek\(this System\.DateOnly, System\.DayOfWeek\)\.this'),
            if weeks are considered starting with [firstDayOfWeek](Louis.DateOnlyExtensions.md#Louis.DateOnlyExtensions.GetEndOfWeek(thisSystem.DateOnly,System.DayOfWeek).firstDayOfWeek 'Louis\.DateOnlyExtensions\.GetEndOfWeek\(this System\.DateOnly, System\.DayOfWeek\)\.firstDayOfWeek')\.

### See Also
- [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek')

<a name='Louis.DateOnlyExtensions.GetEndOfWeek(thisSystem.DateOnly,System.Globalization.CultureInfo)'></a>

## DateOnlyExtensions\.GetEndOfWeek\(this DateOnly, CultureInfo\) Method

Given a date, returns the last day of the same week, according to the specified culture\.

```csharp
public static System.DateOnly GetEndOfWeek(this System.DateOnly @this, System.Globalization.CultureInfo culture);
```
#### Parameters

<a name='Louis.DateOnlyExtensions.GetEndOfWeek(thisSystem.DateOnly,System.Globalization.CultureInfo).this'></a>

`this` [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly')

The instance of [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly') on which this method is called\.

<a name='Louis.DateOnlyExtensions.GetEndOfWeek(thisSystem.DateOnly,System.Globalization.CultureInfo).culture'></a>

`culture` [System\.Globalization\.CultureInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo 'System\.Globalization\.CultureInfo')

An object that supplies culture\-specific information\.

#### Returns
[System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly')  
An instance of [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly') whose value represents the last day of the week of [this](Louis.DateOnlyExtensions.md#Louis.DateOnlyExtensions.GetEndOfWeek(thisSystem.DateOnly,System.Globalization.CultureInfo).this 'Louis\.DateOnlyExtensions\.GetEndOfWeek\(this System\.DateOnly, System\.Globalization\.CultureInfo\)\.this'),
            according to [culture](Louis.DateOnlyExtensions.md#Louis.DateOnlyExtensions.GetEndOfWeek(thisSystem.DateOnly,System.Globalization.CultureInfo).culture 'Louis\.DateOnlyExtensions\.GetEndOfWeek\(this System\.DateOnly, System\.Globalization\.CultureInfo\)\.culture')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[culture](Louis.DateOnlyExtensions.md#Louis.DateOnlyExtensions.GetEndOfWeek(thisSystem.DateOnly,System.Globalization.CultureInfo).culture 'Louis\.DateOnlyExtensions\.GetEndOfWeek\(this System\.DateOnly, System\.Globalization\.CultureInfo\)\.culture') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### See Also
- [System\.Globalization\.CultureInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo 'System\.Globalization\.CultureInfo')
- [System\.Globalization\.CultureInfo\.DateTimeFormat](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.datetimeformat 'System\.Globalization\.CultureInfo\.DateTimeFormat')
- [System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo.firstdayofweek 'System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek')

<a name='Louis.DateOnlyExtensions.GetEndOfWeek(thisSystem.DateOnly,System.Globalization.DateTimeFormatInfo)'></a>

## DateOnlyExtensions\.GetEndOfWeek\(this DateOnly, DateTimeFormatInfo\) Method

Given a date, returns the last day of the same week, according to the specified formatting information\.

```csharp
public static System.DateOnly GetEndOfWeek(this System.DateOnly @this, System.Globalization.DateTimeFormatInfo dateTimeFormat);
```
#### Parameters

<a name='Louis.DateOnlyExtensions.GetEndOfWeek(thisSystem.DateOnly,System.Globalization.DateTimeFormatInfo).this'></a>

`this` [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly')

The instance of [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly') on which this method is called\.

<a name='Louis.DateOnlyExtensions.GetEndOfWeek(thisSystem.DateOnly,System.Globalization.DateTimeFormatInfo).dateTimeFormat'></a>

`dateTimeFormat` [System\.Globalization\.DateTimeFormatInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo 'System\.Globalization\.DateTimeFormatInfo')

An object that supplies culture\-specific date formatting information\.

#### Returns
[System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly')  
An instance of [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly') whose value represents the last day of the week of [this](Louis.DateOnlyExtensions.md#Louis.DateOnlyExtensions.GetEndOfWeek(thisSystem.DateOnly,System.Globalization.DateTimeFormatInfo).this 'Louis\.DateOnlyExtensions\.GetEndOfWeek\(this System\.DateOnly, System\.Globalization\.DateTimeFormatInfo\)\.this'),
            according to [dateTimeFormat](Louis.DateOnlyExtensions.md#Louis.DateOnlyExtensions.GetEndOfWeek(thisSystem.DateOnly,System.Globalization.DateTimeFormatInfo).dateTimeFormat 'Louis\.DateOnlyExtensions\.GetEndOfWeek\(this System\.DateOnly, System\.Globalization\.DateTimeFormatInfo\)\.dateTimeFormat')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[dateTimeFormat](Louis.DateOnlyExtensions.md#Louis.DateOnlyExtensions.GetEndOfWeek(thisSystem.DateOnly,System.Globalization.DateTimeFormatInfo).dateTimeFormat 'Louis\.DateOnlyExtensions\.GetEndOfWeek\(this System\.DateOnly, System\.Globalization\.DateTimeFormatInfo\)\.dateTimeFormat') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### See Also
- [System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo.firstdayofweek 'System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek')

<a name='Louis.DateOnlyExtensions.GetStartOfMonth(thisSystem.DateOnly)'></a>

## DateOnlyExtensions\.GetStartOfMonth\(this DateOnly\) Method

Given a date, returns the first day of the same month\.

```csharp
public static System.DateOnly GetStartOfMonth(this System.DateOnly @this);
```
#### Parameters

<a name='Louis.DateOnlyExtensions.GetStartOfMonth(thisSystem.DateOnly).this'></a>

`this` [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly')

The instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') on which this method is called\.

#### Returns
[System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly')  
An instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') whose value represents the first day of the month of [this](Louis.DateOnlyExtensions.md#Louis.DateOnlyExtensions.GetStartOfMonth(thisSystem.DateOnly).this 'Louis\.DateOnlyExtensions\.GetStartOfMonth\(this System\.DateOnly\)\.this')\.

<a name='Louis.DateOnlyExtensions.GetStartOfWeek(thisSystem.DateOnly)'></a>

## DateOnlyExtensions\.GetStartOfWeek\(this DateOnly\) Method

Given a date, returns the first day of the same week, according to the current culture\.

```csharp
public static System.DateOnly GetStartOfWeek(this System.DateOnly @this);
```
#### Parameters

<a name='Louis.DateOnlyExtensions.GetStartOfWeek(thisSystem.DateOnly).this'></a>

`this` [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly')

The instance of [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly') on which this method is called\.

#### Returns
[System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly')  
An instance of [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly') whose value represents the first day of the week of [this](Louis.DateOnlyExtensions.md#Louis.DateOnlyExtensions.GetStartOfWeek(thisSystem.DateOnly).this 'Louis\.DateOnlyExtensions\.GetStartOfWeek\(this System\.DateOnly\)\.this'),
            according to the current culture\.

### See Also
- [System\.Globalization\.CultureInfo\.CurrentCulture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.currentculture 'System\.Globalization\.CultureInfo\.CurrentCulture')
- [System\.Globalization\.CultureInfo\.DateTimeFormat](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.datetimeformat 'System\.Globalization\.CultureInfo\.DateTimeFormat')
- [System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo.firstdayofweek 'System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek')

<a name='Louis.DateOnlyExtensions.GetStartOfWeek(thisSystem.DateOnly,System.DayOfWeek)'></a>

## DateOnlyExtensions\.GetStartOfWeek\(this DateOnly, DayOfWeek\) Method

Returns the most recent date, earlier or equal to a given date, whose day of the week is equal to a specified day of the week\.

```csharp
public static System.DateOnly GetStartOfWeek(this System.DateOnly @this, System.DayOfWeek firstDayOfWeek);
```
#### Parameters

<a name='Louis.DateOnlyExtensions.GetStartOfWeek(thisSystem.DateOnly,System.DayOfWeek).this'></a>

`this` [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly')

The instance of [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly') on which this method is called\.

<a name='Louis.DateOnlyExtensions.GetStartOfWeek(thisSystem.DateOnly,System.DayOfWeek).firstDayOfWeek'></a>

`firstDayOfWeek` [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek')

A [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek') value representing the day that starts the week\.

#### Returns
[System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly')  
An instance of [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly') whose value represents the first day of the week of [this](Louis.DateOnlyExtensions.md#Louis.DateOnlyExtensions.GetStartOfWeek(thisSystem.DateOnly,System.DayOfWeek).this 'Louis\.DateOnlyExtensions\.GetStartOfWeek\(this System\.DateOnly, System\.DayOfWeek\)\.this'),
            if weeks are considered starting with [firstDayOfWeek](Louis.DateOnlyExtensions.md#Louis.DateOnlyExtensions.GetStartOfWeek(thisSystem.DateOnly,System.DayOfWeek).firstDayOfWeek 'Louis\.DateOnlyExtensions\.GetStartOfWeek\(this System\.DateOnly, System\.DayOfWeek\)\.firstDayOfWeek')\.

### See Also
- [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek')

<a name='Louis.DateOnlyExtensions.GetStartOfWeek(thisSystem.DateOnly,System.Globalization.CultureInfo)'></a>

## DateOnlyExtensions\.GetStartOfWeek\(this DateOnly, CultureInfo\) Method

Given a date, returns the first day of the same week, according to the specified culture\.

```csharp
public static System.DateOnly GetStartOfWeek(this System.DateOnly @this, System.Globalization.CultureInfo culture);
```
#### Parameters

<a name='Louis.DateOnlyExtensions.GetStartOfWeek(thisSystem.DateOnly,System.Globalization.CultureInfo).this'></a>

`this` [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly')

The instance of [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly') on which this method is called\.

<a name='Louis.DateOnlyExtensions.GetStartOfWeek(thisSystem.DateOnly,System.Globalization.CultureInfo).culture'></a>

`culture` [System\.Globalization\.CultureInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo 'System\.Globalization\.CultureInfo')

An object that supplies culture\-specific information\.

#### Returns
[System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly')  
An instance of [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly') whose value represents the first day of the week of [this](Louis.DateOnlyExtensions.md#Louis.DateOnlyExtensions.GetStartOfWeek(thisSystem.DateOnly,System.Globalization.CultureInfo).this 'Louis\.DateOnlyExtensions\.GetStartOfWeek\(this System\.DateOnly, System\.Globalization\.CultureInfo\)\.this'),
            according to [culture](Louis.DateOnlyExtensions.md#Louis.DateOnlyExtensions.GetStartOfWeek(thisSystem.DateOnly,System.Globalization.CultureInfo).culture 'Louis\.DateOnlyExtensions\.GetStartOfWeek\(this System\.DateOnly, System\.Globalization\.CultureInfo\)\.culture')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[culture](Louis.DateOnlyExtensions.md#Louis.DateOnlyExtensions.GetStartOfWeek(thisSystem.DateOnly,System.Globalization.CultureInfo).culture 'Louis\.DateOnlyExtensions\.GetStartOfWeek\(this System\.DateOnly, System\.Globalization\.CultureInfo\)\.culture') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### See Also
- [System\.Globalization\.CultureInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo 'System\.Globalization\.CultureInfo')
- [System\.Globalization\.CultureInfo\.DateTimeFormat](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.datetimeformat 'System\.Globalization\.CultureInfo\.DateTimeFormat')
- [System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo.firstdayofweek 'System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek')

<a name='Louis.DateOnlyExtensions.GetStartOfWeek(thisSystem.DateOnly,System.Globalization.DateTimeFormatInfo)'></a>

## DateOnlyExtensions\.GetStartOfWeek\(this DateOnly, DateTimeFormatInfo\) Method

Given a date, returns the first day of the same week, according to the specified formatting information\.

```csharp
public static System.DateOnly GetStartOfWeek(this System.DateOnly @this, System.Globalization.DateTimeFormatInfo dateTimeFormat);
```
#### Parameters

<a name='Louis.DateOnlyExtensions.GetStartOfWeek(thisSystem.DateOnly,System.Globalization.DateTimeFormatInfo).this'></a>

`this` [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly')

The instance of [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly') on which this method is called\.

<a name='Louis.DateOnlyExtensions.GetStartOfWeek(thisSystem.DateOnly,System.Globalization.DateTimeFormatInfo).dateTimeFormat'></a>

`dateTimeFormat` [System\.Globalization\.DateTimeFormatInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo 'System\.Globalization\.DateTimeFormatInfo')

An object that supplies culture\-specific date formatting information\.

#### Returns
[System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly')  
An instance of [System\.DateOnly](https://learn.microsoft.com/en-us/dotnet/api/system.dateonly 'System\.DateOnly') whose value represents the first day of the week of [this](Louis.DateOnlyExtensions.md#Louis.DateOnlyExtensions.GetStartOfWeek(thisSystem.DateOnly,System.Globalization.DateTimeFormatInfo).this 'Louis\.DateOnlyExtensions\.GetStartOfWeek\(this System\.DateOnly, System\.Globalization\.DateTimeFormatInfo\)\.this'),
            according to [dateTimeFormat](Louis.DateOnlyExtensions.md#Louis.DateOnlyExtensions.GetStartOfWeek(thisSystem.DateOnly,System.Globalization.DateTimeFormatInfo).dateTimeFormat 'Louis\.DateOnlyExtensions\.GetStartOfWeek\(this System\.DateOnly, System\.Globalization\.DateTimeFormatInfo\)\.dateTimeFormat')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[dateTimeFormat](Louis.DateOnlyExtensions.md#Louis.DateOnlyExtensions.GetStartOfWeek(thisSystem.DateOnly,System.Globalization.DateTimeFormatInfo).dateTimeFormat 'Louis\.DateOnlyExtensions\.GetStartOfWeek\(this System\.DateOnly, System\.Globalization\.DateTimeFormatInfo\)\.dateTimeFormat') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### See Also
- [System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo.firstdayofweek 'System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek')