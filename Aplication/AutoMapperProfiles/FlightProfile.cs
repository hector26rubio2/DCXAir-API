using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapperProfiles
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<Flight, FlightDto>(); // Mapeo de Flight a FlightDto
            CreateMap<FlightDto, Flight>(); // Mapeo inverso de FlightDto a Flight
        }
    }
}
