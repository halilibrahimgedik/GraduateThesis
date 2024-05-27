using GraduateThesis.Core.Dtos.AnnouncementDtos;
using GraduateThesis.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduateThesis.API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer",Roles = "admin,club-president")]
    [Route("api/[controller]")]
    public class AnnouncementController : CustomBaseController
    {

        private readonly IAnnouncementService _announcementService;
        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAnnouncements() 
        { 
            return CreateAction(await _announcementService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return CreateAction(await _announcementService.GetByIdAsync(id));
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAnnouncement(int id)
        {
            return CreateAction(await _announcementService.RemoveAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddAnnouncement(CreateAnnouncementDto dto)
        {
            return CreateAction(await _announcementService.AddAsync(dto));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAnnouncement(UpdateAnnouncementDto dto)
        {
            return CreateAction(await _announcementService.UpdateAsync(dto));
        }
    }
}
