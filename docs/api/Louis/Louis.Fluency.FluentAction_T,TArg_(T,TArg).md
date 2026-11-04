#### [Louis](README.md 'README')
### [Louis\.Fluency](Louis.Fluency.md 'Louis\.Fluency')

## FluentAction\<T,TArg\>\(T, TArg\) Delegate

Encapsulates a method that has two parameters and returns a value of the same type as the first parameter\.

```csharp
public delegate T FluentAction<T,TArg>(T obj, TArg arg);
```
#### Type parameters

<a name='Louis.Fluency.FluentAction_T,TArg_(T,TArg).T'></a>

`T`

The type of both the first parameter and the result of the method that this delegate encapsulates\.

<a name='Louis.Fluency.FluentAction_T,TArg_(T,TArg).TArg'></a>

`TArg`

The type of the second parameter of the method that this delegate encapsulates\.
#### Parameters

<a name='Louis.Fluency.FluentAction_T,TArg_(T,TArg).obj'></a>

`obj` [T](Louis.Fluency.FluentAction_T,TArg_(T,TArg).md#Louis.Fluency.FluentAction_T,TArg_(T,TArg).T 'Louis\.Fluency\.FluentAction\<T,TArg\>\(T, TArg\)\.T')

The first parameter of the method that this delegate encapsulates\.

<a name='Louis.Fluency.FluentAction_T,TArg_(T,TArg).arg'></a>

`arg` [TArg](Louis.Fluency.FluentAction_T,TArg_(T,TArg).md#Louis.Fluency.FluentAction_T,TArg_(T,TArg).TArg 'Louis\.Fluency\.FluentAction\<T,TArg\>\(T, TArg\)\.TArg')

The second parameter of the method that this delegate encapsulates\.

#### Returns
[T](Louis.Fluency.FluentAction_T,TArg_(T,TArg).md#Louis.Fluency.FluentAction_T,TArg_(T,TArg).T 'Louis\.Fluency\.FluentAction\<T,TArg\>\(T, TArg\)\.T')  
The return value of the method that this delegate encapsulates\.
            This is usually \(but not obligatorily\), at least if [T](Louis.Fluency.FluentAction_T,TArg_(T,TArg).md#Louis.Fluency.FluentAction_T,TArg_(T,TArg).T 'Louis\.Fluency\.FluentAction\<T,TArg\>\(T, TArg\)\.T') is a reference type,
            the same reference that was passed as the first parameter to the method\.