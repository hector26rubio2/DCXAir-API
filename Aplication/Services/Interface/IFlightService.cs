
using Application.DTOs;
using Application.DTOs;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
