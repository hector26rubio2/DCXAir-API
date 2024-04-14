using Domain.Entities;
using Domain.Models;

namespace Infrastructure.Repositories.Interface
{
    public interface IFlightRepository
    {
        Task<List<Journey>> GetFlightsByTypeAsync(Filter filter);

        Task AddRangeAsync(List<Flight> flights);
        Task<List<string>> GetOriginAirportsAsync();
        Task<List<string>> GetDestinationAirportsAsync();
    }
}
