using CursoDotNet.DataAccess.Contracts.Repositories;
using System.Threading.Tasks;

namespace CursoDotNet.DataAccess.Contracts
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
