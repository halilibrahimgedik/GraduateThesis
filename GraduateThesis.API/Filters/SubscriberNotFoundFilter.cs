using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GraduateThesis.API.Filters
{
    public class SubscriberNotFoundFilter : IAsyncActionFilter
    {
        private readonly UserManager<AppUser> _userManager;
        public SubscriberNotFoundFilter(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments["userId"];

            if(idValue == null)
            {
                await next.Invoke();
                return;
            }

            var userId = (string)idValue;

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
