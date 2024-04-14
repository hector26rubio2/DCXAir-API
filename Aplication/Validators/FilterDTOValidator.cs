using Aplication.DTOs;
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
    public class FilterDTOValidator : AbstractValidator<FilterDto>
    {
        public FilterDTOValidator()
        {
            RuleFor(x => x.Origin)
                .NotEmpty().WithMessage("El origen es obligatorio.")
                .Length(3).WithMessage("El origen debe tener exactamente tres caracteres.")
                .Matches("^[A-Z]+$").WithMessage("El origen debe contener solo letras letras mayusculas.");

            RuleFor(x => x.Destination)
                .NotEmpty().WithMessage("El destino es obligatorio.")
                .Length(3).WithMessage("El destino debe tener exactamente tres caracteres.")
                .Matches("^[A-Z]+$").WithMessage("El destino debe contener solo letras mayusculas.");

            RuleFor(x => x.CurrencyType)
                .IsInEnum().WithMessage("El tipo de moneda no es válido.");
            RuleFor(x => x.FlightType)
              .Must(x => x.Equals("roundtrip", StringComparison.OrdinalIgnoreCase) ||
                         x.Equals("oneway", StringComparison.OrdinalIgnoreCase))
              .WithMessage("El tipo de vuelo debe ser 'roundtrip' o 'oneway'.");
        }

        public override ValidationResult Validate(ValidationContext<FilterDto> context)
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

