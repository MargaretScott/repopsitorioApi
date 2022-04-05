using BootcampAres.DataAccess.Contracts.Entities;
using BootcampAres.DataAccess.Contracts.Repositories;

namespace BootcampAres.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private BootcampAresContext _context;

        public CustomerRepository(BootcampAresContext context)
        {
            _context = context;
        }

        public CustomerDto? GetCustomerById(int customerNumber)
        {
            var query =
                 from customer in _context.Customers
                 where customer.CustomerNumber == customerNumber
                 select new CustomerDto
                 {
                     AddressLine1 = customer.AddressLine1,
                     AddressLine2 = customer.AddressLine2,
                     City = customer.City,
                     ContactFirstName = customer.ContactFirstName,
                     ContactLastName = customer.ContactLastName,
                     Country = customer.Country,
                     CreditLimit = customer.CreditLimit,
                     CustomerName = customer.CustomerName,
                     CustomerNumber = customer.CustomerNumber,
                     PostalCode = customer.PostalCode,
                     Phone = customer.Phone,
                     SalesRepEmployeeNumber = customer.SalesRepEmployeeNumber,
                     State = customer.State,
                 };

            return query.FirstOrDefault();
         }

       
    }
}
