using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.AutoMapperProfiles
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
