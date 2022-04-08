using BootcampAres.DataAccess.Contracts.Entities;
using BootcampAres.DataAccess.Contracts.Repositories;
using BootcampAres.DataAccess.Mappers;

namespace BootcampAres.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private BootcampAresContext _context;

        public CustomerRepository(BootcampAresContext context)
        {
            _context = context;
        }

        public CustomerDto? GetCustomerByNumber(int number)
        {
            var query =
                from c in _context.Customers
                where c.CustomerNumber == number
                select CustomerMapper.MapToCustomerDtoFromCustomer(c);

            return query.FirstOrDefault();
        }

        public CustomerDto AddCustomer(CustomerDto customer)
        {
            Customer newCustomer = CustomerMapper.MapToCustomerFromCustomerDto(customer);

            var customerAdded = _context.Customers.Add(newCustomer);

            CustomerDto result = CustomerMapper.MapToCustomerDtoFromCustomer(customerAdded.Entity);

            return result;
        }

        public void DeleteCustomer(CustomerDto customer)
        {
            Customer customerToDelete = CustomerMapper.MapToCustomerFromCustomerDto(customer);

            _context.Customers.Remove(customerToDelete);
        }

        public CustomerDto UpdateCustomer(CustomerDto customer)
        {
            Customer customerToUpdate = CustomerMapper.MapToCustomerFromCustomerDto(customer);

            var productUpdated = _context.Customers.Update(customerToUpdate);

            CustomerDto result = CustomerMapper.MapToCustomerDtoFromCustomer(productUpdated.Entity);

            return result;
        }
    }
}
