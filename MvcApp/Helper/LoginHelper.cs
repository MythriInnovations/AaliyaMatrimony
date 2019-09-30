using Domain.Models;
using Microsoft.AspNetCore.Identity;
using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace MvcApp.Helper
{
    public class LoginHelper:ILoginHelper
    {
        
        public SignInManager<User> SignInManager { get; set; }
        public UserManager<User> UserManager { get; set; }

        public async Task<ActionResult<bool>> LoginAsync(LoginViewModel model)
        {
            var existUser = await UserManager.FindByEmailAsync(model.Email);
            if (existUser != null)
            {
                var result = await SignInManager.CheckPasswordSignInAsync(existUser, model.Password, false);

                if (result.Succeeded)
                {
                    await SignInManager.SignInAsync(existUser, model.RememberMe);
                    return true;
                }
            }

            return new NotFoundResult();
        }

        public async Task<ActionResult<bool>> LogoutAsync()
        {
            await SignInManager.SignOutAsync();
            return true;
        }
    }
}
