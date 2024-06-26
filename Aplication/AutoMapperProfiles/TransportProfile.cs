﻿using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapperProfiles
{
    public class TransportProfile : Profile
    {
        public TransportProfile()
        {
            CreateMap<Transport, TransportDto>(); // Mapeo de Transport a TransportDto
            CreateMap<TransportDto, Transport>(); // Mapeo inverso de TransportDto a Transport
        }
    }
}
