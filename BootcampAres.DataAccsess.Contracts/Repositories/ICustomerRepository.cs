using BootcampAres.DataAccess.Contracts.Entities;

namespace BootcampAres.DataAccess.Contracts.Repositories
{
    public interface ICustomerRepository
    {
        CustomerDto? GetCustomerById(int CustomerNumber);
      
    }
}
