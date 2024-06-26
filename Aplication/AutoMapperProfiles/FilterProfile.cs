﻿using Application.DTOs;
using AutoMapper;
using Domain.Models;

namespace Application.AutoMapperProfiles
{
    public class FilterProfile : Profile
    {
        public FilterProfile()
        {
            CreateMap<Filter, FilterDto>(); // Mapeo de Flight a FlightDto
            CreateMap<FilterDto, Filter>(); // Mapeo inverso de FlightDto a Flight
        }
    }
}
