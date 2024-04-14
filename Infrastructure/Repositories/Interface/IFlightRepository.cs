using Domain.Entities;
using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interface
{
    public interface IFlightRepository
    {
        Task<List<Flight>> GetFlightsByTypeAsync(Filter filter);

        Task AddRangeAsync(List<Flight> flights);
        Task<List<string>> GetOriginAirportsAsync();
        Task<List<string>> GetDestinationAirportsAsync();
    }
}
