using GraduateThesis.Core.Dtos.UniversityDtos;
using GraduateThesis.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduateThesis.API.Controllers
{
    public class UniversitiesController : CustomBaseController
    {
        private readonly IUniversityService _universityService;

        public UniversitiesController(IUniversityService universityService)
        {
            _universityService = universityService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return CreateAction(await _universityService.GetAllAsync());
        }

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

        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateAction(await _universityService.RemoveAsync(id));
        }
    }
}
