using BootcampAres.BusinessModels.Models.Customer;
using BootcampAres.BusinessModels.Models.Product;

namespace BootcampAres.Application.Contracts.Services
{
    public interface ICustomerService
    {
      CustomerResponse? GetCustomerByCode(int code);
    }
}
