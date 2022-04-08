using CursoDotNet.DataAccess.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CursoDotNet.DataAccess.Contracts
{
    public interface IApplicationDbContext
    {
        DbSet<Car> Cars { get; set; }

        DbSet<User> Users { get; set; }

        DbSet<Role> Roles { get; set; }

        int SaveChanges();

        void Dispose();

        EntityEntry<TEntity> GetEntry<TEntity>(TEntity entity) where TEntity : class;

        DbSet<T> GetEntitySet<T>() where T : class;

        DatabaseFacade TheDatabase { get; }
    }
}
