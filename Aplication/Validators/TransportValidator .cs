using Application.DTOs;
using FluentValidation;

namespace Application.Validators
{
    public class TransportValidator : BaseValidator<TransportDto>
    {
        public TransportValidator()
        {
            RuleFor(t => t.FlightCarrier).NotEmpty().WithMessage("El transportista del vuelo es requerido.");
            RuleFor(t => t.FlightNumber).NotEmpty().WithMessage("El número de vuelo es requerido.");

        }
    }
}
