using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.AutoMapperProfiles
{
    public class JourneyProfile : Profile
    {
        public JourneyProfile()
        {
            CreateMap<Journey, JourneyDto>(); // Mapeo de Flight a FlightDto
            CreateMap<JourneyDto, Journey>(); // Mapeo inverso de FlightDto a Flight
        }
    }
}
