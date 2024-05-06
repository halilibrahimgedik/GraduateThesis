using GraduateThesis.Core.Dtos.CategoryDtos;
using GraduateThesis.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduateThesis.API.Controllers
{
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateAction(await _categoryService.GetAllAsync());
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCategoryByIdWithClubs(int id)
        {
            return CreateAction(await _categoryService.GetCategoryByIdWithClubsAsync(id));
        }

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
        public async Task<IActionResult> AddAll(CreateCategoryDto[] dtos)
        {
            return CreateAction(await _categoryService.AddRangeAsync(dtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto dto)
        {
            return CreateAction(await _categoryService.UpdateAsync(dto));
        }

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
