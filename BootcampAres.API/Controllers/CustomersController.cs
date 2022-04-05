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
        [Route("{code}")]
        public IActionResult GetCustomerByCode(int code)
        {
            CustomerResponse? customer =
                _customerService.GetCustomerByCode(code);
            if (customer != null)
            {
                return Ok(customer);
            }
            else
            {
                return NoContent();
            }
        }




    }
    
}
