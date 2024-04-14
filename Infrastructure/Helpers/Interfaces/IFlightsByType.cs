using Domain.Entities;
using Domain.Models;

namespace Infrastructure.Helpers.Interfaces
{
    public  interface IFlightsByType
    {
        List<Journey> GetOneWayFlights(string origin,string destination, List<Flight> flights);
        List<Journey> GetRoundTripFlights(string origin, string destination, List<Flight> flights);
    }
}
