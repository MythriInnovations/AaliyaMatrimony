using Application.Errors;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.User
{
    /// <summary>
    /// CQRS query and handler.
    /// </summary>
    public class Login
    {
        //public class Query : IRequest<User>
        //{
        //    public string Email { get; set; }
        //    public string MobileNumber { get; set; }
        //    public string Password { get; set; }
        //    public bool RememberMe { get; set; }
        //}
        //public class QueryValidator : AbstractValidator<Query>
        //{
        //    public QueryValidator()
        //    {
        //        RuleFor(x => x.MobileNumber).Empty()
        //                     .When(x => !string.IsNullOrEmpty(x.Email)).NotEmpty()
        //                     .WithMessage("Please provide Email or Mobile number");

        //        RuleFor(x => x.Email).Empty()
        //                     .When(x => !string.IsNullOrEmpty(x.MobileNumber)).NotEmpty()
        //                     .WithMessage("Please provide Email or Mobile number");

        //        RuleFor(x => x.Password).NotEmpty();
        //    }
        //}
        //public class Handler : IRequestHandler<Query, User>
        //{
        //    private readonly UserManager<User> _userManager;
        //    private readonly SignInManager<User> _signingManager;

        //    public Handler(UserManager<User> userManager,SignInManager<User> signingManager)
        //    {
        //        _userManager = userManager;
        //        _signingManager = signingManager;
        //    }

        //    public async Task<User> Handle(Query request, CancellationToken cancellationToken)
        //    {
        //        var user =await _userManager.FindByEmailAsync(request.Email);

        //        if(user == null)
        //        {
        //            throw new ApplicationRestException(HttpStatusCode.Unauthorized);
        //        }

        //        var result = await _signingManager.CheckPasswordSignInAsync(user, request.Password, false);
        //        if (result.Succeeded)
        //        {
        //            await _signingManager.SignInAsync(user, request.RememberMe);
        //            return user;
        //        }
        //        else
        //        {
        //            throw new ApplicationRestException(HttpStatusCode.Unauthorized);
        //        }
        //    }
        //}
    }
}
