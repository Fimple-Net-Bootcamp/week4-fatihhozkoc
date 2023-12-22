using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week4.Core.DTOs;
using Week4.Core.Models;
using Week4.Core.Services;
using Week4.Repository;

namespace Week4.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : CustomBaseController
    {

        private readonly IMapper _mapper;
        private readonly IService<Activities> _service;

        public ActivitiesController(IService<Activities> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Save(PostActivitiesDto paDto)
        {
            if (paDto == null)
            {
                return BadRequest(CustomResponseDto<PostActivitiesDto>.Fail(400, "User data is null."));
            }
            var activity = _mapper.Map<Activities>(paDto);
            if (activity == null)
            { 
                return BadRequest(CustomResponseDto<PostActivitiesDto>.Fail(400, "Error in mapping the user data."));
            }
            var createdActivity = await _service.AddAsync(activity);
            if (createdActivity == null)
            {
                return StatusCode(500, CustomResponseDto<PostActivitiesDto>.Fail(500, "Could not create the user."));
            }
            var activityDtoResult = _mapper.Map<PostActivitiesDto>(createdActivity);
            return CreateActionResult(CustomResponseDto<PostActivitiesDto>.Success(201, activityDtoResult));
        }
    }
}
