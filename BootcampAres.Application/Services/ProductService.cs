using BootcampAres.Application.Contracts.Services;
using BootcampAres.BusinessModels.Models.Product;
using BootcampAres.DataAccess.Contracts;
using BootcampAres.DataAccess.Contracts.Entities;
using BootcampAres.DataAccess.Contracts.Repositories;

namespace BootcampAres.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IUnitOfWork _uOw;

        public ProductService(IProductRepository productRepository,
                              IUnitOfWork uOw)
        {
            _productRepository = productRepository;
            _uOw = uOw;
        }

        public ProductResponse? GetProductByCode(string code)
        {
            //Necesito llamar a mi repositorio
            ProductDto? product = _productRepository.GetProductById(code);

            ProductResponse result = new ProductResponse();

            if(product != null)
            {
                result.Code = product.ProductCode;
                result.Description = product.ProductDescription;
                result.Price = product.BuyPrice;
                result.Stock = product.QuantityInStock;
            }
            else return null;

            return result;
        }

        public ProductResponse AddProduct(ProductRequest product)
        {
            //ProductRequest -> ProductDto
            //Mapeo
            ProductDto newProduct = new ProductDto
            {
                BuyPrice = product.Price,
                Msrp = product.Msrp,
                ProductCode = product.Code,
                ProductDescription = product.Description,
                ProductLine = product.Line,
                ProductName = product.Name,
                ProductScale = product.Scale,
                ProductVendor = product.Vendor,
                QuantityInStock = product.Stock
            };

            ProductDto productInserted = _productRepository.AddProduct(newProduct);

            //Hacer el SaveChanges
            _uOw.SaveChanges();

            //ProductDto a ProductResponse
            ProductResponse result = new ProductResponse
            {
                Code = productInserted.ProductCode,
                Description = productInserted.ProductDescription,
                Price = productInserted.BuyPrice,
                Stock = productInserted.QuantityInStock
            };

            return result;
        }

        public bool DeleteProduct(string productCode)
        {
            //Obtener Producto por code
            ProductDto? product = _productRepository.GetProductById(productCode);

            //Validar si el producto existe o no
            if(product == null)
            {
                return false;
            }
            else
            {
                //Llamada al repositorio a borrar
                _productRepository.DeleteProduct(product);

                //SaveChanges
                _uOw.SaveChanges();

                return true;
            }
        }

        public ProductResponse UpdateProduct(string code,
                                             ProductUpdateRequest product)
        {
            //ProductRequest -> ProductDto
            //Mapeo
            ProductDto newProduct = new ProductDto
            {
                BuyPrice = product.Price,
                Msrp = product.Msrp,
                ProductCode = code,
                ProductDescription = product.Description,
                ProductLine = product.Line,
                ProductName = product.Name,
                ProductScale = product.Scale,
                ProductVendor = product.Vendor,
                QuantityInStock = product.Stock
            };

            ProductDto productUpdated = _productRepository.UpdateProduct(newProduct);

            //Hacer el SaveChanges
            _uOw.SaveChanges();

            //ProductDto a ProductResponse
            ProductResponse result = new ProductResponse
            {
                Code = productUpdated.ProductCode,
                Description = productUpdated.ProductDescription,
                Price = productUpdated.BuyPrice,
                Stock = productUpdated.QuantityInStock
            };

            return result;
        }
    }
}
