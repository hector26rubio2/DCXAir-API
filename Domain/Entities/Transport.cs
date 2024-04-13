using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Transport : IEntityWithId
    {
        public Guid Id { get; set; }
        public string? FlightCarrier { get; set; }
        public string? FlightNumber { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }

    }
}
