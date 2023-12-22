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
    public class PetRepository : GenericRepository<Pet>, IPetRepository
    {
        public PetRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Pet> GetByPetIdAsync(int petId)
        {
            return await _context.Pets.Include(x => x.Statutes).Where(x => x.Id == petId).SingleOrDefaultAsync();
            //return await _context.HealthStatuses.Where(h => h.PetId == petId).SingleOrDefaultAsync();
        }
    }
}
