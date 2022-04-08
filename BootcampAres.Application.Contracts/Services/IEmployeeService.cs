using BootcampAres.BusinessModels.Models.Employee;

namespace BootcampAres.Application.Contracts.Services
{
    public interface IEmployeeService
    {
        EmployeeResponse? GetEmployeeByNumber(int number);
        EmployeeResponse AddEmployee(EmployeeRequest customer);
        bool DeleteEmployee(int number);
        EmployeeResponse UpdateEmployee(int number, EmployeeUpdateRequest employee);
    }
}
