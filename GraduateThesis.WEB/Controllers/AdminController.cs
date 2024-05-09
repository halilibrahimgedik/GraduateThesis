using GraduateThesis.WEB.Services.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace GraduateThesis.WEB.Controllers
{
    public class AdminController : Controller
    {
        private readonly ClubApiService _clubApiService;

        public AdminController(ClubApiService clubApiService)
        {
            _clubApiService = clubApiService;
        }

        public async Task<IActionResult> ManageClubs()
        {
            var clubs = await _clubApiService.GetAllAsync();
            return View(clubs);
        }
    }
}
