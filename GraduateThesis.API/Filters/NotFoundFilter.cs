using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace GraduateThesis.API.Filters
{
    public class NotFoundFilter<T,Dto> : IAsyncActionFilter where T : BaseEntity where Dto : class
    {
        private readonly IGenericService<T,Dto> _service;
        public NotFoundFilter(IGenericService<T,Dto> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments["id"];

            if(idValue == null )
            {
               await next.Invoke();
                return;
            }

            var id = (int)idValue;

            var entityExist = await _service.AnyAsync(x=>x.Id == id);

            if (entityExist.Data)
            {
                await next.Invoke();
                return;
            }


            context.Result = new NotFoundObjectResult
                (
                    CustomResponseDto<Dto>.Fail((int)HttpStatusCode.NotFound,$"{typeof(T).Name} - {id} not found")
                );
        }
    }
}
