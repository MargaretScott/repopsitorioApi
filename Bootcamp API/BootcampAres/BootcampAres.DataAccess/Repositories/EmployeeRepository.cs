using BootcampAres.DataAccess.Contracts.Entities;
using BootcampAres.DataAccess.Contracts.Repositories;
using BootcampAres.DataAccess.Mappers;

namespace BootcampAres.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private BootcampAresContext _context;

        public EmployeeRepository(BootcampAresContext context)
        {
            _context = context;
        }

        public EmployeeDto? GetEmployeeByNumber(int number)
        {
            var query =
                from e in _context.Employees
                where e.EmployeeNumber == number
                select EmployeeMapper.MapToEmployeeDtoFromEmployee(e);

            return query.FirstOrDefault();
        }

        public EmployeeDto AddEmployee(EmployeeDto employee)
        {
            Employee newEmployee = EmployeeMapper.MapToEmployeeFromEmployeeDto(employee);

            var employeeInserted = _context.Employees.Add(newEmployee);

            EmployeeDto result = EmployeeMapper.MapToEmployeeDtoFromEmployee(employeeInserted.Entity);

            return result;
        }

        public void DeleteEmployee(EmployeeDto employee)
        {
            Employee employeeToDelete = EmployeeMapper.MapToEmployeeFromEmployeeDto(employee);

            _context.Employees.Remove(employeeToDelete);
        }

        public EmployeeDto UpdateEmployee(EmployeeDto employee)
        {
            Employee employeeToUpdate = EmployeeMapper.MapToEmployeeFromEmployeeDto(employee);

            var employeeUpdated = _context.Employees.Update(employeeToUpdate);

            EmployeeDto result = EmployeeMapper.MapToEmployeeDtoFromEmployee(employeeUpdated.Entity);

            return result;
        }

        public EmployeeSearchDtoList SearchEmployee(int pageNumber, int itemsPerPage, string? firstName = null, string? lastName = null, string? email = null)
        {
            //Hacer la query con el mapeo al dto
            var query =
                from e in _context.Employees
                join o in _context.Offices on e.OfficeCode equals o.OfficeCode
                where (firstName == null || e.FirstName.Contains(firstName))
                   && (lastName == null || e.LastName.Contains(lastName))
                   && (email == null || e.Email.Contains(email))
                orderby e.FirstName
                select EmployeeMapper.MapToSearchDtoFromEmployeeAndOffice(e,o);

            //Hacer la paginacion y sacar el total
            int skip = (pageNumber - 1) * itemsPerPage;

            //Hacer el mapper al tipo EmployeeSearchDtoList
            EmployeeSearchDtoList result = new EmployeeSearchDtoList();
            result.Results = query.Skip(skip).Take(itemsPerPage).ToList();
            result.Total = query.Count();

            return result;
        }
    }
}
