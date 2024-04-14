
using Application.DTOs;

namespace Application.Services.Interface
{
    public interface IFlightService
    {
        Task AddFlightsAsync(List<FlightDto> flights);
        Task<List<string>> GetOriginAirportsAsync();
        Task<List<string>> GetDestinationAirportsAsync();
        Task<List<JourneyDto>> GetFlightsByTypeAsync(FilterDto filter);
    }
}
