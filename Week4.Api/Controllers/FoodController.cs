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
    public class FoodController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Foods> _service;

        public FoodController(IMapper mapper, IService<Foods> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var foods = await _service.GetAllAsync();
            var foodDtos = _mapper.Map<List<GetFoodDto>>(foods.ToList());
            return CreateActionResult(CustomResponseDto<List<GetFoodDto>>.Success(200, foodDtos));
        }


        [HttpPost("{petId}")]
        public async Task<IActionResult> Save(int petId, PostFoodDto foodDto)
        {
            if (foodDto == null)
            {
                return BadRequest(CustomResponseDto<PostFoodDto>.Fail(400, "Food data is null."));
            }

            // petId değerini DTO'ya ekleyin veya DTO içinde zaten varsa bu adımı atlayın
            foodDto.PetId = petId;

            var food = _mapper.Map<Foods>(foodDto);
            if (food == null)
            {
                return BadRequest(CustomResponseDto<PostFoodDto>.Fail(400, "Error in mapping the food data."));
            }

            var createdFood = await _service.AddAsync(food);
            if (createdFood == null)
            {
                return StatusCode(500, CustomResponseDto<PostFoodDto>.Fail(500, "Could not create the food record."));
            }

            var foodDtoResult = _mapper.Map<PostFoodDto>(createdFood);
            return CreateActionResult(CustomResponseDto<PostFoodDto>.Success(201, foodDtoResult));
        }
    }
}
