#### [Louis](README.md 'README')
### [Louis\.Text](Louis.Text.md 'Louis\.Text')

## StringLiteralKind Enum

Represents the kind of string literal produced by `ToLiteral` methods\.

```csharp
public enum StringLiteralKind
```
### Fields

<a name='Louis.Text.StringLiteralKind.Quoted'></a>

`Quoted` 0

Represents a [quoted string literal](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#quoted-string-literals 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/programming\-guide/strings/\#quoted\-string\-literals')\.

<a name='Louis.Text.StringLiteralKind.Verbatim'></a>

`Verbatim` 1

Represents a [verbatim string literal](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/#verbatim-string-literals 'https://docs\.microsoft\.com/en\-us/dotnet/csharp/programming\-guide/strings/\#verbatim\-string\-literals')\.

### See Also
- [ToLiteral\(this string, StringLiteralKind\)](Louis.Text.StringExtensions.md#Louis.Text.StringExtensions.ToLiteral(thisstring,Louis.Text.StringLiteralKind) 'Louis\.Text\.StringExtensions\.ToLiteral\(this string, Louis\.Text\.StringLiteralKind\)')
- [ToLiteral\(this ReadOnlySpan&lt;char&gt;, StringLiteralKind\)](Louis.Text.CharReadOnlySpanExtensions.md#Louis.Text.CharReadOnlySpanExtensions.ToLiteral(thisSystem.ReadOnlySpan_char_,Louis.Text.StringLiteralKind) 'Louis\.Text\.CharReadOnlySpanExtensions\.ToLiteral\(this System\.ReadOnlySpan\<char\>, Louis\.Text\.StringLiteralKind\)')