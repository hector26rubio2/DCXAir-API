using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
