using GraduateThesis.API.Filters;
using GraduateThesis.Core.Dtos.ClubDtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Dtos.UniversityDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GraduateThesis.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
    public class ClubsController : CustomBaseController
    {
        private readonly IClubService _clubService;

        public ClubsController(IClubService clubService)
        {
            _clubService = clubService;
        }



        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clubs = await _clubService.GetAllAsync();

            return CreateAction(clubs);
        }


        [AllowAnonymous]
        [ServiceFilter(typeof(DoesUniversityExistFilter))]
        [HttpGet("GetClubsByUniversity")]
        public async Task<IActionResult> GetActiveClubsByUniversity(int universityId)
        {
            return CreateAction(await _clubService.GetActiveClubsByUniversityAsync(universityId));
        }


        [AllowAnonymous]
        [ServiceFilter(typeof(DoesUniversityExistFilter))]
        [HttpGet("GetClubsByUniversityWithCategories")]
        public async Task<IActionResult> GetClubsByUniversityWithCategories(int universityId)
        {
            var datas = await _clubService.GetClubsByUniversityWithCategoriesAsync(universityId);

            return CreateAction(datas);
        }


        [AllowAnonymous]
        [ServiceFilter(typeof(NotFoundFilter<Club,ClubDto>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var club = await _clubService.GetClubByIdWithCategoriesAsync(id);
            
            return CreateAction(club);
        }


        [ServiceFilter(typeof(ValidateCategoryIdsFilter))]
        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateClubWithImageDto dto)
        {
            var club = await _clubService.AddAsync(dto);

            return CreateAction(club);
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> AddAll(List<CreateClubDto> dtos)
        {
            return CreateAction(await _clubService.AddRangeAsync(dtos));
        }


        [ServiceFilter(typeof(ValidateCategoryIdsFilter))]
        [HttpPut]
        public async Task<IActionResult> Update([FromForm]UpdateClubDto dto)
        {
            var response = await _clubService.UpdateAsync(dto);

            return CreateAction(response);
        }


        [ServiceFilter(typeof(NotFoundFilter<Club, ClubDto>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            return CreateAction(await _clubService.RemoveAsync(id));
        }


        [HttpDelete("[action]")]
        public async Task<IActionResult> RemoveAll(List<int> ids)
        {
            return CreateAction(await _clubService.RemoveRangeAsync(ids));
        }


        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Any(int id)
        {
            var club = await _clubService.AnyAsync(x=>x.Id == id);

            return CreateAction(club);
        }

    }
}
