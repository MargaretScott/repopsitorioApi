using BootcampAres.Application.Contracts.Services;
using BootcampAres.BusinessModels.Models.Customer;
using BootcampAres.DataAccess.Contracts.Entities;
using BootcampAres.DataAccess.Contracts.Repositories;

namespace BootcampAres.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public CustomerResponse? GetCustomerByCode(int code)
        {
            //Necesito llamar a mi repositorio
            CustomerDto? customer= _customerRepository.GetCustomerById(code);
            CustomerResponse result = new CustomerResponse();

            if (customer != null)
            {
                result.CustomerName = customer.CustomerName;
                result.CustomerNumber = customer.CustomerNumber;
            
                
            }
            else return null;

            return result;

        }

       
     

        
    }
    
}
