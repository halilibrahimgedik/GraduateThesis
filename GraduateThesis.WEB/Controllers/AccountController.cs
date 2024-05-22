using GraduateThesis.WEB.Models;
using GraduateThesis.WEB.Models.LoginViewModels;
using GraduateThesis.WEB.Models.UserViewModels;
using GraduateThesis.WEB.Services.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace GraduateThesis.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly UniversityApiService _universityApiService;
        private readonly UserApiService _userApiService;
        private readonly AuthorizationApiService _authApiService;
        public AccountController(UniversityApiService universityApiService, UserApiService userApiService, AuthorizationApiService authApiService)
        {
            _universityApiService = universityApiService;
            _userApiService = userApiService;
            _authApiService = authApiService;
        }
        ///Authentication/SignUp
        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            ViewBag.Universities = await GetUniversities();

            var userVm = new CreateUserVm();
            return View(userVm);
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

            if (!result.IsSuccessfull)
            {
                CreateMessage(AlertType.danger, result.Errors);
                ViewBag.Universities = await GetUniversities();
                return View();
            }

            CreateMessage(AlertType.success, new List<string>() { "Hesabınız başarıyla oluşturulmuştur" });

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVm);
            }

            var result = await _authApiService.CreateToken(loginVm);

            if (!result.IsSuccessfull)
            {
                CreateMessage(AlertType.success, new List<string>() { "Hesabınız başarıyla oluşturulmuştur" });
                return View(loginVm);
            }

            HttpContext.Response.Cookies.Append("AccessToken", result.Data.AccessToken);

            HttpContext.Items["AccessToken"] = result.Data; // Token'ı HttpContext.Items içine sakla

            return RedirectToAction("Index", "Clubs");
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
