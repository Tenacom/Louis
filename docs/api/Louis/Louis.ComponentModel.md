#### [Louis](README.md 'README')

## Louis\.ComponentModel Namespace

Provides type converters that convert instances of a type to and from strings,
and base classes to write such converters\.

| Classes | |
| :--- | :--- |
| [MailAddressCollectionConverter](Louis.ComponentModel.MailAddressCollectionConverter.md 'Louis\.ComponentModel\.MailAddressCollectionConverter') | Provides a type converter to convert [System\.Net\.Mail\.MailAddressCollection](https://learn.microsoft.com/en-us/dotnet/api/system.net.mail.mailaddresscollection 'System\.Net\.Mail\.MailAddressCollection') instances to and from strings\. |
| [MailAddressConverter](Louis.ComponentModel.MailAddressConverter.md 'Louis\.ComponentModel\.MailAddressConverter') | Provides a type converter to convert [System\.Net\.Mail\.MailAddress](https://learn.microsoft.com/en-us/dotnet/api/system.net.mail.mailaddress 'System\.Net\.Mail\.MailAddress') instances to and from strings\. |
| [ParsableStringConverter&lt;T&gt;](Louis.ComponentModel.ParsableStringConverter_T_.md 'Louis\.ComponentModel\.ParsableStringConverter\<T\>') |   A type converters that uses the [System\.IParsable&lt;&gt;](https://learn.microsoft.com/en-us/dotnet/api/system.iparsable-1 'System\.IParsable\`1') interface to convert strings to instances of a type.  If the type also implements [System\.IFormattable](https://learn.microsoft.com/en-us/dotnet/api/system.iformattable 'System\.IFormattable'), it is used to perform the opposite conversion. |
| [SimpleStringConverter](Louis.ComponentModel.SimpleStringConverter.md 'Louis\.ComponentModel\.SimpleStringConverter') | Provides utility methods to simplify use of type converters derived from [SimpleStringConverter&lt;T&gt;](Louis.ComponentModel.SimpleStringConverter_T_.md 'Louis\.ComponentModel\.SimpleStringConverter\<T\>')\. |
| [SimpleStringConverter&lt;T&gt;](Louis.ComponentModel.SimpleStringConverter_T_.md 'Louis\.ComponentModel\.SimpleStringConverter\<T\>') | Base class for type converters that can convert instances of a specific type to and from strings\. |
