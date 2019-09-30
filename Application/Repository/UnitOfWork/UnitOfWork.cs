using System;
using System.Collections.Generic;
using System.Text;
using Application.Repository.CustomRepository;
using Persistance;

namespace Application.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private readonly IUserRepository _userRepository;

        public UnitOfWork(DataContext dataContext, IUserRepository userRepository)
        {
            _dataContext = dataContext;
            _userRepository = userRepository;
            
        }

        public IUserRepository UserRepository => _userRepository;

        public int Complete()
        {
            return _dataContext.SaveChanges();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
