using GoodReadsClone.Application.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace GoodReadsClone.Application.Attributes;
public class ReputableEmailAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var email = value as string;

        var service = validationContext.GetService(typeof(IEmailService)) as IEmailService;

        if (service!.IsRisky(email!).GetAwaiter().GetResult())
            return new ValidationResult(GetErrorMessage());

        return ValidationResult.Success;
    }

    public static string GetErrorMessage() => "Email in not valid";
}
