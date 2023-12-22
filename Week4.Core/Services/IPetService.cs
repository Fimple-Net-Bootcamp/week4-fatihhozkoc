using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4.Core.DTOs;
using Week4.Core.Models;

namespace Week4.Core.Services
{
    public interface IPetService : IService<Pet>
    {
        public Task<CustomResponseDto<PetWithStatusDto>> GetByPetIdAsync(int petId);
    }
}
