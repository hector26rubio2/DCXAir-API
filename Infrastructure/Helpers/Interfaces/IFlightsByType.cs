using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helpers.Interfaces
{
    public  interface IFlightsByType
    {
        List<Journey> GetOneWayFlights(string origin,string destination, List<Flight> flights);
        List<Journey> GetRoundTripFlights(string origin, string destination, List<Flight> flights);
    }
}
