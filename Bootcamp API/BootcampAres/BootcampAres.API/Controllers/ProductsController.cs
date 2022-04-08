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
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetProductByCode(string code)
        {
            ProductResponse? product = _productService.GetProductByCode(code);

            if(product != null)
            {
                if (string.IsNullOrEmpty(product.Error))
                    return Ok(product);
                else
                    return BadRequest(product.Error);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddProduct(ProductRequest product)
        {
            ProductResponse newProduct = _productService.AddProduct(product);

            if (string.IsNullOrEmpty(newProduct.Error))
                return Ok(product);
            else
                return BadRequest(newProduct.Error);
        }

        [HttpDelete]
        [Route("{code}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteProduct(string code)
        {
            bool result = _productService.DeleteProduct(code);

            if (result)
                return NoContent();
            else
                return BadRequest("El producto no existe");
        }

        [HttpPut]
        [Route("{code}")]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateProduct(string code, ProductUpdateRequest product)
        {
            ProductResponse productUpdated = _productService.UpdateProduct(code, product);

            if (string.IsNullOrEmpty(productUpdated.Error))
                return Ok(product);
            else
                return BadRequest(productUpdated.Error);
        }
    }
}
