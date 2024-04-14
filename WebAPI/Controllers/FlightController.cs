using Application.DTOs;
using Application.Services.Interface;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Helpers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

      

        [HttpPost("batch")]
        public async Task<IActionResult> AddFlights([FromBody] List<FlightDto> flights)
        {
            try
            {
                await _flightService.AddFlightsAsync(flights);
                return Ok(new ApiResponse<object>(null, "Flights added successfully."));
            }
            catch (ValidationException ex)
            {
                var validationErrors = ex.Errors.Select(error => new PropertyValidationError(error.PropertyName, error.ErrorMessage)).ToList();
                var apiResponse = new ApiResponse<List<PropertyValidationError>>(validationErrors, "La validación ha fallado.");
                return BadRequest(apiResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(null, $"An error occurred: {ex.Message}"));
            }
        }

        [HttpGet("origin-airports")]
        public async Task<IActionResult> GetOriginAirports()
        {
            try
            {
                var originAirports = await _flightService.GetOriginAirportsAsync();
                return Ok(new ApiResponse<List<string>>(originAirports, "Origin airports retrieved successfully."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(null, $"An error occurred: {ex.Message}"));
            }
        }

        [HttpGet("destination-airports")]
        public async Task<IActionResult> GetDestinationAirports()
        {
            try
            {
                var destinationAirports = await _flightService.GetDestinationAirportsAsync();
                return Ok(new ApiResponse<List<string>>(destinationAirports, "Destination airports retrieved successfully."));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(null, $"An error occurred: {ex.Message}"));
            }
        }

        [HttpPost("by-filter")]
        public async Task<IActionResult> GetFlightsByType(FilterDto type)
        {
            try
            {
                var journeys = await _flightService.GetFlightsByTypeAsync(type);
                return Ok(new ApiResponse<List<JourneyDto>>(journeys, "Flights retrieved successfully."));
            }
            catch (ValidationException ex)
            {
                var validationErrors = ex.Errors.Select(error => new PropertyValidationError(error.PropertyName, error.ErrorMessage)).ToList();
                var apiResponse = new ApiResponse<List<PropertyValidationError>>(validationErrors, "La validación ha fallado.");
                return BadRequest(apiResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<string>(null, $"An error occurred: {ex.Message}"));
            }
        }
    }
}
