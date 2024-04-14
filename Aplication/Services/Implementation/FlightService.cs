
using Aplication.DTOs;
using Aplication.Services.Interface;
using Aplication.Validators;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Models;
using FluentValidation;
using Infrastructure.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.Implementation
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly IMapper _mapper;
  

        private readonly FilterDTOValidator _filterValidator;

        public FlightService(IFlightRepository flightRepository, IMapper mapper, FilterDTOValidator filterValidator)
        {
            _flightRepository = flightRepository;
            _mapper = mapper;
            _filterValidator = filterValidator;
            }

            public async Task AddFlightsAsync(List<FlightDto> flightDtos)
        {
            var fightValidator = new FlightValidator();
            var transportValidator = new TransportValidator();

            foreach (var flightDto in flightDtos)
            {
               

                var validationResult = await fightValidator.ValidateAsync(flightDto);

            
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }


                var validationResultTransport = await transportValidator.ValidateAsync(flightDto.Transport);

                if (!validationResultTransport.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }

            }

            var flights = _mapper.Map<List<Flight>>(flightDtos);
            await _flightRepository.AddRangeAsync(flights);
        }

        public async Task<List<string>> GetOriginAirportsAsync()
        {
            return await _flightRepository.GetOriginAirportsAsync();
        }

        public async Task<List<string>> GetDestinationAirportsAsync()
        {
            return await _flightRepository.GetDestinationAirportsAsync();
        }

        public async Task<List<FlightDto>> GetFlightsByTypeAsync(FilterDto filterDto)
        {
                var validationResult = await _filterValidator.ValidateAsync(filterDto);
                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }

                var filter = _mapper.Map<Filter>(filterDto);
                var flights = await _flightRepository.GetFlightsByTypeAsync(filter);
                return _mapper.Map<List<FlightDto>>(flights);
            }
    }
}
