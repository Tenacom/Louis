#### [Louis](README.md 'README')
### [Louis](Louis.md 'Louis')

## DateUtility Class

Provides utility methods to work with dates\.

```csharp
public static class DateUtility
```

Inheritance [System\.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object 'System\.Object') → DateUtility
### Methods

<a name='Louis.DateUtility.GetDaysFromStartOfWeek(System.DayOfWeek)'></a>

## DateUtility\.GetDaysFromStartOfWeek\(DayOfWeek\) Method

Returns the amount of full days separating a given day of the week from the first day of the same week,
according to the current culture\.

```csharp
public static int GetDaysFromStartOfWeek(System.DayOfWeek today);
```
#### Parameters

<a name='Louis.DateUtility.GetDaysFromStartOfWeek(System.DayOfWeek).today'></a>

`today` [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek')

A [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek') value\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
An integer number between 0 and 6 representing the days between the start of the week and [today](Louis.DateUtility.md#Louis.DateUtility.GetDaysFromStartOfWeek(System.DayOfWeek).today 'Louis\.DateUtility\.GetDaysFromStartOfWeek\(System\.DayOfWeek\)\.today'),
            according to the current culture\.

### See Also
- [System\.Globalization\.CultureInfo\.CurrentCulture](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.currentculture 'System\.Globalization\.CultureInfo\.CurrentCulture')
- [System\.Globalization\.CultureInfo\.DateTimeFormat](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.datetimeformat 'System\.Globalization\.CultureInfo\.DateTimeFormat')
- [System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo.firstdayofweek 'System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek')

<a name='Louis.DateUtility.GetDaysFromStartOfWeek(System.DayOfWeek,System.DayOfWeek)'></a>

## DateUtility\.GetDaysFromStartOfWeek\(DayOfWeek, DayOfWeek\) Method

Returns the amount of full days separating a given day of the week from the first day of the same week,
if a given day is considered the first of the week\.

```csharp
public static int GetDaysFromStartOfWeek(System.DayOfWeek today, System.DayOfWeek firstDayOfWeek);
```
#### Parameters

<a name='Louis.DateUtility.GetDaysFromStartOfWeek(System.DayOfWeek,System.DayOfWeek).today'></a>

`today` [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek')

A [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek') value\.

<a name='Louis.DateUtility.GetDaysFromStartOfWeek(System.DayOfWeek,System.DayOfWeek).firstDayOfWeek'></a>

`firstDayOfWeek` [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek')

A [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek') value representing the day that starts the week\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
An integer number between 0 and 6 representing the days between the start of the week and [today](Louis.DateUtility.md#Louis.DateUtility.GetDaysFromStartOfWeek(System.DayOfWeek,System.DayOfWeek).today 'Louis\.DateUtility\.GetDaysFromStartOfWeek\(System\.DayOfWeek, System\.DayOfWeek\)\.today'),
            if weeks are considered starting with [firstDayOfWeek](Louis.DateUtility.md#Louis.DateUtility.GetDaysFromStartOfWeek(System.DayOfWeek,System.DayOfWeek).firstDayOfWeek 'Louis\.DateUtility\.GetDaysFromStartOfWeek\(System\.DayOfWeek, System\.DayOfWeek\)\.firstDayOfWeek')\.

### See Also
- [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek')

<a name='Louis.DateUtility.GetDaysFromStartOfWeek(System.DayOfWeek,System.Globalization.CultureInfo)'></a>

## DateUtility\.GetDaysFromStartOfWeek\(DayOfWeek, CultureInfo\) Method

Returns the amount of full days separating a given day of the week from the first day of the same week,
according to the specified culture\.

```csharp
public static int GetDaysFromStartOfWeek(System.DayOfWeek today, System.Globalization.CultureInfo culture);
```
#### Parameters

<a name='Louis.DateUtility.GetDaysFromStartOfWeek(System.DayOfWeek,System.Globalization.CultureInfo).today'></a>

`today` [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek')

A [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek') value\.

<a name='Louis.DateUtility.GetDaysFromStartOfWeek(System.DayOfWeek,System.Globalization.CultureInfo).culture'></a>

`culture` [System\.Globalization\.CultureInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo 'System\.Globalization\.CultureInfo')

An object that supplies culture\-specific information\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
An integer number between 0 and 6 representing the days between the start of the week and [today](Louis.DateUtility.md#Louis.DateUtility.GetDaysFromStartOfWeek(System.DayOfWeek,System.Globalization.CultureInfo).today 'Louis\.DateUtility\.GetDaysFromStartOfWeek\(System\.DayOfWeek, System\.Globalization\.CultureInfo\)\.today'),
            according to [culture](Louis.DateUtility.md#Louis.DateUtility.GetDaysFromStartOfWeek(System.DayOfWeek,System.Globalization.CultureInfo).culture 'Louis\.DateUtility\.GetDaysFromStartOfWeek\(System\.DayOfWeek, System\.Globalization\.CultureInfo\)\.culture')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[culture](Louis.DateUtility.md#Louis.DateUtility.GetDaysFromStartOfWeek(System.DayOfWeek,System.Globalization.CultureInfo).culture 'Louis\.DateUtility\.GetDaysFromStartOfWeek\(System\.DayOfWeek, System\.Globalization\.CultureInfo\)\.culture') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### See Also
- [System\.Globalization\.CultureInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo 'System\.Globalization\.CultureInfo')
- [System\.Globalization\.CultureInfo\.DateTimeFormat](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.cultureinfo.datetimeformat 'System\.Globalization\.CultureInfo\.DateTimeFormat')
- [System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo.firstdayofweek 'System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek')

<a name='Louis.DateUtility.GetDaysFromStartOfWeek(System.DayOfWeek,System.Globalization.DateTimeFormatInfo)'></a>

## DateUtility\.GetDaysFromStartOfWeek\(DayOfWeek, DateTimeFormatInfo\) Method

Returns the amount of full days separating a given day of the week from the first day of the same week,
according to the specified formatting information\.

```csharp
public static int GetDaysFromStartOfWeek(System.DayOfWeek today, System.Globalization.DateTimeFormatInfo dateTimeFormat);
```
#### Parameters

<a name='Louis.DateUtility.GetDaysFromStartOfWeek(System.DayOfWeek,System.Globalization.DateTimeFormatInfo).today'></a>

`today` [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek')

A [System\.DayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.dayofweek 'System\.DayOfWeek') value\.

<a name='Louis.DateUtility.GetDaysFromStartOfWeek(System.DayOfWeek,System.Globalization.DateTimeFormatInfo).dateTimeFormat'></a>

`dateTimeFormat` [System\.Globalization\.DateTimeFormatInfo](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo 'System\.Globalization\.DateTimeFormatInfo')

An object that supplies culture\-specific date formatting information\.

#### Returns
[System\.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32 'System\.Int32')  
An integer number between 0 and 6 representing the days between the start of the week and [today](Louis.DateUtility.md#Louis.DateUtility.GetDaysFromStartOfWeek(System.DayOfWeek,System.Globalization.DateTimeFormatInfo).today 'Louis\.DateUtility\.GetDaysFromStartOfWeek\(System\.DayOfWeek, System\.Globalization\.DateTimeFormatInfo\)\.today'),
            according to [dateTimeFormat](Louis.DateUtility.md#Louis.DateUtility.GetDaysFromStartOfWeek(System.DayOfWeek,System.Globalization.DateTimeFormatInfo).dateTimeFormat 'Louis\.DateUtility\.GetDaysFromStartOfWeek\(System\.DayOfWeek, System\.Globalization\.DateTimeFormatInfo\)\.dateTimeFormat')\.

#### Exceptions

[System\.ArgumentNullException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentnullexception 'System\.ArgumentNullException')  
[dateTimeFormat](Louis.DateUtility.md#Louis.DateUtility.GetDaysFromStartOfWeek(System.DayOfWeek,System.Globalization.DateTimeFormatInfo).dateTimeFormat 'Louis\.DateUtility\.GetDaysFromStartOfWeek\(System\.DayOfWeek, System\.Globalization\.DateTimeFormatInfo\)\.dateTimeFormat') is [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/language\-reference/keywords/null')\.

### See Also
- [System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek](https://learn.microsoft.com/en-us/dotnet/api/system.globalization.datetimeformatinfo.firstdayofweek 'System\.Globalization\.DateTimeFormatInfo\.FirstDayOfWeek')