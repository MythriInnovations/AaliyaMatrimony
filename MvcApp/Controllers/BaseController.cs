using System;
using Application.Repository.UnitOfWork;
using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MvcApp.Helper;

namespace MvcApp.Controllers
{
    public class BaseController : Controller
    {
        //private IMediator _mediator;
        private IMapper _mapper;
        public BaseController()
        {
        }

        public BaseController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            //UserManager = userManager;
            //SignInManager = signInManager;
        }

        //protected UserManager<User> UserManager { get; set; }
        //protected SignInManager<User> SignInManager { get; set; }
        //protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());
        protected IMapper Mapper => _mapper ?? (_mapper = HttpContext.RequestServices.GetService<IMapper>());
        protected IServiceProvider Services => (IServiceProvider) HttpContext.RequestServices.GetService(typeof(IServiceProvider));
        //protected IUnitOfWork UnitOfWork => Services.GetRequiredService<UnitOfWork>();
        protected ILoginHelper LoginHelperObject => Services.GetRequiredService<ILoginHelper>();
    }
}