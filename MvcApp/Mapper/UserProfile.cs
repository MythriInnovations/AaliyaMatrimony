using Application.Helper;
using Application.User;
using AutoMapper;
using Domain.Models;
using MvcApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApp.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //CreateMap<LoginViewModel, Login.Query>();
            //CreateMap<Login.Query,LoginViewModel>();
            CreateMap<UserViewModel, User>().ForMember(dest => dest.MobileNumber, obj => obj.MapFrom(src => src.Mobile));
            CreateMap<User, UserViewModel>().ForMember(dest => dest.Mobile, options =>
            {
                options.MapFrom(src => src.MobileNumber);
  
            }).ForMember(dest => dest.Gender, options =>
            {
                options.MapFrom(src => string.Compare(src.Gender,"2") == 0? "Male":"Female");
            });
            CreateMap<PagedList<User>, UserListViewModel>().ForMember(dest => dest.Users, obj => obj.MapFrom(src => src.ToList())).
                ForMember(dest => dest.CurrentPage, obj => obj.MapFrom(src => src.CurrentPage)).
                ForMember(dest => dest.HasNextPage, obj => obj.MapFrom(src => src.HasNextPage)).
                ForMember(dest => dest.HasPreviousPage, obj => obj.MapFrom(src => src.HasPreviousPage))
                .ForMember(dest => dest.TotalPages, obj => obj.MapFrom(src => src.TotalPages))
                .ForMember(dest => dest.TotalCount, obj => obj.MapFrom(src => src.TotalCount))
                .ForMember(dest => dest.PageSize, obj => obj.MapFrom(src => src.PageSize));
        }
    }
}
