using GraduateThesis.WEB.Models.ViewModels;
using GraduateThesis.WEB.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace GraduateThesis.WEB.Controllers
{
    public class ClubsController : Controller
    {
        private readonly ClubApiService _clubApiService;
        private const string clubEndPoint = "my.projects.com.tr/api/clubs";

        public ClubsController(ClubApiService clubApiService)
        {
            _clubApiService = clubApiService;
        }

        public async Task<IActionResult> Index()
        {
            List<ClubVm> clubs = await _clubApiService.GetAllAsync();
            return View(clubs);
        }
    }
}
