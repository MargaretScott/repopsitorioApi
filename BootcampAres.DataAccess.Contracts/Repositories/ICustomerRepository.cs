using BootcampAres.DataAccess.Contracts.Entities;

namespace BootcampAres.DataAccess.Contracts.Repositories
{
    public interface ICustomerRepository
    {
        CustomerDto? GetCustomerByNumber(int number);
        CustomerDto AddCustomer(CustomerDto customer);
        void DeleteCustomer(CustomerDto customer);
        CustomerDto UpdateCustomer(CustomerDto customer);
    }
}
