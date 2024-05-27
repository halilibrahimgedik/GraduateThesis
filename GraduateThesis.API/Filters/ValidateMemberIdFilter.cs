using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Dtos.MemberDtos;
using GraduateThesis.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GraduateThesis.API.Filters
{
    public class ValidateMemberIdFilter : IAsyncActionFilter
    {
        private readonly UserManager<AppUser> _userManager;
        public ValidateMemberIdFilter(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments["dto"];

            if (idValue == null)
            {
                await next.Invoke();
                return;
            }

            string userId = null;

            if (idValue is MemberIdDto dto) // pattern Matching kullanarak ile idValue nesnesini dto'ya cast ettik
            {
                userId = dto.UserId;
            }

            //var idValue = context.ActionArguments["userId"];

            //userId = (string)idValue;

            var user = await _userManager.FindByIdAsync(userId);

            if(user != null)
            {
                await next.Invoke();
                return;
            }

            context.Result = new BadRequestObjectResult(
                    CustomResponseDto<NoDataDto>.Fail(StatusCodes.Status404NotFound, " User Not Found !")
                ); 
        }
    }
}
