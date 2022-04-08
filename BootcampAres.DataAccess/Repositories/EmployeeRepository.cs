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
    }
}
