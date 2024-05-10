using GraduateThesis.Core.Dtos.ClubDtos;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using GraduateThesis.Core.Services;
using System.Security.Cryptography.Xml;
using GraduateThesis.Service.Exceptions;

namespace GraduateThesis.API.Filters
{
    public class ValidateCategoryIdsFilter : IAsyncActionFilter
    {
        private readonly ICategoryService _categoryService;

        public ValidateCategoryIdsFilter(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var dto = context.ActionArguments["dto"];


            if (dto is UpdateClubDto updateClubDto)
            {
                await ValidateCategories(updateClubDto.Categories);
            }
            else if (dto is CreateClubWithImageDto createClubDto)
            {
                await ValidateCategories(createClubDto.Categories);
            }
            else
            {
                throw new ArgumentException("Unsupported DTO type");
            }

            await next.Invoke();
            return;
        }
        private async Task ValidateCategories(List<int> categoryIds)
        {
            foreach (var categoryId in categoryIds)
            {
                var exist = await _categoryService.AnyAsync(x => x.Id == categoryId);
                if (!exist.Data)
                {
                    throw new ClientSideException($"Bad Request, there is no category with ID: {categoryId}");
                }
            }
        }
    }
}
