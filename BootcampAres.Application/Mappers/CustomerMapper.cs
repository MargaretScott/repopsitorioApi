using BootcampAres.BusinessModels.Models.Customer;
using BootcampAres.DataAccess.Contracts.Entities;

namespace BootcampAres.Application.Mappers
{
    public static class CustomerMapper
    {
        //CustomerDto -> CustomerResponse
        public static CustomerResponse MapToCustomerResponseFromCustomerDto(CustomerDto customerDto)
        {
            CustomerResponse result = new CustomerResponse
            {
                Name = customerDto.CustomerName,
                CustomerNumber = customerDto.CustomerNumber
            };

            return result;
        }

        //CustomerRequest -> CustomerDto
        public static CustomerDto MapToCustomerDtoFromCustomerRequest(CustomerRequest customerRequest)
        {
            CustomerDto customer = new CustomerDto
            {
                AddressLine1 = customerRequest.AddressLine1,
                AddressLine2 = customerRequest.AddressLine2,
                City = customerRequest.City,
                ContactFirstName = customerRequest.FirstName,
                ContactLastName = customerRequest.LastName,
                Country = customerRequest.Country,
                CreditLimit = customerRequest.CreditLimit,
                CustomerName = customerRequest.Name,
                CustomerNumber = customerRequest.Number,
                Phone = customerRequest.Phone,
                PostalCode = customerRequest.PostalCode,
                SalesRepEmployeeNumber = customerRequest.SalesRepEmployeeNumber,
                State = customerRequest.State
            };

            return customer;
        }

        //int y CustomerUpdateRequest -> CustomerDto
        public static CustomerDto MapToCustomerDtoFromCustomerUpdateRequest(int number, CustomerUpdateRequest customerUpdateRequest)
        {
            CustomerDto customer = new CustomerDto
            {
                AddressLine1 = customerUpdateRequest.AddressLine1,
                AddressLine2 = customerUpdateRequest.AddressLine2,
                City = customerUpdateRequest.City,
                ContactFirstName = customerUpdateRequest.FirstName,
                ContactLastName = customerUpdateRequest.LastName,
                Country = customerUpdateRequest.Country,
                CreditLimit = customerUpdateRequest.CreditLimit,
                CustomerName = customerUpdateRequest.Name,
                CustomerNumber = number,
                Phone = customerUpdateRequest.Phone,
                PostalCode = customerUpdateRequest.PostalCode,
                SalesRepEmployeeNumber = customerUpdateRequest.SalesRepEmployeeNumber,
                State = customerUpdateRequest.State
            };

            return customer;
        }
    }
}
