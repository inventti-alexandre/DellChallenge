using System;
using System.Threading.Tasks;
using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.EnititiesViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace DellChallenge.Web2.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
  
        public async Task<IActionResult> SignOut()
        {
            await RemoveUser();
            return Redirect("Index");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied(string returnUrl = null)
        {

            return View("AccessDenied");
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
                if (ModelState.IsValid)
                {
                    var user = new UserLoginViewModel() { Email = email, Password = password };

                    var userAuthenticated = new User(email, password);

                    await RegisterUser(userAuthenticated);

                }

                return Json(new { success = true, html = View("Home") });
            }
            catch(Exception ex)
            {

            }
            return Json(new { success = true, html = View("Home")});
            
        }
    }
}
