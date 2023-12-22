using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4.Core.Models;

namespace Week4.Core.Repositories
{
    public interface IPetRepository : IGenericRepository<Pet>
    {
        Task<Pet> GetByPetIdAsync(int petId);
    }
}
