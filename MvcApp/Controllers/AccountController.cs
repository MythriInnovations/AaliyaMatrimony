using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Application.User;
using MvcApp.Models;
using Microsoft.AspNetCore.Authorization;
using Domain.Models;
using MvcApp.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
using System.Collections.Generic;
using Application.Repository.UnitOfWork;
using Domain.Enums;

namespace MvcApp.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager,IUnitOfWork unitOfWork)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            return LocalRedirect("/");
        }

        [HttpGet]
        public async Task<ActionResult<User>> Login()
        {
            return View("index","home");
        }

        [HttpPost]
        public async Task<ActionResult<User>> Login(LoginViewModel model)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                var existUser = _unitOfWork.UserRepository.FindByAsync(obj => obj.Email == model.Email || obj.MobileNumber == model.MobileNumber).Result.ToList().FirstOrDefault();

                if (existUser != null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(existUser, model.Password, false);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(existUser, model.RememberMe);
                        return RedirectToAction("index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("EmailOrMobilenumber", "Email or Password is not matching");
                        return View(model); ;
                    }
                }
                ModelState.AddModelError("UserNotExist", "Email or Mobilenumber is not exists");
            }
            return View(model);
        }

        public async Task<ActionResult<User>> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "Home");
        }

        public ActionResult AccessDenied()
        {
            return View();
        }
    }
}