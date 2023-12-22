using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week4.Core.DTOs;
using Week4.Core.Models;
using Week4.Core.Services;

namespace Week4.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Pet> _service;
        private readonly IPetService _petService;

        public PetController(IService<Pet> service, IMapper mapper, IPetService petService)
        {
            _service = service;
            _mapper = mapper;
            _petService = petService;
        }


        [HttpGet("[action]/{petId}")]
        public async Task<IActionResult> GetByPetIdAsync(int petId)
        {
            var result = await _petService.GetByPetIdAsync(petId);

            // result null ise uygun bir hata mesajı döndür.
            if (result == null || result.Data == null)
            {
                return NotFound(new { Message = $"Pet with ID {petId} not found or no data availableeeeee." });
            }

            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> All()
        {
            var pets = await _service.GetAllAsync();
            if (pets == null || !pets.Any())
            {
                return NotFound(CustomResponseDto<List<GetPetDto>>.Fail(404, "No pets found."));
            }
            var petDtos = _mapper.Map<List<GetPetDto>>(pets.ToList());
            return CreateActionResult(CustomResponseDto<List<GetPetDto>>.Success(200, petDtos));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pet = await _service.GetByIdAsync(id);
            if (pet == null)
            {
                return NotFound(CustomResponseDto<GetPetDto>.Fail(404, $"Pet with id {id} not found."));
            }
            var petDto = _mapper.Map<GetPetDto>(pet);
            return CreateActionResult(CustomResponseDto<GetPetDto>.Success(200, petDto));
        }



        [HttpPost]
        public async Task<IActionResult> Save(PostPetDto petDto)
        {
            if (petDto == null)
            {
                return BadRequest(CustomResponseDto<PostPetDto>.Fail(400, "Pet data is null."));
            }
            var pet = _mapper.Map<Pet>(petDto);
            if (pet == null)
            {
                return BadRequest(CustomResponseDto<PostPetDto>.Fail(400, "Error in mapping the pet data."));
            }
            var createdPet = await _service.AddAsync(pet);
            if (createdPet == null)
            {
                return StatusCode(500, CustomResponseDto<PostPetDto>.Fail(500, "Could not create the pet."));
            }
            var petDtoResult = _mapper.Map<PostPetDto>(createdPet);
            return CreateActionResult(CustomResponseDto<PostPetDto>.Success(201, petDtoResult));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GetPetDto petDto)
        {
            var pet = await _service.GetByIdAsync(id);
            if (pet == null)
            {
                return NotFound(CustomResponseDto<NoContentDto>.Fail(404, "Pet not found."));
            }

            _mapper.Map(petDto, pet);
            await _service.UpdateAsync(pet);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
