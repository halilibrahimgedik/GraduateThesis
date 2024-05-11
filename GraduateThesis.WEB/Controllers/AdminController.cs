using GraduateThesis.WEB.Models.ClubViewModels;
using GraduateThesis.WEB.Services.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GraduateThesis.WEB.Controllers
{
    public class AdminController : Controller
    {
        private readonly ClubApiService _clubApiService;
        private readonly CategoryApiService _categoryApiService;

        public AdminController(ClubApiService clubApiService, CategoryApiService categoryApiService)
        {
            _clubApiService = clubApiService;
            _categoryApiService = categoryApiService;
        }

        public async Task<IActionResult> ManageClubs()
        {
            var clubs = await _clubApiService.GetAllAsync();
            ViewBag.ErrorMessage = TempData["ErrorMessage"];
            return View(clubs);
        }

        [HttpGet]
        public async Task<IActionResult> CreateClub()
        {
            ViewBag.Categories = await _categoryApiService.GetAllAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateClub(CreateClubVm model, IFormFile file)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categoryApiService.GetAllAsync();
                return View(model);
            }

            var clubWithImage = new CreateClubWithImageVm()
            {
                Name = model.Name,
                Summary = model.Summary,
                IsActive = model.IsActive,
                Categories = model.Categories,
                Image = file,
            };

            var response =await _clubApiService.SaveAsync(clubWithImage);

            if(response == null)
            {
                ViewBag.Categories = await _categoryApiService.GetAllAsync();

                ViewData["Errors"] = new List<string>() {"Bir Hata Meydana Geldi, Lütfen Daha Sonra Tekrar Deneyiniz"};

                return View(model);
            }

            if (response?.Errors?.Count > 0)
            {
                ViewBag.Categories = await _categoryApiService.GetAllAsync();

                ViewData["Errors"] = response.Errors;

                return View(model);
            }

            return RedirectToAction("ManageClubs");
        }

        public async Task<IActionResult> RemoveClub(int id)
        {
            var result = await _clubApiService.RemoveAsync(id);

            if (!result)
            {
                TempData["ErrorMessage"] = $"{id}'li Kulüp Silinemedi. Lütfen daha sonra tekrar deneyiniz ..";
                return RedirectToAction("ManageClubs");
            }
            return RedirectToAction("ManageClubs");
        }

        public async Task<IActionResult>
    }
}
