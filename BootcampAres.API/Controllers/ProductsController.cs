using BootcampAres.Application.Contracts.Services;
using BootcampAres.BusinessModels.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace BootcampAres.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("{code}")]
        public IActionResult GetProductByCode(string code)
        {
            ProductResponse? product =
                _productService.GetProductByCode(code);
            if(product != null)
            {
                return Ok(product);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
