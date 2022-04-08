using BootcampAres.Application.Contracts.Services;
using BootcampAres.Application.Mappers;
using BootcampAres.BusinessModels.Models.Employee;
using BootcampAres.DataAccess.Contracts;
using BootcampAres.DataAccess.Contracts.Entities;
using BootcampAres.DataAccess.Contracts.Repositories;

namespace BootcampAres.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        private IUnitOfWork _uOw;

        public EmployeeService(IEmployeeRepository employeeRepository,
                               IUnitOfWork uOw)
        {
            _employeeRepository = employeeRepository;
            _uOw = uOw;
        }

        public EmployeeResponse? GetEmployeeByNumber(int number)
        {
            EmployeeDto? employee = _employeeRepository.GetEmployeeByNumber(number);

            EmployeeResponse result = new EmployeeResponse();

            if (employee != null)
            {
                result = EmployeeMapper.MapToEmployeeResponseFromEmployeeDto(employee);
            }
            else
                return null;

            return result;
        }

        public EmployeeResponse AddEmployee(EmployeeRequest customer)
        {
            EmployeeDto newEmployee = EmployeeMapper.MapToEmployeeDtoFromEmployeeRequest(customer);

            EmployeeDto employeeInserted = _employeeRepository.AddEmployee(newEmployee);

            _uOw.SaveChanges();

            EmployeeResponse result = EmployeeMapper.MapToEmployeeResponseFromEmployeeDto(employeeInserted);

            return result;
        }

        public bool DeleteEmployee(int number)
        {
            //Obtener Employee por number
            EmployeeDto? employee = _employeeRepository.GetEmployeeByNumber(number);

            //Validar si el employee existe o no
            if (employee == null)
            {
                return false;
            }
            else
            {
                //Llamada al repositorio a borrar
                _employeeRepository.DeleteEmployee(employee);

                //SaveChanges
                _uOw.SaveChanges();

                return true;
            }
        }

        public EmployeeResponse UpdateEmployee(int number, EmployeeUpdateRequest employee)
        {
            //number != 0 y validar campos obligatorios
            if (number == 0)
                return new EmployeeResponse { Error = "El id del empleado no puede ser 0."};

            if(string.IsNullOrEmpty(employee.FirstName)
            || string.IsNullOrEmpty(employee.LastName)
            || string.IsNullOrEmpty(employee.Extension)
            || string.IsNullOrEmpty(employee.Email)
            || string.IsNullOrEmpty(employee.JobTitle)
            || string.IsNullOrEmpty(employee.OfficeCode))
                return new EmployeeResponse { Error = "Los campos obligatorios del empleado deben ir informados." };

            //Validar que el empleado existe
            EmployeeDto? existingEmployee = _employeeRepository.GetEmployeeByNumber(number);

            if (existingEmployee == null)
                return new EmployeeResponse { Error = "El empleado no existe en bbdd." };

            //Si el ReportsTo viene informado, validar que existe
            if(employee.ReportsTo != null)
            {
                EmployeeDto? existingBoss = _employeeRepository.GetEmployeeByNumber(employee.ReportsTo.Value);

                if (existingBoss == null)
                    return new EmployeeResponse { Error = "El jefe indicado no existe en bbdd" };
            }

            //int y EmployeeUpdateRequest -> EmployeeDto
            EmployeeDto employeeToUpdate = EmployeeMapper.MapToEmployeeDtoFromEmployeeUpdateRequest(number, employee);

            EmployeeDto employeeUpdated = _employeeRepository.UpdateEmployee(employeeToUpdate);

            _uOw.SaveChanges();

            EmployeeResponse result = EmployeeMapper.MapToEmployeeResponseFromEmployeeDto(employeeUpdated);

            return result;
        }
    }
}
