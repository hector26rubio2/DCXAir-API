using AutoMapper;
using Domain.Entities;
using Application.DTOs;

namespace Application.AutoMapperProfiles
{
    public class JourneyProfile : Profile
    {
        public JourneyProfile()
        {
            CreateMap<Journey, JourneyDto>(); // Mapeo de Journey a JourneyDto
            CreateMap<JourneyDto, Journey>(); // Mapeo inverso de JourneyDto a Journey
        }
    }
}
