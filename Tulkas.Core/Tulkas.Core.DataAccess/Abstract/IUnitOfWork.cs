using Tulkas.Core.Entities;
using System;

namespace Tulkas.Core.DataAccess.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IEntityRepository<TEntity> GetRepository<TEntity>()
            where TEntity : class, IEntity, new();

        int SaveChanges();
    }
}
