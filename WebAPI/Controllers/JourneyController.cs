using Aplication.Exceptions;
using Application.DTOs;
using Application.Services.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JourneyController : ControllerBase
    {
        private readonly IJourneyService _journeyService;

        public JourneyController(IJourneyService journeyService)
        {
            _journeyService = journeyService;
        }

        [HttpPost]
        public async Task<IActionResult> AddJourney(JourneyDto journeyDto)
        {
            try
            {
                await _journeyService.AddJourneyAsync(journeyDto);
                return Ok(new ApiResponse<object>(null, "Journey agregada exitosamente."));
            }
            catch (ValidationException ex)
            {
                var validationErrors = ex.Errors.Select(error => new PropertyValidationError(error.PropertyName, error.ErrorMessage)).ToList();
                var apiResponse = new ApiResponse<List<PropertyValidationError>>(validationErrors, "La validación ha fallado.");
    return BadRequest(apiResponse);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ApiResponse<object>(null, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>(null, $"Error interno del servidor."));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllJourneys()
        {
            try
            {
                var journeys = await _journeyService.GetAllJourneysAsync();
                return Ok(new ApiResponse<IEnumerable<JourneyDto>>(journeys, "Journeys obtenidos exitosamente."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>(null, $"Error interno del servidor."));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetJourneyById(Guid id)
        {
            try
            {
                var journey = await _journeyService.GetJourneyByIdAsync(id);
                return Ok(new ApiResponse<JourneyDto>(journey, "Journey obtenido exitosamente."));
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ApiResponse<object>(null, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<object>(null, $"Error interno del servidor."));
            }
        }
    }
}
