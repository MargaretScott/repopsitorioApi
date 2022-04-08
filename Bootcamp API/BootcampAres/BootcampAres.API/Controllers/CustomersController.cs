using BootcampAres.Application.Contracts.Services;
using BootcampAres.BusinessModels.Models.Customer;
using Microsoft.AspNetCore.Mvc;

namespace BootcampAres.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : Controller
    {
        private ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        [Route("{number}")]
        [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCustomerByNumber(int number)
        {
            CustomerResponse? customer = _customerService.GetCustomerByNumber(number);

            if (customer != null)
            {
                if (string.IsNullOrEmpty(customer.Error))
                    return Ok(customer);
                else
                    return BadRequest(customer.Error);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddCustomer(CustomerRequest customer)
        {
            CustomerResponse newCustomer = _customerService.AddCustomer(customer);

            if (string.IsNullOrEmpty(newCustomer.Error))
                return Ok(newCustomer);
            else
                return BadRequest(newCustomer.Error);
        }

        [HttpDelete]
        [Route("{number}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCustomer(int number)
        {
            bool result = _customerService.DeleteCustomer(number);

            if (result)
                return NoContent();
            else
                return BadRequest("El cliente no existe");
        }

        [HttpPut]
        [Route("{number}")]
        [ProducesResponseType(typeof(CustomerResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateCustomer(int number, CustomerUpdateRequest customer)
        {
            CustomerResponse customerUpdated = _customerService.UpdateCustomer(number, customer);

            if (string.IsNullOrEmpty(customerUpdated.Error))
                return Ok(customerUpdated);
            else
                return BadRequest(customerUpdated.Error);
        }

        [HttpPost]
        [Route("search")]
        [ProducesResponseType(typeof(CustomerWithEmployeeResponseList), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CustomerSearch(CustomerSearchRequest request)
        {
            CustomerWithEmployeeResponseList searchList = _customerService.CustomerSearch(request);

            if (string.IsNullOrEmpty(searchList.Error))
                return Ok(searchList);
            else
                return BadRequest(searchList.Error);
        }
    }
}
