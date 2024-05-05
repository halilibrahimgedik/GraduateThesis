using GraduateThesis.Core.Dtos.ClubDtos;
using GraduateThesis.Core.Services;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> GetClubs()
        {
            var datas = await _clubService.GetAllAsync();

            return CreateAction(datas);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClubDto dto)
        {
            var data = await _clubService.AddAsync(dto);

            return CreateAction(data);
        }

    }
}
