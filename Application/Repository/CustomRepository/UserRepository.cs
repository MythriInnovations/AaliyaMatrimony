using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Application.Repository.GenericRepository;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Application.Repository.CustomRepository
{
    public class UserRepository : Repository<Domain.Models.User>,IUserRepository
    {
        public UserRepository(DataContext context):base(context)
        {

        }

        public IQueryable<Domain.Models.User> GetAllUsers()
        {
            var users = from s in _dataContext.Users
                        select s;
            return users;
        }

    }
}
