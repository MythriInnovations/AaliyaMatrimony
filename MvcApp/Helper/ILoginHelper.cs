using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApp.Helper
{
    public interface ILoginHelper
    {
        SignInManager<User> SignInManager { get; set; }
        UserManager<User> UserManager { get; set; }
        Task<ActionResult<bool>> LoginAsync(LoginViewModel model);
       Task<ActionResult<bool>> LogoutAsync();
    }
}
