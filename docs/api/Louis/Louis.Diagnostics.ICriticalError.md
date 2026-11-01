#### [Louis](README.md 'README')
### [Louis\.Diagnostics](Louis.Diagnostics.md 'Louis\.Diagnostics')

## ICriticalError Interface

Identifies an exception as a critical error\. Critical errors indicate an unrecoverable error
that should terminate an application immediately; therefore they should never be caught\.

```csharp
public interface ICriticalError
```

Derived  
↳ [CriticalInternalErrorException](Louis.Diagnostics.CriticalInternalErrorException.md 'Louis\.Diagnostics\.CriticalInternalErrorException')

### Remarks

Exceptions implementing this interface will be recognized as critical errors
            by the [IsCriticalError\(this Exception\)](Louis.Diagnostics.ExceptionExtensions.md#Louis.Diagnostics.ExceptionExtensions.IsCriticalError(thisSystem.Exception) 'Louis\.Diagnostics\.ExceptionExtensions\.IsCriticalError\(this System\.Exception\)') method.

While using an empty interface as a marker
            [is usually considered bad practice](https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1040#rule-description 'https://docs\.microsoft\.com/en\-us/dotnet/fundamentals/code\-analysis/quality\-rules/ca1040\#rule\-description'),
            in this case it is the best alternative, because:
- an attribute to mark exception classes as critical would make checking a lot more expensive,
              as the type of every exception (and of its causing exceptions) should be checked for the presence of the attribute;
- a `CriticalException` base class would be straightforward to check for, but would make it hard
              (if at all possible) to mark exceptions in existing code bases as critical, as they could be part of existing class hierarchies
              that have to be preserved.