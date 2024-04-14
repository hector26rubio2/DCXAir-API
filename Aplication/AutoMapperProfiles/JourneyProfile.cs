using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
