using BootcampAres.BusinessModels.Models.Customer;

namespace BootcampAres.Application.Contracts.Services
{
    public interface ICustomerService
    {
        CustomerResponse? GetCustomerByNumber(int number);
        CustomerResponse AddCustomer(CustomerRequest customer);
        CustomerResponse UpdateCustomer(int number,
                                               CustomerUpdateRequest customer);
        bool DeleteCustomer(int number);
    }
}
