#### [Louis](README.md 'README')
### [Louis\.Fluency](Louis.Fluency.md 'Louis\.Fluency')

## FluentAction\<T\>\(T\) Delegate

Encapsulates a method that has one parameter and returns a value of the same type as the parameter\.

```csharp
public delegate T FluentAction<T>(T obj);
```
#### Type parameters

<a name='Louis.Fluency.FluentAction_T_(T).T'></a>

`T`

The type of both the parameter and the result of the method that this delegate encapsulates\.
#### Parameters

<a name='Louis.Fluency.FluentAction_T_(T).obj'></a>

`obj` [T](Louis.Fluency.FluentAction_T_(T).md#Louis.Fluency.FluentAction_T_(T).T 'Louis\.Fluency\.FluentAction\<T\>\(T\)\.T')

The parameter of the method that this delegate encapsulates\.

#### Returns
[T](Louis.Fluency.FluentAction_T_(T).md#Louis.Fluency.FluentAction_T_(T).T 'Louis\.Fluency\.FluentAction\<T\>\(T\)\.T')  
The return value of the method that this delegate encapsulates\.
            This is usually \(but not obligatorily\), at least is [T](Louis.Fluency.FluentAction_T_(T).md#Louis.Fluency.FluentAction_T_(T).T 'Louis\.Fluency\.FluentAction\<T\>\(T\)\.T') is a reference type,
            the same reference that was passed to the method\.