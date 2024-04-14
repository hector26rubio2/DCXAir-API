using Domain.Entities;
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Implementation
{
    public class FlightRepository : IFlightRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<FlightRepository> _logger;
        public FlightRepository(ApplicationDbContext context, ILogger<FlightRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

       


        

        public async Task<List<Flight>> GetFlightsByTypeAsync(Filter filter)
        {
            try
            {
                // Implementación para obtener vuelos por tipo (ida o ida y vuelta)
                _logger.LogInformation("Obteniendo vuelos por tipo {FlightType}...", filter);
                // Lógica para filtrar vuelos por tipo desde la fuente de datos
                return new List<Flight>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener vuelos por tipo {FlightType}.", filter);
                throw;
            }
        }

        public async Task AddRangeAsync(List<Flight> flights)
        {
            try
            {
                _logger.LogInformation("Agregando una lista de vuelos a la base de datos...");

                foreach (var flight in flights)
                {
                    // Verificar si el transporte asociado ya existe en la base de datos
                    var existingTransport = await _context.Transports.FirstOrDefaultAsync(t =>
                        t.FlightCarrier == flight.Transport.FlightCarrier &&
                        t.FlightNumber == flight.Transport.FlightNumber);

                    if (existingTransport == null)
                    {
                        _context.Transports.Add(flight.Transport);
                    }
                    else
                    {
                        flight.TransportId = existingTransport.Id;
                    }

                    var existingFlight = await _context.Flights.FirstOrDefaultAsync(f =>
                        f.Origin == flight.Origin &&
                        f.Destination == flight.Destination &&
                        f.Price == flight.Price &&
                        f.TransportId == flight.TransportId);

                    if (existingFlight == null)
                    {
                        // Si el vuelo no existe, agregarlo a la base de datos
                        _context.Flights.Add(flight);
                    }
                    else
                    {
                        _logger.LogInformation("El vuelo ya existe en la base de datos y no se agregará nuevamente.");
                    }
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar una lista de vuelos a la base de datos.");
                throw;
            }
        }

        public async Task<List<string>> GetOriginAirportsAsync()
        {
            try
            {
                _logger.LogInformation("Obteniendo nombres de aeropuertos de origen...");
                return await _context.Flights.Select(f => f.Origin).Distinct().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener nombres de aeropuertos de origen.");
                throw;
            }
        }

        public async Task<List<string>> GetDestinationAirportsAsync()
        {
            try
            {
                _logger.LogInformation("Obteniendo nombres de aeropuertos de destino...");
                return await _context.Flights.Select(f => f.Destination).Distinct().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener nombres de aeropuertos de destino.");
                throw;
            }
        }
    }
}
