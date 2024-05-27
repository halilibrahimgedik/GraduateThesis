using GraduateThesis.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GraduateThesis.API.Controllers
{
    [Route("api/announcements")]
    [ApiController]
    public class AnnouncementController : CustomBaseController
    {

        private readonly AnnouncementService _announcementService;
        public AnnouncementController(AnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }



    }
}
