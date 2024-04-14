using Application.DTOs;
using Domain.Enums;
using FluentValidation;
namespace Application.Validators
{
    public class FilterDTOValidator : BaseValidator<FilterDto>
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
              .Must(x => x.Equals(FlightType.ROUND_TRIP, StringComparison.OrdinalIgnoreCase) ||
                         x.Equals(FlightType.ONE_WAY, StringComparison.OrdinalIgnoreCase))
              .WithMessage($"El tipo de vuelo debe ser '{FlightType.ROUND_TRIP}' o '{FlightType.ONE_WAY}'.");
        }

    }
}

