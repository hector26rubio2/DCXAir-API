using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interface
{
    public interface IJourneyRepository
    {
        Task<List<Journey>> GetAllAsync();
        Task<Journey> GetByIdAsync(Guid id);
        Task AddAsync(Journey journey);
    }
}
