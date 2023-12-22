using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week4.Core.DTOs;

namespace Week4.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction] 
        public IActionResult CreateActionResult<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 204)
            {
                return new ObjectResult(null)
                {
                    StatusCode = response.StatusCode,
                };
            }
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode,
            };
        }
    }
}
