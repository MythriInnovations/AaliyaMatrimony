using Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Application.Repository.GenericRepository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity:class
    {
        protected readonly DataContext _dataContext;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(TEntity entity)
        {
            _dataContext.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dataContext.AddRange(entities);
        }

        public IEnumerable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> expression)
        {
           return _dataContext.Set<TEntity>().Where(expression);
        }

        public async Task<IEnumerable<TEntity>> FindByAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Task.Run(()=>_dataContext.Set<TEntity>().Where(expression));
        }

        public TEntity Get(string id)
        {
            return _dataContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dataContext.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            _dataContext.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dataContext.RemoveRange(entities);
        }
    }
}
