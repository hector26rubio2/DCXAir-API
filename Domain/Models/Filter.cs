using Domain.Enums;

namespace Domain.Models
{
    public class Filter
    {
        public string Origin { get; set; }
        public string Destination { get; set; }

        public CurrencyType CurrencyType { get; set; }
        public string FlightType { get; set; }
    }
}
