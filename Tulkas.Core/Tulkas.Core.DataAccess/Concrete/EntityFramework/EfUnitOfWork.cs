using Tulkas.Core.DataAccess.Abstract;
using Tulkas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tulkas.Core.DataAccess.Concrete.EntityFramework
{
    public class EfUnitOfWork<TContext> : IUnitOfWork
        where TContext : IDbContext, IDisposable, new()
    {
        private readonly IDbContext _ctx;
        private readonly Dictionary<Type, object> _repositories;
        private bool _disposed;

        public EfUnitOfWork()
        {
            _ctx = new TContext();
            _repositories = new Dictionary<Type, object>();
            _disposed = false;
        }

        public IEntityRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity, new()
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IEntityRepository<TEntity>;
            }

            var repository = new EfEntityRepositoryBase<TEntity, TContext>(_ctx);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }
        public int SaveChanges()
        {
            return _ctx.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
                _ctx.Dispose();
            }
            _disposed = true;
        }
    }
}
