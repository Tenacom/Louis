#### [Louis](README.md 'README')

## Louis\.Diagnostics Namespace

Provides types to create, inspect, and rethrow exceptions, to identify critical errors,
and to perform self\-checks in library and application code\.

| Classes | |
| :--- | :--- |
| [CriticalInternalErrorException](Louis.Diagnostics.CriticalInternalErrorException.md 'Louis\.Diagnostics\.CriticalInternalErrorException') | The exception that is thrown by methods of the [SelfCheck](Louis.Diagnostics.SelfCheck.md 'Louis\.Diagnostics\.SelfCheck') class to signal an unrecoverable condition, most probably caused by an internal error in a library or application, that should cause an application to terminate immediately\. |
| [ExceptionExtensions](Louis.Diagnostics.ExceptionExtensions.md 'Louis\.Diagnostics\.ExceptionExtensions') | Provides extension methods for exceptions\. |
| [ExceptionHelper](Louis.Diagnostics.ExceptionHelper.md 'Louis\.Diagnostics\.ExceptionHelper') | Provides utility methods to construct exception messages\. |
| [InternalErrorException](Louis.Diagnostics.InternalErrorException.md 'Louis\.Diagnostics\.InternalErrorException') |   The exception that is thrown by methods of the [SelfCheck](Louis.Diagnostics.SelfCheck.md 'Louis\.Diagnostics\.SelfCheck') class             to signal a condition most probably caused by an internal error in a library             or application.  Do not use this class directly; use the methods of the [SelfCheck](Louis.Diagnostics.SelfCheck.md 'Louis\.Diagnostics\.SelfCheck') class instead. |
| [SelfCheck](Louis.Diagnostics.SelfCheck.md 'Louis\.Diagnostics\.SelfCheck') | Provides methods to perform self\-checks in library or application code\. |
| [StringBuilderExtensions](Louis.Diagnostics.StringBuilderExtensions.md 'Louis\.Diagnostics\.StringBuilderExtensions') | Provides extension methods for [System\.Text\.StringBuilder](https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder 'System\.Text\.StringBuilder')\. |

| Interfaces | |
| :--- | :--- |
| [ICriticalError](Louis.Diagnostics.ICriticalError.md 'Louis\.Diagnostics\.ICriticalError') | Identifies an exception as a critical error\. Critical errors indicate an unrecoverable error that should terminate an application immediately; therefore they should never be caught\. |
