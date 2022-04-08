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

        public CustomerWithEmployeeDtoList CustomerSearch(int pageNumber,
                                                          int itemsPerPage,
                                                          string? customerName = null,
                                                          string? contactFirstName = null,
                                                          string? city = null,
                                                          string? country = null,
                                                          string? employeeFirstName = null)
        {
            var query =
                from c in _context.Customers
                join e in _context.Employees on c.SalesRepEmployeeNumber equals e.EmployeeNumber into employees
                from em in employees.DefaultIfEmpty()
                join o in _context.Offices on em.OfficeCode equals o.OfficeCode into offices
                from of in offices.DefaultIfEmpty()
                where (customerName == null || c.CustomerName.Contains(customerName))
                   && (contactFirstName == null || c.ContactFirstName.Contains(contactFirstName))
                   && (city == null || c.City.Contains(city))
                   && (country == null || c.Country.Contains(country))
                   && (employeeFirstName == null || em.FirstName.Contains(employeeFirstName))
                orderby c.CustomerName
                select CustomerMapper.MapToCWithEDtoFromCAndE(c, em, of);

            CustomerWithEmployeeDtoList result = new CustomerWithEmployeeDtoList();

            int skip = (pageNumber - 1) * itemsPerPage;

            result.Results = query.Skip(skip).Take(itemsPerPage).ToList();
            result.Total = query.Count();

            return result;
        }
    }
}
