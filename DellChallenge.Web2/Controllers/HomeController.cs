using System;
using System.Threading.Tasks;
using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.EnititiesViewModel;
using DellChallenge.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DellChallenge.Web2.Controllers
{
    public class HomeController : BaseController
    {
        private AuthenticationService _authenticationService;

        public IActionResult Index()
        {
            return View();
        }
  
        public async Task<IActionResult> SignOut()
        {
            await RemoveUser();
            return Redirect("Index");
        }

        public HomeController(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            return View("Index");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string email, string password)
        {
            try
            {
                var userAuthenticated = _authenticationService.Login(new UserLoginViewModel(email, password));

                if (userAuthenticated != null)
                {
                    await RegisterUser(userAuthenticated);
                    return Json(new { success = true, html = View("Home") });
                }

                return Json(new { success = false, statusCode = 401 });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, statusCode = 400 });
            }            
        }
    }
}
