using Application.Exceptions;
using FluentValidation;
using FluentValidation.Results;


namespace Application.Validators
{
    public class BaseValidator<T>: AbstractValidator<T>
    {

        public override ValidationResult Validate(ValidationContext<T> context)
        {
            var validationResult = base.Validate(context);
            if (!validationResult.IsValid)
            {
                throw new ApplicationValidationException(validationResult.Errors);
            }
            return validationResult;
        }
    }
}
