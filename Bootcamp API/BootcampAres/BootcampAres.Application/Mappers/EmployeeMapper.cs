using BootcampAres.BusinessModels.Models.Employee;
using BootcampAres.DataAccess.Contracts.Entities;

namespace BootcampAres.Application.Mappers
{
    public static class EmployeeMapper
    {
        //EmployeeDto -> EmployeeResponse
        public static EmployeeResponse MapToEmployeeResponseFromEmployeeDto(EmployeeDto employee)
        {
            EmployeeResponse result = new EmployeeResponse
            {
                Email = employee.Email,
                EmployeeNumber = employee.EmployeeNumber,
                FirstName = employee.FirstName,
                JobTitle = employee.JobTitle,
                LastName = employee.LastName
            };

            return result;
        }

        //EmployeeRequest -> EmployeeDto
        public static EmployeeDto MapToEmployeeDtoFromEmployeeRequest(EmployeeRequest employee)
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

        //int y EmployeeUpdateRequest -> EmployeeDto
        public static EmployeeDto MapToEmployeeDtoFromEmployeeUpdateRequest(int number, EmployeeUpdateRequest employee)
        {
            EmployeeDto result = new EmployeeDto
            {
                Email = employee.Email,
                EmployeeNumber = number,
                Extension = employee.Extension,
                FirstName = employee.FirstName,
                JobTitle = employee.JobTitle,
                LastName = employee.LastName,
                OfficeCode = employee.OfficeCode,
                ReportsTo = employee.ReportsTo
            };

            return result;
        }

        //EmployeeSearchDto -> EmployeeSearchResponse
        public static EmployeeSearchResponse MapToSearchResponseFromSearchDto(EmployeeSearchDto dto)
        {
            EmployeeSearchResponse result = new EmployeeSearchResponse
            {
                EmployeeEmail = dto.EmployeeEmail,
                EmployeeName = dto.EmployeeName,
                JobTitle = dto.JobTitle,
                OfficeTerritory = dto.OfficeTerritory
            };

            return result;
        }

        //EmployeeSearchDtoList -> EmployeeSearchResponseList
        public static EmployeeSearchResponseList MapToSearchResponseListFromSearchDtoList(EmployeeSearchDtoList dtoList, int pageNumber, int itemsPerPage)
        {
            EmployeeSearchResponseList result = new EmployeeSearchResponseList();
            result.Total = dtoList.Total;
            result.PageNumber = pageNumber;
            result.ItemsPerPage = itemsPerPage;

            foreach(EmployeeSearchDto employee in dtoList.Results)
            {
                result.Results.Add(MapToSearchResponseFromSearchDto(employee));
            }

            return result;
        }
    }
}
