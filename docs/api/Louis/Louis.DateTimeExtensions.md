#### [Louis](README.md 'README')
### [Louis](Louis.md 'Louis')

## DateTimeExtensions Class

Provides extension methods for instances of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')\.

```csharp
public static class DateTimeExtensions
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → DateTimeExtensions
### Methods

<a name='Louis.DateTimeExtensions.GetEndOfDay(thisSystem.DateTime)'></a>

## DateTimeExtensions\.GetEndOfDay\(this DateTime\) Method

Given a date and time, returns the last tick of the day\.

```csharp
public static System.DateTime GetEndOfDay(this System.DateTime @this);
```
#### Parameters

<a name='Louis.DateTimeExtensions.GetEndOfDay(thisSystem.DateTime).this'></a>

`this` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') on which this method is called\.

#### Returns
[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')  
An instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') whose value represents the last tick on the same day as [this](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetEndOfDay(thisSystem.DateTime).this 'Louis\.DateTimeExtensions\.GetEndOfDay\(this System\.DateTime\)\.this')\.

<a name='Louis.DateTimeExtensions.GetEndOfMonth(thisSystem.DateTime)'></a>

## DateTimeExtensions\.GetEndOfMonth\(this DateTime\) Method

Given a date and time, returns the last tick of the last day of the same month\.

```csharp
public static System.DateTime GetEndOfMonth(this System.DateTime @this);
```
#### Parameters

<a name='Louis.DateTimeExtensions.GetEndOfMonth(thisSystem.DateTime).this'></a>

`this` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') on which this method is called\.

#### Returns
[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')  
An instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') whose value represents the last tick of the last day of the month of [this](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetEndOfMonth(thisSystem.DateTime).this 'Louis\.DateTimeExtensions\.GetEndOfMonth\(this System\.DateTime\)\.this')\.

<a name='Louis.DateTimeExtensions.GetEndOfWeek(thisSystem.DateTime)'></a>

## DateTimeExtensions\.GetEndOfWeek\(this DateTime\) Method

Given a date and time, returns the last tick of the last day of the same week, according to the current culture\.

```csharp
public static System.DateTime GetEndOfWeek(this System.DateTime @this);
```
#### Parameters

<a name='Louis.DateTimeExtensions.GetEndOfWeek(thisSystem.DateTime).this'></a>

`this` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') on which this method is called\.

#### Returns
[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')  
An instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') whose value represents the last day of the week of [this](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetEndOfWeek(thisSystem.DateTime).this 'Louis\.DateTimeExtensions\.GetEndOfWeek\(this System\.DateTime\)\.this'),
            according to the current culture\.

### See Also
- [System\.Globalization\.CultureInfo\.CurrentCulture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.currentculture 'System\.Globalization\.CultureInfo\.CurrentCulture')
- [System\.Globalization\.CultureInfo\.DateTimeFormat](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.datetimeformat 'System\.Globalization\.CultureInfo\.DateTimeFormat')
- [System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo.firstdayofweek 'System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek')

<a name='Louis.DateTimeExtensions.GetEndOfWeek(thisSystem.DateTime,System.DayOfWeek)'></a>

## DateTimeExtensions\.GetEndOfWeek\(this DateTime, DayOfWeek\) Method

Returns the last tick of the earliest date, greater or equal to a given date, whose day of the week is the one preceding a specified day of the week\.

```csharp
public static System.DateTime GetEndOfWeek(this System.DateTime @this, System.DayOfWeek firstDayOfWeek);
```
#### Parameters

<a name='Louis.DateTimeExtensions.GetEndOfWeek(thisSystem.DateTime,System.DayOfWeek).this'></a>

`this` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') on which this method is called\.

<a name='Louis.DateTimeExtensions.GetEndOfWeek(thisSystem.DateTime,System.DayOfWeek).firstDayOfWeek'></a>

`firstDayOfWeek` [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek')

A [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek') value representing the day that starts the week\.

#### Returns
[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')  
An instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') whose value represents the last day of the week of [this](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetEndOfWeek(thisSystem.DateTime,System.DayOfWeek).this 'Louis\.DateTimeExtensions\.GetEndOfWeek\(this System\.DateTime, System\.DayOfWeek\)\.this'),
            if weeks are considered starting with [firstDayOfWeek](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetEndOfWeek(thisSystem.DateTime,System.DayOfWeek).firstDayOfWeek 'Louis\.DateTimeExtensions\.GetEndOfWeek\(this System\.DateTime, System\.DayOfWeek\)\.firstDayOfWeek')\.

### See Also
- [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek')

<a name='Louis.DateTimeExtensions.GetEndOfWeek(thisSystem.DateTime,System.Globalization.CultureInfo)'></a>

## DateTimeExtensions\.GetEndOfWeek\(this DateTime, CultureInfo\) Method

Given a date and time, returns the last tick of the last day of the same week, according to the specified culture\.

```csharp
public static System.DateTime GetEndOfWeek(this System.DateTime @this, System.Globalization.CultureInfo culture);
```
#### Parameters

<a name='Louis.DateTimeExtensions.GetEndOfWeek(thisSystem.DateTime,System.Globalization.CultureInfo).this'></a>

`this` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') on which this method is called\.

<a name='Louis.DateTimeExtensions.GetEndOfWeek(thisSystem.DateTime,System.Globalization.CultureInfo).culture'></a>

`culture` [System\.Globalization\.CultureInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo 'System\.Globalization\.CultureInfo')

An object that supplies culture\-specific information\.

#### Returns
[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')  
An instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') whose value represents the last day of the week of [this](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetEndOfWeek(thisSystem.DateTime,System.Globalization.CultureInfo).this 'Louis\.DateTimeExtensions\.GetEndOfWeek\(this System\.DateTime, System\.Globalization\.CultureInfo\)\.this'),
            according to [culture](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetEndOfWeek(thisSystem.DateTime,System.Globalization.CultureInfo).culture 'Louis\.DateTimeExtensions\.GetEndOfWeek\(this System\.DateTime, System\.Globalization\.CultureInfo\)\.culture')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[culture](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetEndOfWeek(thisSystem.DateTime,System.Globalization.CultureInfo).culture 'Louis\.DateTimeExtensions\.GetEndOfWeek\(this System\.DateTime, System\.Globalization\.CultureInfo\)\.culture') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### See Also
- [System\.Globalization\.CultureInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo 'System\.Globalization\.CultureInfo')
- [System\.Globalization\.CultureInfo\.DateTimeFormat](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.datetimeformat 'System\.Globalization\.CultureInfo\.DateTimeFormat')
- [System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo.firstdayofweek 'System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek')

<a name='Louis.DateTimeExtensions.GetEndOfWeek(thisSystem.DateTime,System.Globalization.DateTimeFormatInfo)'></a>

## DateTimeExtensions\.GetEndOfWeek\(this DateTime, DateTimeFormatInfo\) Method

Given a date and time, returns the last tick of the last day of the same week, according to the specified formatting information\.

```csharp
public static System.DateTime GetEndOfWeek(this System.DateTime @this, System.Globalization.DateTimeFormatInfo dateTimeFormat);
```
#### Parameters

<a name='Louis.DateTimeExtensions.GetEndOfWeek(thisSystem.DateTime,System.Globalization.DateTimeFormatInfo).this'></a>

`this` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') on which this method is called\.

<a name='Louis.DateTimeExtensions.GetEndOfWeek(thisSystem.DateTime,System.Globalization.DateTimeFormatInfo).dateTimeFormat'></a>

`dateTimeFormat` [System\.Globalization\.DateTimeFormatInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo 'System\.Globalization\.DateTimeFormatInfo')

An object that supplies culture\-specific date formatting information\.

#### Returns
[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')  
An instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') whose value represents the last day of the week of [this](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetEndOfWeek(thisSystem.DateTime,System.Globalization.DateTimeFormatInfo).this 'Louis\.DateTimeExtensions\.GetEndOfWeek\(this System\.DateTime, System\.Globalization\.DateTimeFormatInfo\)\.this'),
            according to [dateTimeFormat](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetEndOfWeek(thisSystem.DateTime,System.Globalization.DateTimeFormatInfo).dateTimeFormat 'Louis\.DateTimeExtensions\.GetEndOfWeek\(this System\.DateTime, System\.Globalization\.DateTimeFormatInfo\)\.dateTimeFormat')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[dateTimeFormat](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetEndOfWeek(thisSystem.DateTime,System.Globalization.DateTimeFormatInfo).dateTimeFormat 'Louis\.DateTimeExtensions\.GetEndOfWeek\(this System\.DateTime, System\.Globalization\.DateTimeFormatInfo\)\.dateTimeFormat') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### See Also
- [System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo.firstdayofweek 'System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek')

<a name='Louis.DateTimeExtensions.GetLastDayOfMonth(thisSystem.DateTime)'></a>

## DateTimeExtensions\.GetLastDayOfMonth\(this DateTime\) Method

Given a date and time, returns midnight on the last day of the same month\.

```csharp
public static System.DateTime GetLastDayOfMonth(this System.DateTime @this);
```
#### Parameters

<a name='Louis.DateTimeExtensions.GetLastDayOfMonth(thisSystem.DateTime).this'></a>

`this` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') on which this method is called\.

#### Returns
[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')  
An instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') whose value represents midnight on the last day of the month of [this](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetLastDayOfMonth(thisSystem.DateTime).this 'Louis\.DateTimeExtensions\.GetLastDayOfMonth\(this System\.DateTime\)\.this')\.

<a name='Louis.DateTimeExtensions.GetLastDayOfWeek(thisSystem.DateTime)'></a>

## DateTimeExtensions\.GetLastDayOfWeek\(this DateTime\) Method

Given a date and time, returns midnight on the last day of the same week, according to the current culture\.

```csharp
public static System.DateTime GetLastDayOfWeek(this System.DateTime @this);
```
#### Parameters

<a name='Louis.DateTimeExtensions.GetLastDayOfWeek(thisSystem.DateTime).this'></a>

`this` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') on which this method is called\.

#### Returns
[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')  
An instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') whose value represents the last day of the week of [this](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetLastDayOfWeek(thisSystem.DateTime).this 'Louis\.DateTimeExtensions\.GetLastDayOfWeek\(this System\.DateTime\)\.this'),
            according to the current culture\.

### See Also
- [System\.Globalization\.CultureInfo\.CurrentCulture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.currentculture 'System\.Globalization\.CultureInfo\.CurrentCulture')
- [System\.Globalization\.CultureInfo\.DateTimeFormat](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.datetimeformat 'System\.Globalization\.CultureInfo\.DateTimeFormat')
- [System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo.firstdayofweek 'System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek')

<a name='Louis.DateTimeExtensions.GetLastDayOfWeek(thisSystem.DateTime,System.DayOfWeek)'></a>

## DateTimeExtensions\.GetLastDayOfWeek\(this DateTime, DayOfWeek\) Method

Returns midnight on the earliest date, greater or equal to a given date and time, whose day of the week is the one preceding a specified day of the week\.

```csharp
public static System.DateTime GetLastDayOfWeek(this System.DateTime @this, System.DayOfWeek firstDayOfWeek);
```
#### Parameters

<a name='Louis.DateTimeExtensions.GetLastDayOfWeek(thisSystem.DateTime,System.DayOfWeek).this'></a>

`this` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') on which this method is called\.

<a name='Louis.DateTimeExtensions.GetLastDayOfWeek(thisSystem.DateTime,System.DayOfWeek).firstDayOfWeek'></a>

`firstDayOfWeek` [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek')

A [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek') value representing the day that starts the week\.

#### Returns
[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')  
An instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') whose value represents the last day of the week of [this](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetLastDayOfWeek(thisSystem.DateTime,System.DayOfWeek).this 'Louis\.DateTimeExtensions\.GetLastDayOfWeek\(this System\.DateTime, System\.DayOfWeek\)\.this'),
            if weeks are considered starting with [firstDayOfWeek](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetLastDayOfWeek(thisSystem.DateTime,System.DayOfWeek).firstDayOfWeek 'Louis\.DateTimeExtensions\.GetLastDayOfWeek\(this System\.DateTime, System\.DayOfWeek\)\.firstDayOfWeek')\.

### See Also
- [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek')

<a name='Louis.DateTimeExtensions.GetLastDayOfWeek(thisSystem.DateTime,System.Globalization.CultureInfo)'></a>

## DateTimeExtensions\.GetLastDayOfWeek\(this DateTime, CultureInfo\) Method

Given a date and time, returns midnight on the last day of the same week, according to the specified culture\.

```csharp
public static System.DateTime GetLastDayOfWeek(this System.DateTime @this, System.Globalization.CultureInfo culture);
```
#### Parameters

<a name='Louis.DateTimeExtensions.GetLastDayOfWeek(thisSystem.DateTime,System.Globalization.CultureInfo).this'></a>

`this` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') on which this method is called\.

<a name='Louis.DateTimeExtensions.GetLastDayOfWeek(thisSystem.DateTime,System.Globalization.CultureInfo).culture'></a>

`culture` [System\.Globalization\.CultureInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo 'System\.Globalization\.CultureInfo')

An object that supplies culture\-specific information\.

#### Returns
[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')  
An instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') whose value represents the last day of the week of [this](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetLastDayOfWeek(thisSystem.DateTime,System.Globalization.CultureInfo).this 'Louis\.DateTimeExtensions\.GetLastDayOfWeek\(this System\.DateTime, System\.Globalization\.CultureInfo\)\.this'),
            according to [culture](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetLastDayOfWeek(thisSystem.DateTime,System.Globalization.CultureInfo).culture 'Louis\.DateTimeExtensions\.GetLastDayOfWeek\(this System\.DateTime, System\.Globalization\.CultureInfo\)\.culture')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[culture](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetLastDayOfWeek(thisSystem.DateTime,System.Globalization.CultureInfo).culture 'Louis\.DateTimeExtensions\.GetLastDayOfWeek\(this System\.DateTime, System\.Globalization\.CultureInfo\)\.culture') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### See Also
- [System\.Globalization\.CultureInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo 'System\.Globalization\.CultureInfo')
- [System\.Globalization\.CultureInfo\.DateTimeFormat](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.datetimeformat 'System\.Globalization\.CultureInfo\.DateTimeFormat')
- [System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo.firstdayofweek 'System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek')

<a name='Louis.DateTimeExtensions.GetLastDayOfWeek(thisSystem.DateTime,System.Globalization.DateTimeFormatInfo)'></a>

## DateTimeExtensions\.GetLastDayOfWeek\(this DateTime, DateTimeFormatInfo\) Method

Given a date and time, returns midnight on the last day of the same week, according to the specified formatting information\.

```csharp
public static System.DateTime GetLastDayOfWeek(this System.DateTime @this, System.Globalization.DateTimeFormatInfo dateTimeFormat);
```
#### Parameters

<a name='Louis.DateTimeExtensions.GetLastDayOfWeek(thisSystem.DateTime,System.Globalization.DateTimeFormatInfo).this'></a>

`this` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') on which this method is called\.

<a name='Louis.DateTimeExtensions.GetLastDayOfWeek(thisSystem.DateTime,System.Globalization.DateTimeFormatInfo).dateTimeFormat'></a>

`dateTimeFormat` [System\.Globalization\.DateTimeFormatInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo 'System\.Globalization\.DateTimeFormatInfo')

An object that supplies culture\-specific date formatting information\.

#### Returns
[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')  
An instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') whose value represents the last day of the week of [this](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetLastDayOfWeek(thisSystem.DateTime,System.Globalization.DateTimeFormatInfo).this 'Louis\.DateTimeExtensions\.GetLastDayOfWeek\(this System\.DateTime, System\.Globalization\.DateTimeFormatInfo\)\.this'),
            according to [dateTimeFormat](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetLastDayOfWeek(thisSystem.DateTime,System.Globalization.DateTimeFormatInfo).dateTimeFormat 'Louis\.DateTimeExtensions\.GetLastDayOfWeek\(this System\.DateTime, System\.Globalization\.DateTimeFormatInfo\)\.dateTimeFormat')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[dateTimeFormat](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetLastDayOfWeek(thisSystem.DateTime,System.Globalization.DateTimeFormatInfo).dateTimeFormat 'Louis\.DateTimeExtensions\.GetLastDayOfWeek\(this System\.DateTime, System\.Globalization\.DateTimeFormatInfo\)\.dateTimeFormat') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### See Also
- [System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo.firstdayofweek 'System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek')

<a name='Louis.DateTimeExtensions.GetStartOfMonth(thisSystem.DateTime)'></a>

## DateTimeExtensions\.GetStartOfMonth\(this DateTime\) Method

Given a date and time, returns midnight on the first day of the same month\.

```csharp
public static System.DateTime GetStartOfMonth(this System.DateTime @this);
```
#### Parameters

<a name='Louis.DateTimeExtensions.GetStartOfMonth(thisSystem.DateTime).this'></a>

`this` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') on which this method is called\.

#### Returns
[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')  
An instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') whose value represents midnight on the first day of the month of [this](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetStartOfMonth(thisSystem.DateTime).this 'Louis\.DateTimeExtensions\.GetStartOfMonth\(this System\.DateTime\)\.this')\.

<a name='Louis.DateTimeExtensions.GetStartOfWeek(thisSystem.DateTime)'></a>

## DateTimeExtensions\.GetStartOfWeek\(this DateTime\) Method

Given a date and time, returns midnight on the first day of the same week, according to the current culture\.

```csharp
public static System.DateTime GetStartOfWeek(this System.DateTime @this);
```
#### Parameters

<a name='Louis.DateTimeExtensions.GetStartOfWeek(thisSystem.DateTime).this'></a>

`this` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') on which this method is called\.

#### Returns
[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')  
An instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') whose value represents the first day of the week of [this](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetStartOfWeek(thisSystem.DateTime).this 'Louis\.DateTimeExtensions\.GetStartOfWeek\(this System\.DateTime\)\.this'),
            according to the current culture\.

### See Also
- [System\.Globalization\.CultureInfo\.CurrentCulture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.currentculture 'System\.Globalization\.CultureInfo\.CurrentCulture')
- [System\.Globalization\.CultureInfo\.DateTimeFormat](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.datetimeformat 'System\.Globalization\.CultureInfo\.DateTimeFormat')
- [System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo.firstdayofweek 'System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek')

<a name='Louis.DateTimeExtensions.GetStartOfWeek(thisSystem.DateTime,System.DayOfWeek)'></a>

## DateTimeExtensions\.GetStartOfWeek\(this DateTime, DayOfWeek\) Method

Returns midnight on the most recent date, earlier or equal to a given date, whose day of the week is equal to a specified day of the week\.

```csharp
public static System.DateTime GetStartOfWeek(this System.DateTime @this, System.DayOfWeek firstDayOfWeek);
```
#### Parameters

<a name='Louis.DateTimeExtensions.GetStartOfWeek(thisSystem.DateTime,System.DayOfWeek).this'></a>

`this` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') on which this method is called\.

<a name='Louis.DateTimeExtensions.GetStartOfWeek(thisSystem.DateTime,System.DayOfWeek).firstDayOfWeek'></a>

`firstDayOfWeek` [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek')

A [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek') value representing the day that starts the week\.

#### Returns
[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')  
An instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') whose value represents the first day of the week of [this](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetStartOfWeek(thisSystem.DateTime,System.DayOfWeek).this 'Louis\.DateTimeExtensions\.GetStartOfWeek\(this System\.DateTime, System\.DayOfWeek\)\.this'),
            if weeks are considered starting with [firstDayOfWeek](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetStartOfWeek(thisSystem.DateTime,System.DayOfWeek).firstDayOfWeek 'Louis\.DateTimeExtensions\.GetStartOfWeek\(this System\.DateTime, System\.DayOfWeek\)\.firstDayOfWeek')\.

### See Also
- [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek')

<a name='Louis.DateTimeExtensions.GetStartOfWeek(thisSystem.DateTime,System.Globalization.CultureInfo)'></a>

## DateTimeExtensions\.GetStartOfWeek\(this DateTime, CultureInfo\) Method

Given a date and time, returns midnight on the first day of the same week, according to the specified culture\.

```csharp
public static System.DateTime GetStartOfWeek(this System.DateTime @this, System.Globalization.CultureInfo culture);
```
#### Parameters

<a name='Louis.DateTimeExtensions.GetStartOfWeek(thisSystem.DateTime,System.Globalization.CultureInfo).this'></a>

`this` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') on which this method is called\.

<a name='Louis.DateTimeExtensions.GetStartOfWeek(thisSystem.DateTime,System.Globalization.CultureInfo).culture'></a>

`culture` [System\.Globalization\.CultureInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo 'System\.Globalization\.CultureInfo')

An object that supplies culture\-specific information\.

#### Returns
[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')  
An instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') whose value represents the first day of the week of [this](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetStartOfWeek(thisSystem.DateTime,System.Globalization.CultureInfo).this 'Louis\.DateTimeExtensions\.GetStartOfWeek\(this System\.DateTime, System\.Globalization\.CultureInfo\)\.this'),
            according to [culture](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetStartOfWeek(thisSystem.DateTime,System.Globalization.CultureInfo).culture 'Louis\.DateTimeExtensions\.GetStartOfWeek\(this System\.DateTime, System\.Globalization\.CultureInfo\)\.culture')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[culture](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetStartOfWeek(thisSystem.DateTime,System.Globalization.CultureInfo).culture 'Louis\.DateTimeExtensions\.GetStartOfWeek\(this System\.DateTime, System\.Globalization\.CultureInfo\)\.culture') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### See Also
- [System\.Globalization\.CultureInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo 'System\.Globalization\.CultureInfo')
- [System\.Globalization\.CultureInfo\.DateTimeFormat](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.datetimeformat 'System\.Globalization\.CultureInfo\.DateTimeFormat')
- [System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo.firstdayofweek 'System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek')

<a name='Louis.DateTimeExtensions.GetStartOfWeek(thisSystem.DateTime,System.Globalization.DateTimeFormatInfo)'></a>

## DateTimeExtensions\.GetStartOfWeek\(this DateTime, DateTimeFormatInfo\) Method

Given a date and time, returns midnight on the first day of the same week, according to the specified formatting information\.

```csharp
public static System.DateTime GetStartOfWeek(this System.DateTime @this, System.Globalization.DateTimeFormatInfo dateTimeFormat);
```
#### Parameters

<a name='Louis.DateTimeExtensions.GetStartOfWeek(thisSystem.DateTime,System.Globalization.DateTimeFormatInfo).this'></a>

`this` [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')

The instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') on which this method is called\.

<a name='Louis.DateTimeExtensions.GetStartOfWeek(thisSystem.DateTime,System.Globalization.DateTimeFormatInfo).dateTimeFormat'></a>

`dateTimeFormat` [System\.Globalization\.DateTimeFormatInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo 'System\.Globalization\.DateTimeFormatInfo')

An object that supplies culture\-specific date formatting information\.

#### Returns
[System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime')  
An instance of [System\.DateTime](https://learn.microsoft.com/en-us/dotnet/api/system.datetime 'System\.DateTime') whose value represents the first day of the week of [this](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetStartOfWeek(thisSystem.DateTime,System.Globalization.DateTimeFormatInfo).this 'Louis\.DateTimeExtensions\.GetStartOfWeek\(this System\.DateTime, System\.Globalization\.DateTimeFormatInfo\)\.this'),
            according to [dateTimeFormat](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetStartOfWeek(thisSystem.DateTime,System.Globalization.DateTimeFormatInfo).dateTimeFormat 'Louis\.DateTimeExtensions\.GetStartOfWeek\(this System\.DateTime, System\.Globalization\.DateTimeFormatInfo\)\.dateTimeFormat')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[dateTimeFormat](Louis.DateTimeExtensions.md#Louis.DateTimeExtensions.GetStartOfWeek(thisSystem.DateTime,System.Globalization.DateTimeFormatInfo).dateTimeFormat 'Louis\.DateTimeExtensions\.GetStartOfWeek\(this System\.DateTime, System\.Globalization\.DateTimeFormatInfo\)\.dateTimeFormat') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### See Also
- [System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo.firstdayofweek 'System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek')