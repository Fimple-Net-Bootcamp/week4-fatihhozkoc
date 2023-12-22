using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week4.Core.DTOs;
using Week4.Core.Models;
using Week4.Core.Repositories;
using Week4.Core.Services;
using Week4.Core.UnitOfWorks;

namespace Week4.Service.Services
{
    public class PetService : Service<Pet>, IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public PetService(IGenericRepository<Pet> repository, IUnitOfWork unitOfWork, IPetRepository petRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<PetWithStatusDto>> GetByPetIdAsync(int petId)
        {
            try
            {
                var pet = await _petRepository.GetByPetIdAsync(petId);

                if (pet == null)
                {
                    return CustomResponseDto<PetWithStatusDto>.Fail(404, $"No pet found for ID {petId}.");
                }

                var petWithStatusDto = _mapper.Map<PetWithStatusDto>(pet);

                if (petWithStatusDto == null)
                {
                    // Log the issue here for debugging
                    return CustomResponseDto<PetWithStatusDto>.Fail(500, "Mapping failed.");
                }

                return CustomResponseDto<PetWithStatusDto>.Success(200, petWithStatusDto);
            }
            catch (Exception ex)
            {
                // Log the exception details here
                return CustomResponseDto<PetWithStatusDto>.Fail(500, $"An error occurred: {ex.Message}");
            }
        }




    }
}
