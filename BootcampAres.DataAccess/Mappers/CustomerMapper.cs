using BootcampAres.DataAccess.Contracts.Entities;

namespace BootcampAres.DataAccess.Mappers
{
    public static class CustomerMapper
    {
        public static CustomerDto MapToCustomerDtoFromCustomer(Customer customer)
        {
            CustomerDto result = new CustomerDto
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
                Phone = customer.Phone,
                PostalCode = customer.PostalCode,
                SalesRepEmployeeNumber = customer.SalesRepEmployeeNumber,
                State = customer.State
            };

            return result;
        }

        public static Customer MapToCustomerFromCustomerDto(CustomerDto customerDto)
        {
            Customer customer = new Customer
            {
                AddressLine1 = customerDto.AddressLine1,
                AddressLine2 = customerDto.AddressLine2,
                City = customerDto.City,
                ContactFirstName = customerDto.ContactFirstName,
                ContactLastName = customerDto.ContactLastName,
                Country = customerDto.Country,
                CreditLimit = customerDto.CreditLimit,
                CustomerName = customerDto.CustomerName,
                CustomerNumber = customerDto.CustomerNumber,
                Phone = customerDto.Phone,
                PostalCode = customerDto.PostalCode,
                SalesRepEmployeeNumber = customerDto.SalesRepEmployeeNumber,
                State = customerDto.State
            };

            return customer;
        }
    }
}
