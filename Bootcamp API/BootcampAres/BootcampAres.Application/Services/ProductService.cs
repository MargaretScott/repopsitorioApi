using BootcampAres.Application.Contracts.Services;
using BootcampAres.Application.Mappers;
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
            if (string.IsNullOrEmpty(code))
                return new ProductResponse { Error = "El codigo de producto no puede estar vacío." };

            //Necesito llamar a mi repositorio
            ProductDto? product = _productRepository.GetProductById(code);

            if(product != null)
            {
                ProductResponse result = ProductMapper.MapToProductResponseFromProductDto(product);

                return result;
            }
            else return null;
        }

        public ProductResponse AddProduct(ProductRequest product)
        {
            if(ValidateProductExistence(product.Code))
                return new ProductResponse { Error = "El producto ya existe en bbdd." };

            //TODO: Falta la validacion por productLine

            //ProductRequest -> ProductDto
            //Mapeo
            ProductDto newProduct = ProductMapper.MapToProductDtoFromProductRequest(product);

            ProductDto productInserted = _productRepository.AddProduct(newProduct);

            //Hacer el SaveChanges
            _uOw.SaveChanges();

            //ProductDto a ProductResponse
            ProductResponse result = ProductMapper.MapToProductResponseFromProductDto(productInserted);

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
            if (string.IsNullOrEmpty(code))
                return new ProductResponse { Error = "El codigo de producto no puede estar vacío." };

            if (!ValidateProductExistence(code))
                return new ProductResponse { Error = "El producto no existe en bbdd." };

            //TODO: Falta la validacion por productLine

            //ProductRequest -> ProductDto
            //Mapeo
            ProductDto newProduct = ProductMapper.MapToProductDtoFromProductUpdateRequest(code, product);

            ProductDto productUpdated = _productRepository.UpdateProduct(newProduct);

            //Hacer el SaveChanges
            _uOw.SaveChanges();

            //ProductDto a ProductResponse
            ProductResponse result = ProductMapper.MapToProductResponseFromProductDto(productUpdated);

            return result;
        }

        private bool ValidateProductExistence(string code)
        {
            ProductDto? product = _productRepository.GetProductById(code);

            if (product == null)
                return false;
            else
                return true;
        }
    }
}
