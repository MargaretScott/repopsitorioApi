using BootcampAres.DataAccess.Contracts.Entities;

namespace BootcampAres.DataAccess.Contracts.Repositories
{
    public interface IEmployeeRepository
    {
        EmployeeDto? GetEmployeeByNumber(int number);
        EmployeeDto AddEmployee(EmployeeDto employee);
        void DeleteEmployee(EmployeeDto employee);
        EmployeeDto UpdateEmployee(EmployeeDto employee);

        EmployeeSearchDtoList SearchEmployee(int pageNumber, int itemsPerPage, string? firstName = null, string? lastName = null, string? email = null);
    }
}
