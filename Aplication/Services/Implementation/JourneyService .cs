using Aplication.Exceptions;
using Aplication.Validators;
using Application.DTOs;
using Application.Services.Interface;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using Infrastructure.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implementation
{
    public class JourneyService : IJourneyService
    {
        private readonly IJourneyRepository _journeyRepository;
        private readonly IMapper _mapper;
        private readonly JourneyValidator _journeyValidator;

        public JourneyService(IJourneyRepository journeyRepository, IMapper mapper, JourneyValidator journeyValidator)
        {
            _journeyRepository = journeyRepository;
            _mapper = mapper;
            _journeyValidator = journeyValidator;
        }
        public async Task AddJourneyAsync(JourneyDto journeyDto)
        {
            try
            {
                // Validar el DTO utilizando FluentValidation
                _journeyValidator.ValidateAndThrow(journeyDto);

                // Mapear el DTO a la entidad y guardar en el repositorio
                var journeyEntity = _mapper.Map<Journey>(journeyDto);
                await _journeyRepository.AddAsync(journeyEntity);
            }
            catch (ValidationException ex)
            {
                // Manejar la excepción de validación lanzada por FluentValidation
                throw new ValidationException(ex.Errors);
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones
                Console.WriteLine($"Error al agregar Journey: {ex.Message}");
                throw;
            }
        
    }


        public async Task<List<JourneyDto>> GetAllJourneysAsync()
        {
            try
            {
                var journeys = await _journeyRepository.GetAllAsync();
                return _mapper.Map<List<JourneyDto>>(journeys);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener todas las Journey: {ex.Message}");
                throw;
            }
        }

        public async Task<JourneyDto> GetJourneyByIdAsync(Guid id)
        {
            try
            {
                var journey = await _journeyRepository.GetByIdAsync(id);
                if (journey == null)
                {
                    throw new NotFoundException($"No Journey found with ID {id}");
                }
                return _mapper.Map<JourneyDto>(journey);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener Journey por ID: {ex.Message}");
                throw;
            }
        }
    }
}
