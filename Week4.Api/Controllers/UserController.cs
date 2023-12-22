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
    public class UserController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<User> _service;

        public UserController(IService<User> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound(CustomResponseDto<GetUserDto>.Fail(404, $"User with id {id} not found."));
            }
            var userDto = _mapper.Map<GetUserDto>(user);
            return CreateActionResult(CustomResponseDto<GetUserDto>.Success(200, userDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(PostUserDto userDto)
        {
            if (userDto == null)
            {
                return BadRequest(CustomResponseDto<PostUserDto>.Fail(400, "User data is null."));
            }
            var user = _mapper.Map<User>(userDto);
            if (user == null)
            {
                return BadRequest(CustomResponseDto<PostUserDto>.Fail(400, "Error in mapping the user data."));
            }
            var createdUser = await _service.AddAsync(user);
            if (createdUser == null)
            {
                return StatusCode(500, CustomResponseDto<PostUserDto>.Fail(500, "Could not create the user."));
            }
            var userDtoResult = _mapper.Map<PostUserDto>(createdUser);
            return CreateActionResult(CustomResponseDto<PostUserDto>.Success(201, userDtoResult));
        }

    }
}
