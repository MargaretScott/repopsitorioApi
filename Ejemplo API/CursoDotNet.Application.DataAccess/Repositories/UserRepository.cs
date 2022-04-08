using CursoDotNet.DataAccess.Contracts.Entities;
using CursoDotNet.DataAccess.Contracts.Repositories;
using System;

namespace CursoDotNet.DataAccess.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }
}
