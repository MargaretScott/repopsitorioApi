using BootcampAres.Application.Contracts.Services;
using BootcampAres.Application.Mappers;
using BootcampAres.BusinessModels.Models.Customer;
using BootcampAres.BusinessModels.Models.Employee;
using BootcampAres.DataAccess.Contracts;
using BootcampAres.DataAccess.Contracts.Entities;
using BootcampAres.DataAccess.Contracts.Repositories;

namespace BootcampAres.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _customerRepository;
        private IEmployeeService _employeeService;
        private IUnitOfWork _uOw;

        public CustomerService(ICustomerRepository customerRepository,
                               IEmployeeService employeeService,
                               IUnitOfWork uOw)
        {
            _customerRepository = customerRepository;
            _employeeService = employeeService;
            _uOw = uOw;
        }

        public CustomerResponse? GetCustomerByNumber(int number)
        {
            //Validar que el number es != 0
            if (number == 0)
                return new CustomerResponse { Error = "El id no puede ser 0." };

            CustomerDto? customer = _customerRepository.GetCustomerByNumber(number);

            CustomerResponse result = new CustomerResponse();

            if (customer != null)
            {
                result = CustomerMapper.MapToCustomerResponseFromCustomerDto(customer);
            }
            else
                return null;

            return result;
        }

        public CustomerResponse AddCustomer(CustomerRequest customer)
        {
            //Validar que el number es != 0
            if (customer.Number == 0)
                return new CustomerResponse { Error = "El id no puede ser 0." };

            //Validar campos obligatorios
            if (string.IsNullOrEmpty(customer.Name)
            || string.IsNullOrEmpty(customer.LastName)
            || string.IsNullOrEmpty(customer.FirstName)
            || string.IsNullOrEmpty(customer.Phone)
            || string.IsNullOrEmpty(customer.AddressLine1)
            || string.IsNullOrEmpty(customer.City)
            || string.IsNullOrEmpty(customer.Country))
                return new CustomerResponse { Error = "Debe informar los campos obligatorios." };

            //Validar que existe la FK del responsable
            if (!ValidateRespExistence(customer.SalesRepEmployeeNumber))
            {
                return new CustomerResponse { Error = "El responsable no existe en bbdd." };
            }

            //Validar que el number pasado en el request no existe ya en bbdd
            if (ValidateCustomerExistence(customer.Number))
                return new CustomerResponse { Error = "El cliente ya existe en bbdd." };

            CustomerDto newCustomer = CustomerMapper.MapToCustomerDtoFromCustomerRequest(customer);

            CustomerDto customerInserted = _customerRepository.AddCustomer(newCustomer);

            _uOw.SaveChanges();

            CustomerResponse result = CustomerMapper.MapToCustomerResponseFromCustomerDto(customerInserted);

            return result;
        }

        public bool DeleteCustomer(int number)
        {
            //Obtener Customer por number
            CustomerDto? customer = _customerRepository.GetCustomerByNumber(number);

            //Validar si el customer existe o no
            if (customer == null)
            {
                return false;
            }
            else
            {
                //Llamada al repositorio a borrar
                _customerRepository.DeleteCustomer(customer);

                //SaveChanges
                _uOw.SaveChanges();

                return true;
            }
        }

        public CustomerResponse UpdateCustomer(int number,
                                               CustomerUpdateRequest customer)
        {
            if (number == 0)
                return new CustomerResponse { Error = "El id no puede ser 0."};

            if(string.IsNullOrEmpty(customer.Name)
            || string.IsNullOrEmpty(customer.LastName)
            || string.IsNullOrEmpty(customer.FirstName)
            || string.IsNullOrEmpty(customer.Phone)
            || string.IsNullOrEmpty(customer.AddressLine1)
            || string.IsNullOrEmpty(customer.City)
            || string.IsNullOrEmpty(customer.Country))
                return new CustomerResponse { Error = "Debe informar los campos obligatorios." };

            if(!ValidateRespExistence(customer.SalesRepEmployeeNumber))
            {
                return new CustomerResponse { Error = "El responsable no existe en bbdd." };
            }

            //Validar si el cliente existe
            if (!ValidateCustomerExistence(number))
                return new CustomerResponse { Error = "El cliente no existe en bbdd." };

            //int y CustomerUpdateRequest -> CustomerDto
            CustomerDto newCustomer = CustomerMapper.MapToCustomerDtoFromCustomerUpdateRequest(number, customer);

            CustomerDto customerUpdated = _customerRepository.UpdateCustomer(newCustomer);

            //Hacer el SaveChanges
            _uOw.SaveChanges();

            //CustomerDto -> CustomerResponse
            CustomerResponse result = CustomerMapper.MapToCustomerResponseFromCustomerDto(customerUpdated);

            return result;
        }

        private bool ValidateRespExistence(int? salesRepEmployeeNumber)
        {
            if (salesRepEmployeeNumber != null && salesRepEmployeeNumber.HasValue)
            {
                //EmployeeDto? employee = _employeeRepository.GetEmployeeByNumber(customer.SalesRepEmployeeNumber.Value);
                EmployeeResponse? employee = _employeeService.GetEmployeeByNumber(salesRepEmployeeNumber.Value);

                if (employee == null)
                    return false;
                else
                    return true;

            }
            return true;
        }

        private bool ValidateCustomerExistence(int customerNumber)
        {
            CustomerDto? existingCustomer = _customerRepository.GetCustomerByNumber(customerNumber);

            if (existingCustomer == null)
                return false;
            else
                return true;

        }
    }
}
