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
        public IActionResult GetEmployeeByNumber(int number)
        {
            EmployeeResponse? employee = _employeeService.GetEmployeeByNumber(number);

            if (employee != null)
            {
                return Ok(employee);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeRequest employee)
        {
            EmployeeResponse newEmployee = _employeeService.AddEmployee(employee);

            return Ok(newEmployee);
        }

        [HttpDelete]
        [Route("{number}")]
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
        public IActionResult UpdateEmployee(int number, EmployeeUpdateRequest employee)
        {
            EmployeeResponse employeeUpdated = _employeeService.UpdateEmployee(number, employee);

            if (string.IsNullOrEmpty(employeeUpdated.Error))
                return Ok(employeeUpdated);
            else
                return BadRequest(employeeUpdated.Error);
        }
    }
}
