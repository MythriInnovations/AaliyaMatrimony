using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Helper;
using Application.Repository.UnitOfWork;
using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MvcApp.Models;
using Persistance;

namespace MvcApp.Controllers
{
    [Authorize(Roles ="Admin")]
    public class UserController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _dataContext;
        private readonly IConfiguration _config;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, IUnitOfWork unitOfWork,DataContext dataContext,IConfiguration config)
        {
            _signInManager = signInManager;
            _unitOfWork = unitOfWork;
            _dataContext = dataContext;
            _config = config;
            _userManager = userManager;
        }

        [Route("Register")]
        [HttpGet]
        public async Task<IActionResult>  Register()
        {
            return await Task.Run(() =>
            {
                UserViewModel model = new UserViewModel();
                return View(model);
            });
        }

        [Route("UserList")]
        [HttpGet]
        public async Task<IActionResult> UserList(string searchString,
                                                  int? pageNumber)
        {
            //return await Task.Run(() =>
            //{
            //    List<User> users = _unitOfWork.UserRepository.GetAll().ToList();
            //    var pagedListUsers = PagedList<User>.CreatePagedList(users, currentPageNumber, 5);
            //    List<UserViewModel> usersModel = Mapper.Map<List<UserViewModel>>(pagedListUsers);

            //    var vm = new UserListViewModel
            //    {
            //        CurrentPageNumber = currentPageNumber,
            //        Users = usersModel
            //    };

            //    return View(vm);
            //});
            //ViewData["CurrentSort"] = sortOrder;
            //ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                //searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var allUsers = _unitOfWork.UserRepository.GetAllUsers();
            if (!String.IsNullOrEmpty(searchString))
            {
                allUsers = allUsers.Where(s => s.UserName.Contains(searchString)
                                       || s.Email.Contains(searchString) || s.Gender.Contains(searchString));
            }
            //switch (sortOrder)
            //{
            //    case "name_desc":
            //        students = students.OrderByDescending(s => s.LastName);
            //        break;
            //    case "Date":
            //        students = students.OrderBy(s => s.EnrollmentDate);
            //        break;
            //    case "date_desc":
            //        students = students.OrderByDescending(s => s.EnrollmentDate);
            //        break;
            //    default:
            //        students = students.OrderBy(s => s.LastName);
            //        break;
            //}
            int pageSize = Convert.ToInt16(_config.GetSection("Paging:PageSize").Value)==0 ? 5:Convert.ToInt16(_config.GetSection("Paging:PageSize").Value);
            var users = await PagedList<User>.CreatePagedList(allUsers.AsNoTracking(), pageNumber ?? 1, pageSize);
            UserListViewModel usrListModel = Mapper.Map<UserListViewModel>(users);
            return View(usrListModel);
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            return await Task.Run(async () =>
            {
                if (ModelState.IsValid)
                {
                    User userExists = _unitOfWork.UserRepository.Find(usr => usr.Email == model.Email || usr.MobileNumber == model.Mobile).SingleOrDefault();
                    if (userExists == null)
                    {
                        using (User user = new User())
                        {
                            Mapper.Map(model, user);
                            IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                            if (result.Succeeded)
                            {
                                await _userManager.AddToRoleAsync(user, EnumHelper<ERole>.GetRole(ERole.User));
                                ViewBag.SuccessMessage = "User registered successfully";
                                return View();
                            }

                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "User already exists");
                    }
                }
                return View(model);
            });
        }
    }
}