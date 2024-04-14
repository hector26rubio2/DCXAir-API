using Application.Exceptions;
using Application.DTOs;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
