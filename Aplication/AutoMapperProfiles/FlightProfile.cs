using Application.DTOs;
using AutoMapper;
using Domain.Entities;

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
