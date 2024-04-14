﻿using Aplication.DTOs;
using Aplication.Exceptions;
using Application.DTOs;
using Domain.Entities;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Validators
{
    public class FlightValidator : AbstractValidator<FlightDto>
    {
        public FlightValidator()
        {
            RuleFor(f => f.Origin).NotEmpty().WithMessage("El origen del vuelo es requerido.")
                   .Length(3).WithMessage("El origen debe tener exactamente tres caracteres.")
                 .Matches("^[A-Z]+$").WithMessage("El origen debe contener solo letras letras mayusculas.");
            RuleFor(f => f.Destination).NotEmpty().WithMessage("El destino del vuelo es requerido.")
                .Length(3).WithMessage("El destino debe tener exactamente tres caracteres.")
                   .Matches("^[A-Z]+$").WithMessage("El origen debe contener solo letras letras mayusculas.");
            RuleFor(f => f.Price).GreaterThan(0).WithMessage("El precio del vuelo debe ser mayor que cero.");
            RuleFor(f => f.Transport).NotNull().WithMessage("Los detalles del transporte son requeridos.");

            RuleFor(f => f.Transport)
                .SetValidator(new TransportValidator());
        }
        public override ValidationResult Validate(ValidationContext<FlightDto> context)
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
