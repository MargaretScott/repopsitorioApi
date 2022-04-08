using BootcampAres.DataAccess.Contracts.Entities;

namespace BootcampAres.DataAccess.Contracts.Repositories
{
    public interface ICustomerRepository
    {
        CustomerDto? GetCustomerByNumber(int number);
        CustomerDto AddCustomer(CustomerDto customer);
        void DeleteCustomer(CustomerDto customer);
        CustomerDto UpdateCustomer(CustomerDto customer);

        CustomerWithEmployeeDtoList CustomerSearch(int pageNumber,
                                                   int itemsPerPage,
                                                   string? customerName = null,
                                                   string? contactFirstName = null,
                                                   string? city = null,
                                                   string? country = null,
                                                   string? employeeFirstName = null);
    }
}
