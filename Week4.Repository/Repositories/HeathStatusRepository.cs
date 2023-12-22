using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4.Core.Models;
using Week4.Core.Repositories;

namespace Week4.Repository.Repositories
{
    public class HeathStatusRepository :  IHealthStatusRepository
    {
        private readonly AppDbContext _dbContext;

        public HeathStatusRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<HealthStatus> GetByPetIdAsync(int petId)
        {
            return await _dbContext.HealthStatuses
                .Where(h => h.PetId == petId)
                .FirstOrDefaultAsync();
        }

    
    }
}
