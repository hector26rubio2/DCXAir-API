using Aplication.Exceptions;
using Application.DTOs;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Validators
{
    public class JourneyValidator : AbstractValidator<JourneyDto>
    {
        public JourneyValidator()
        {
            RuleFor(j => j.Origin).NotEmpty().WithMessage("El origen es obligatorio.");
            RuleFor(j => j.Destination).NotEmpty().WithMessage("El destino es obligatorio.");
            RuleFor(j => j.Price).GreaterThan(0).WithMessage("El precio debe ser mayor que cero.");
        }
        public override ValidationResult Validate(ValidationContext<JourneyDto> context)
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
