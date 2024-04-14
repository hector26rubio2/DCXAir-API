using Domain.Entities;

namespace Domain.Models
{
    public class Journey 
    {
        public Journey(List<Flight> flights, string origin, string destination,double priceJourney)
        {
            Flights = flights;
            Origin = origin;
            Destination = destination;
            Price = priceJourney;
        }

 
        public string Origin { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }

        public List<Flight> Flights { get; set; }
    }
}
