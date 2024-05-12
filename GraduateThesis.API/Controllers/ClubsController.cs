﻿using GraduateThesis.API.Filters;
using GraduateThesis.Core.Dtos.ClubDtos;
using GraduateThesis.Core.Dtos.CustomResponseDtos;
using GraduateThesis.Core.Models;
using GraduateThesis.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace GraduateThesis.API.Controllers
{
    public class ClubsController : CustomBaseController
    {
        private readonly IClubService _clubService;

        public ClubsController(IClubService clubService)
        {
            _clubService = clubService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clubs = await _clubService.GetAllAsync();

            return CreateAction(clubs);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllActiveClubs()
        {
            return CreateAction(await _clubService.GetAllActiveClubsAsync());
        }

        [HttpGet("GetClubsWithCategories")]
        public async Task<IActionResult> GetClubsWithCategories()
        {
            var datas = await _clubService.GetClubsWithCategoriesAsync();

            return CreateAction(datas);
        }

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
            var response= await _clubService.RemoveAsync(id);

            return CreateAction(response);
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
