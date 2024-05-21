using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Dtos.UniversityDtos;
using GraduateThesis.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GraduateThesis.API.Filters
{
    public class DoesUniversityExistFilter : IAsyncActionFilter
    {
        private readonly IUniversityService _universityService;

        public DoesUniversityExistFilter(IUniversityService universityService)
        {
            _universityService = universityService;
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var universityId = context.ActionArguments["universityId"];

            if (universityId == null)
            {
                await next.Invoke();
                return;
            }

            var uniId = (int)universityId;

            var doesUniExist = await _universityService.AnyAsync(u => u.Id == uniId);

            if (doesUniExist.Data)
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(
                    CustomResponseDto<UniversityDto>.Fail(StatusCodes.Status404NotFound, "University not found by filter !")
                );
        }
    }
}
