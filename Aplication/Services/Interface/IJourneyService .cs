using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interface
{
    public interface IJourneyService
    {
        Task<List<JourneyDto>> GetAllJourneysAsync();
        Task<JourneyDto> GetJourneyByIdAsync(Guid id);
        Task AddJourneyAsync(JourneyDto journeyDto);
        
    }
}
