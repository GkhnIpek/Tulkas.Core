using Tulkas.Core.DataAccess.Abstract;
using Tulkas.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Tulkas.Core.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : IDbContext, IDisposable, new()
    {
        private readonly IDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        public EfEntityRepositoryBase(IDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public EfEntityRepositoryBase()
        {
            _dbContext = new TContext();
            _dbSet = _dbContext.Set<TEntity>();
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.SingleOrDefault(filter);
        }
        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter != null
                ? _dbSet.Where(filter).ToList()
                : _dbSet.ToList();
        }
        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
        public void Delete(TEntity entity)
        {
            var existing = _dbSet.Find(entity);
            if (existing != null)
                _dbSet.Remove(entity);
        }
        public bool Any()
        {
            return _dbSet.Any();
        }
        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
