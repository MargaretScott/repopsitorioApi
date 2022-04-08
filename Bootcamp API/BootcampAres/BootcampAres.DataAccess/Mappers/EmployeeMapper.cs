using BootcampAres.DataAccess.Contracts.Entities;

namespace BootcampAres.DataAccess.Mappers
{
    public static class EmployeeMapper
    {
        //EmployeeDto -> Employee
        public static Employee MapToEmployeeFromEmployeeDto(EmployeeDto employeeDto)
        {
            Employee result = new Employee
            {
                Email = employeeDto.Email,
                EmployeeNumber = employeeDto.EmployeeNumber,
                Extension = employeeDto.Extension,
                FirstName = employeeDto.FirstName,
                JobTitle = employeeDto.JobTitle,
                LastName = employeeDto.LastName,
                OfficeCode = employeeDto.OfficeCode,
                ReportsTo = employeeDto.ReportsTo
            };

            return result;
        }

        //Employee -> EmployeeDto
        public static EmployeeDto MapToEmployeeDtoFromEmployee(Employee employee)
        {
            EmployeeDto result = new EmployeeDto
            {
                Email = employee.Email,
                EmployeeNumber = employee.EmployeeNumber,
                Extension = employee.Extension,
                FirstName = employee.FirstName,
                JobTitle = employee.JobTitle,
                LastName = employee.LastName,
                OfficeCode = employee.OfficeCode,
                ReportsTo = employee.ReportsTo
            };

            return result;
        }

        //Employee y Office -> EmployeeSearchDto 
        public static EmployeeSearchDto MapToSearchDtoFromEmployeeAndOffice(Employee employee, Office office)
        {
            EmployeeSearchDto result = new EmployeeSearchDto
            {
                EmployeeEmail = employee.Email,
                EmployeeName = $"{employee.FirstName} {employee.LastName}",
                JobTitle = employee.JobTitle,
                OfficeTerritory = office.Territory
            };

            return result;
        }
    }
}
