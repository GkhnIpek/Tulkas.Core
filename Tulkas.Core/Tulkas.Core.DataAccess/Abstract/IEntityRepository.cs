using Tulkas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Tulkas.Core.DataAccess.Abstract
{
    public interface IEntityRepository<TEntity> : IDisposable
        where TEntity : class, IEntity, new()
    {
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        bool Any();
    }
}
