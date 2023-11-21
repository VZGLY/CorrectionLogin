using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace CorrectionLogin.Controllers
{
    public class AuthController : Controller
{
        IAuthService _authService;
        public AuthController( IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterForm form)
        {
            if (ModelState.IsValid) 
            {
                string Error = "";
                
                if (_authService.Register(form, out Error))
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, Error);
                return View(form);

            }

            return View(form);
        }

        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginForm form)
        {

            if (ModelState.IsValid)
            {

                UserViewModel? user = _authService.Login(form);

                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "Email ou password invalide.");
                    return View(form);
                }

                return RedirectToAction("Bravo");

            }
            return View(form);
        }

        public IActionResult Bravo()
        {
            return View();
        }
    }
}
