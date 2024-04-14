using Domain.Enums;

namespace Application.DTOs
{
    public class FilterDto
    {
        public string Origin { get; set; }
        public string Destination { get; set; }

        public CurrencyType CurrencyType { get; set; }
        public string FlightType { get; set; }

    }
}
