using Domain.Entities;
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
    public class JourneyRepository : IJourneyRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<JourneyRepository> _logger; // Agrega el logger

        public JourneyRepository(ApplicationDbContext context, ILogger<JourneyRepository> logger)
        {
            _context = context;
            _logger = logger; // Inyecta el logger en el constructor
        }

        public async Task<List<Journey>> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Obteniendo todas las Journeys...");
                return await _context.Journeys
                .Include(j => j.Flights)
                .ThenInclude(f => f.Transport)
                .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todas las Journeys.");
                throw; // Re-lanza la excepción para que el llamador pueda manejarla
            }
        }

        public async Task<Journey> GetByIdAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Obteniendo la Journey con ID {JourneyId}...", id);
                var journey = await _context.Journeys
       .Include(j => j.Flights)
       .ThenInclude(f => f.Transport)
       .FirstOrDefaultAsync(j => j.Id == id);
                return journey;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la Journey con ID {JourneyId}.", id);
                throw; // Re-lanza la excepción para que el llamador pueda manejarla
            }
        }

        public async Task AddAsync(Journey journey)
        {
            try
            {
                _logger.LogInformation("Agregando una nueva Journey...");
                // Agregar la Journey al contexto
                _context.Journeys.Add(journey);

                // Verificar y agregar los vuelos
                foreach (var flight in journey.Flights)
                {
                    // Verificar si el vuelo ya existe en el contexto
                    var existingFlight = await _context.Flights
                        .FirstOrDefaultAsync(f => f.Origin == flight.Origin && f.Destination == flight.Destination && f.Price == flight.Price);

                    if (existingFlight != null)
                    {
                        // Si el vuelo ya existe, asignar su ID a la Journey y continuar
                        flight.Id = existingFlight.Id;
                    }
                    else
                    {
                        // Verificar si el transporte asociado al vuelo ya existe en el contexto
                        var existingTransport = await _context.Transports
                            .FirstOrDefaultAsync(t => t.FlightCarrier == flight.Transport.FlightCarrier && t.FlightNumber == flight.Transport.FlightNumber);

                        if (existingTransport == null)
                        {
                            // Si el transporte no existe, agregarlo al contexto
                            _context.Transports.Add(flight.Transport);
                        }
                        else
                        {
                            // Si el transporte ya existe, asignar su ID al vuelo
                            flight.TransportId = existingTransport.Id;
                        }

                        // Agregar el vuelo al contexto
                        _context.Flights.Add(flight);
                    }
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al agregar una nueva Journey.");
                throw; // Re-lanza la excepción para que el llamador pueda manejarla
            }
        }

    }
}
