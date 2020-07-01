using Tulkas.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Tulkas.Core.DataAccess.Abstract
{
    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : class, IEntity;
        int SaveChanges();
        void Dispose();
    }
}
