using BootcampAres.BusinessModels.Models.Product;
using BootcampAres.DataAccess.Contracts.Repositories;
using BootcampAres.Application.Contracts.Services;
using BootcampAres.DataAccess.Contracts.Entities;

namespace BootcampAres.Application.Services
{
    public class ProductService : IProductService
    {

        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
            public ProductResponse? GetProductByCode(string code)
            {

            //Necesito llamar a mi repositorio
            ProductDto? product = _productRepository.GetProductById(code);
            ProductResponse result = new ProductResponse();

            if (product != null)
            {
                result.Code = product.ProductCode;
                result.Description = product.ProductDescription;
                result.Price = product.BuyPrice;
                result.Stock = product.QuantityInStock;
            }
            else return null;

            return result;  

            }
    }
}
