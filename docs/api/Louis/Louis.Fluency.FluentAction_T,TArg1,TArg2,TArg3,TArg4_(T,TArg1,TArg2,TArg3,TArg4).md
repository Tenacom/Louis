#### [Louis](README.md 'README')
### [Louis\.Fluency](Louis.Fluency.md 'Louis\.Fluency')

## FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\(T, TArg1, TArg2, TArg3, TArg4\) Delegate

Encapsulates a method that has five parameters and returns a value of the same type as the first parameter\.

```csharp
public delegate T FluentAction<T,TArg1,TArg2,TArg3,TArg4>(T obj, TArg1 arg1, TArg2 arg2, TArg3 arg3, TArg4 arg4);
```
#### Type parameters

<a name='Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).T'></a>

`T`

The type of both the first parameter and the result of the method that this delegate encapsulates\.

<a name='Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).TArg1'></a>

`TArg1`

The type of the second parameter of the method that this delegate encapsulates\.

<a name='Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).TArg2'></a>

`TArg2`

The type of the third parameter of the method that this delegate encapsulates\.

<a name='Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).TArg3'></a>

`TArg3`

The type of the fourth parameter of the method that this delegate encapsulates\.

<a name='Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).TArg4'></a>

`TArg4`

The type of the fifth parameter of the method that this delegate encapsulates\.
#### Parameters

<a name='Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).obj'></a>

`obj` [T](Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).md#Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).T 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\(T, TArg1, TArg2, TArg3, TArg4\)\.T')

The first parameter of the method that this delegate encapsulates\.

<a name='Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).arg1'></a>

`arg1` [TArg1](Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).md#Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).TArg1 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\(T, TArg1, TArg2, TArg3, TArg4\)\.TArg1')

The second parameter of the method that this delegate encapsulates\.

<a name='Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).arg2'></a>

`arg2` [TArg2](Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).md#Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).TArg2 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\(T, TArg1, TArg2, TArg3, TArg4\)\.TArg2')

The third parameter of the method that this delegate encapsulates\.

<a name='Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).arg3'></a>

`arg3` [TArg3](Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).md#Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).TArg3 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\(T, TArg1, TArg2, TArg3, TArg4\)\.TArg3')

The fourth parameter of the method that this delegate encapsulates\.

<a name='Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).arg4'></a>

`arg4` [TArg4](Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).md#Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).TArg4 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\(T, TArg1, TArg2, TArg3, TArg4\)\.TArg4')

The fifth parameter of the method that this delegate encapsulates\.

#### Returns
[T](Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).md#Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).T 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\(T, TArg1, TArg2, TArg3, TArg4\)\.T')  
The return value of the method that this delegate encapsulates\.
            This is usually \(but not obligatorily\), at least if [T](Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).md#Louis.Fluency.FluentAction_T,TArg1,TArg2,TArg3,TArg4_(T,TArg1,TArg2,TArg3,TArg4).T 'Louis\.Fluency\.FluentAction\<T,TArg1,TArg2,TArg3,TArg4\>\(T, TArg1, TArg2, TArg3, TArg4\)\.T') is a reference type,
            the same reference that was passed as the first parameter to the method\.