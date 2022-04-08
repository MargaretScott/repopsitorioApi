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
            //Validacion del number != 0

            EmployeeDto? employee = _employeeRepository.GetEmployeeByNumber(number);

            if (employee != null)
            {
                EmployeeResponse result = EmployeeMapper.MapToEmployeeResponseFromEmployeeDto(employee);

                return result;
            }
            else
                return null;

        }

        public EmployeeResponse AddEmployee(EmployeeRequest employee)
        {
            //number != 0 y validar campos obligatorios
            if (employee.EmployeeNumber == 0)
                return new EmployeeResponse { Error = "El id del empleado no puede ser 0." };

            if (string.IsNullOrEmpty(employee.FirstName)
            || string.IsNullOrEmpty(employee.LastName)
            || string.IsNullOrEmpty(employee.Extension)
            || string.IsNullOrEmpty(employee.Email)
            || string.IsNullOrEmpty(employee.JobTitle)
            || string.IsNullOrEmpty(employee.OfficeCode))
                return new EmployeeResponse { Error = "Los campos obligatorios del empleado deben ir informados." };

            //Validar que el empleado existe
            if (ValidateEmployeeExistence(employee.EmployeeNumber))
                return new EmployeeResponse { Error = "El empleado ya existe en bbdd." };

            //Si el ReportsTo viene informado, validar que existe
            if (!ValidateBossExistence(employee.ReportsTo))
                return new EmployeeResponse { Error = "El jefe indicado no existe en bbdd." };

            EmployeeDto newEmployee = EmployeeMapper.MapToEmployeeDtoFromEmployeeRequest(employee);

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
            if (!ValidateEmployeeExistence(number))
                return new EmployeeResponse { Error = "El empleado no existe en bbdd." };

            //Si el ReportsTo viene informado, validar que existe
            if (!ValidateBossExistence(employee.ReportsTo))
                return new EmployeeResponse { Error = "El jefe indicado no existe en bbdd." };

            //int y EmployeeUpdateRequest -> EmployeeDto
            EmployeeDto employeeToUpdate = EmployeeMapper.MapToEmployeeDtoFromEmployeeUpdateRequest(number, employee);

            EmployeeDto employeeUpdated = _employeeRepository.UpdateEmployee(employeeToUpdate);

            _uOw.SaveChanges();

            EmployeeResponse result = EmployeeMapper.MapToEmployeeResponseFromEmployeeDto(employeeUpdated);

            return result;
        }

        public EmployeeSearchResponseList SearchEmployee(EmployeeSearchRequest request)
        {
            if (request.PageNumber < 1)
                return new EmployeeSearchResponseList { Error = "La pagina debe ser mayor que 0" };

            if(request.ItemsPerPage < 1)
                return new EmployeeSearchResponseList { Error = "Los items por paginas deben ser mayor de 0" };

            //Llamar al repositorio con los parametros necesarios y recibir un dto
            EmployeeSearchDtoList search = _employeeRepository.SearchEmployee(request.PageNumber, request.ItemsPerPage, request.FirstName, request.LastName, request.Email);

            //Mapear el dto recibido del repositorio y convertirlo en EmployeeSearchResponseList
            EmployeeSearchResponseList result = EmployeeMapper.MapToSearchResponseListFromSearchDtoList(search, request.PageNumber, request.ItemsPerPage);

            //Hacer el return;
            return result;
        }

        private bool ValidateEmployeeExistence(int number)
        {
            EmployeeDto? existingEmployee = _employeeRepository.GetEmployeeByNumber(number);

            if (existingEmployee == null)
                return false;
            else
                return true;
        }

        private bool ValidateBossExistence(int? number)
        {
            if (number != null && number.HasValue)
            {
                EmployeeDto? existingBoss = _employeeRepository.GetEmployeeByNumber(number.Value);

                if (existingBoss == null)
                    return false;
                else
                    return true;
            }
            return true;
        }
    }
}
