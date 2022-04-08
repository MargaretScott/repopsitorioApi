using BootcampAres.BusinessModels.Models.Product;
using BootcampAres.DataAccess.Contracts.Entities;

namespace BootcampAres.Application.Mappers
{
    public static class ProductMapper
    {
        //ProductDto -> ProductResponse
        public static ProductResponse MapToProductResponseFromProductDto(ProductDto productDto)
        {
            ProductResponse result = new ProductResponse
            {
                Code = productDto.ProductCode,
                Description = productDto.ProductDescription,
                Price = productDto.BuyPrice,
                Stock = productDto.QuantityInStock,
            };

            return result;
        }

        //ProductRequest -> ProductDto
        public static ProductDto MapToProductDtoFromProductRequest(ProductRequest product)
        {
            ProductDto result = new ProductDto
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

            return result;
        }

        //string y ProductUpdateRequest -> ProductDto
        public static ProductDto MapToProductDtoFromProductUpdateRequest(string code, ProductUpdateRequest product)
        {
            ProductDto result = new ProductDto
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

            return result;
        }
    }
}
