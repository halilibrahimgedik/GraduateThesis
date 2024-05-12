using GraduateThesis.WEB.Models;
using GraduateThesis.WEB.Models.CategoryViewModels;
using GraduateThesis.WEB.Models.ClubViewModels;
using GraduateThesis.WEB.Services.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;

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
            ModelState.Remove("file");

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

            var response = await _clubApiService.SaveAsync(clubWithImage);

            if (response?.Errors?.Count > 0)
            {
                ViewBag.Categories = await _categoryApiService.GetAllAsync();

                CreateMessage(AlertType.danger, response.Errors);

                return View(model);
            }

            CreateMessage(AlertType.success, new List<string>() { $"{clubWithImage.Name} Adlı Kulüp Başarıyla Eklendi" });

            return RedirectToAction("ManageClubs");
        }

        public async Task<IActionResult> RemoveClub(int id)
        {
            var result = await _clubApiService.RemoveAsync(id);

            if (!result)
            {
                CreateMessage(AlertType.danger, new List<string>() { $"id'si '{id}' olan Kulüp Silinemedi, lütfen daha sonra tekrar deneyiniz" });
                return RedirectToAction("ManageClubs");
            }

            CreateMessage(AlertType.warning, new List<string>() { $"id'si '{id}' olan Kulüp Başarıyla Silinmiştir." });

            return RedirectToAction("ManageClubs");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateClub(int id)
        {
            var club = await _clubApiService.GetByIdAsync(id);

            var updateClubVM = new UpdateClubVM
            {
                Id = club.Id,
                Name = club.Name,
                IsActive = club.IsActive,
                Summary = club.Summary,
                Categories = club.Categories.Select(c => c.Id).ToList(),
                Url = club.Url,
            };

            ViewBag.Categories = await _categoryApiService.GetAllAsync();

            return View(updateClubVM);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateClub(UpdateClubVM model, IFormFile file)
        {
            model.Image = file;

            ModelState.Remove("file");

            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _categoryApiService.GetAllAsync();

                return View(model);
            }

            var response = await _clubApiService.UpdateAsync(model);

            if (response?.Errors?.Count > 0)
            {
                ViewBag.Categories = await _categoryApiService.GetAllAsync();

                CreateMessage(AlertType.danger, response.Errors);

                return View(model);
            }

            CreateMessage(AlertType.warning, new List<string>() { $"{model.Name} Adlı Kulüp Başarıyla Güncellenmiştir." });

            return RedirectToAction(nameof(ManageClubs));
        }





        public async Task<IActionResult> ManageCategories()
        {
            var categories = await _categoryApiService.GetAllAsync();

            return View(categories);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            var category = new CreateCategoryVm();
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var response = await _categoryApiService.AddAsync(model);

            if (response?.Errors?.Count > 0)
            {
                CreateMessage(AlertType.danger, response.Errors);

                return View(model);
            }

            CreateMessage(AlertType.success, new List<string>() {$"{model.Name} adlı kategori başarıyla eklenmiştir."});

            return RedirectToAction(nameof(ManageCategories));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var data = await _categoryApiService.GetByIdAsync(id);

            var category = new UpdateCategoryVm()
            {
                Id = data.Id,
                Name = data.Name,
            };

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryVm model)
        {
            var result = await _categoryApiService.UpdateAsync(model);

            if (result)
            {
                CreateMessage(AlertType.warning, new List<string>() { $"{model.Name} adlı kategori başarıyla güncellenmiştir." });
                return RedirectToAction(nameof(ManageCategories));
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _categoryApiService.RemoveAsync(id);

            CreateMessage(AlertType.warning, new List<string>() { $"id'si {id} olan Kategori Başarıyla Silinmiştir"});

            return RedirectToAction(nameof(ManageCategories));
        }

        private void CreateMessage(AlertType alertType, List<string> messageList)
        {
            var message = new AlertMessage()
            {
                AlertType = alertType,
                MessageList = messageList
            };

            TempData["Message"] = JsonSerializer.Serialize(message);
        }
    }
}
