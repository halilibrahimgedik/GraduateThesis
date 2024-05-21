using GraduateThesis.WEB.Models;
using GraduateThesis.WEB.Models.AuthViewModels;
using GraduateThesis.WEB.Models.UserViewModels;
using GraduateThesis.WEB.Services.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace GraduateThesis.WEB.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UniversityApiService _universityApiService;
        private readonly UserApiService _userApiService;
        public AuthenticationController(UniversityApiService universityApiService, UserApiService userApiService)
        {
            _universityApiService = universityApiService;
            _userApiService = userApiService;
        }
        ///Authentication/SignUp
        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            ViewBag.Universities = await GetUniversities();

            var a = new CreateUserVm();
            return View(a);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(CreateUserVm model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Universities = await GetUniversities();
                return View(model);
            }

            var result = await _userApiService.CreateUserAsync(model);

            if (result != null && result.Errors.Any())
            {
                CreateMessage(AlertType.danger, result.Errors);
                ViewBag.Universities = await GetUniversities();
                return View();
            }

            CreateMessage(AlertType.success, new List<string>() { "Hesabınız başarıyla oluşturulmuştur" });

            return View();
        }




        private async Task<SelectList> GetUniversities()
        {
            var universities = await _universityApiService.GetAllAsync();

            return new SelectList(universities, "Id", "UniversityName");
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
