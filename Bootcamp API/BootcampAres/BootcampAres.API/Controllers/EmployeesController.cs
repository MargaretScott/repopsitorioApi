using BootcampAres.Application.Contracts.Services;
using BootcampAres.BusinessModels.Models.Employee;
using Microsoft.AspNetCore.Mvc;

namespace BootcampAres.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("{number}")]
        [ProducesResponseType(typeof(EmployeeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetEmployeeByNumber(int number)
        {
            EmployeeResponse? employee = _employeeService.GetEmployeeByNumber(number);

            if (employee != null)
            {
                if (string.IsNullOrEmpty(employee.Error))
                    return Ok(employee);
                else
                    return BadRequest(employee.Error);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(EmployeeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddEmployee(EmployeeRequest employee)
        {
            EmployeeResponse newEmployee = _employeeService.AddEmployee(employee);

            if (string.IsNullOrEmpty(newEmployee.Error))
                return Ok(newEmployee);
            else
                return BadRequest(newEmployee.Error);
        }

        [HttpDelete]
        [Route("{number}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteEmployee(int number)
        {
            bool result = _employeeService.DeleteEmployee(number);

            if (result)
                return NoContent();
            else
                return BadRequest("El empleado no existe");
        }

        [HttpPut]
        [Route("{number}")]
        [ProducesResponseType(typeof(EmployeeResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateEmployee(int number, EmployeeUpdateRequest employee)
        {
            EmployeeResponse employeeUpdated = _employeeService.UpdateEmployee(number, employee);

            if (string.IsNullOrEmpty(employeeUpdated.Error))
                return Ok(employeeUpdated);
            else
                return BadRequest(employeeUpdated.Error);
        }

        [HttpPost]
        [Route("search")]
        [ProducesResponseType(typeof(EmployeeSearchResponseList), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult SearchEmployee(EmployeeSearchRequest request)
        {
            EmployeeSearchResponseList search = _employeeService.SearchEmployee(request);

            if (string.IsNullOrEmpty(search.Error))
                return Ok(search);
            else
                return BadRequest(search.Error);
        }
    }
}
