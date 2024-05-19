using GraduateThesis.API.Filters;
using GraduateThesis.Core.Dtos.CategoryDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduateThesis.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateAction(await _categoryService.GetAllAsync());
        }


        [AllowAnonymous]
        [ServiceFilter(typeof(NotFoundFilter<Category, CategoryDto>))]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCategoryByIdWithClubs(int id)
        {
            return CreateAction(await _categoryService.GetCategoryByIdWithClubsAsync(id));
        }

        [AllowAnonymous]
        [ServiceFilter(typeof(NotFoundFilter<Category,CategoryDto >))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateAction(await _categoryService.GetByIdAsync(id));
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateCategoryDto dto)
        {
            return CreateAction(await _categoryService.AddAsync(dto));
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddAll(List<CreateCategoryDto> dtos)
        {
            return CreateAction(await _categoryService.AddRangeAsync(dtos));
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto dto)
        {
            return CreateAction(await _categoryService.UpdateAsync(dto));
        }


        [ServiceFilter(typeof(NotFoundFilter<Category, CategoryDto>))]
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateAction(await _categoryService.RemoveAsync(id));
        }


        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveAll(List<int> ids)
        {
            return CreateAction(await _categoryService.RemoveRangeAsync(ids));
        }


        [HttpGet("[Action]/{id}")]
        public async Task<IActionResult> Any(int id)
        {
            return CreateAction(await _categoryService.AnyAsync(c=>c.Id == id));
        }
    }
}
