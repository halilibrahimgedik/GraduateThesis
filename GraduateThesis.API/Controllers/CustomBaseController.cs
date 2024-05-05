using GraduateThesis.Core.Dtos.CustomResponseDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduateThesis.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        
        public IActionResult CreateAction<T>(CustomResponseDto<T> response)
        {
            if (response.StatusCode == 204)
            {
                return new ObjectResult(null) { StatusCode = response.StatusCode };
            }

            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
