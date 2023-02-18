---
tags:
- CSharp
- C#
- Entity Framework
date: 2023-06-21
---

# Entity Framework EntityValidation

{Content}

<!--
## User
Yaharo Bing, do you what was causing this error? maybe you can list out some things that might be the possible root cause for this error. here is the error message:
System.Data.Entity.Validation.DbEntityValidationException: Validation failed for one or more entities. See 'EntityValidationErrors' property for more details.
   at System.Data.Entity.Internal.InternalContext.SaveChanges()
## Bing
The error message you provided is a System.Data.Entity.Validation.DbEntityValidationException which occurs when the validation of one or more entities fails during SaveChanges(). This exception message is quite clear in its intent: Something isn’t valid and if you want to find out what that is then you should attach a debugger and inspect the exception.
You can try to see the details hidden within the DbEntityValidationException by inspecting the EntityValidationErrors property for more details.
## User
what is the best way to inspect EntityValidationErrors?
## Bing
One way to inspect the EntityValidationErrors property is by using a try-catch block and catching the DbEntityValidationException. You can then iterate through the validation errors to see the error messages. Here's an example:

[csharp]
catch (DbEntityValidationException ex)
{
    foreach (var errors in ex.EntityValidationErrors)
    {
        foreach (var validationError in errors.ValidationErrors)
        {
            // get the error message
            string errorMessage = validationError.ErrorMessage;
        }
    }
}
Another way to check for validation errors is by setting a breakpoint in your controller and checking which values have errors against them by looking in the ModelState. The ModelState.Values collection contains the error and the key is the field.

-->
