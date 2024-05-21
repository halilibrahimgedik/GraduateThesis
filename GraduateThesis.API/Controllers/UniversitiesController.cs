using GraduateThesis.API.Filters;
using GraduateThesis.Core.Dtos.UniversityDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduateThesis.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
    public class UniversitiesController : CustomBaseController
    {
        private readonly IUniversityService _universityService;

        public UniversitiesController(IUniversityService universityService)
        {
            _universityService = universityService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateAction(await _universityService.GetAllAsync());
        }

        [AllowAnonymous]
        [ServiceFilter(typeof(NotFoundFilter<University, UniversityDto>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateAction(await _universityService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateUniversityDto dto)
        {
            return CreateAction(await _universityService.AddAsync(dto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateUniversityDto dto)
        {
            return CreateAction(await _universityService.UpdateAsync(dto));
        }

        [ServiceFilter(typeof(NotFoundFilter<University, UniversityDto>))]
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateAction(await _universityService.RemoveAsync(id));
        }
    }
}
