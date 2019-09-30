using Application.Repository.GenericRepository;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Repository.CustomRepository
{
    public interface IUserRepository:IRepository<Domain.Models.User>
    {
        IQueryable<Domain.Models.User> GetAllUsers();
    }
}
