using Application.Repository.CustomRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get;}
        int Complete();
    }
}
