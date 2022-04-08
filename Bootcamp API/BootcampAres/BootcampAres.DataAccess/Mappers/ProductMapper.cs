using BootcampAres.DataAccess.Contracts.Entities;

namespace BootcampAres.DataAccess.Mappers
{
    public static class ProductMapper
    {
        //ProductDto -> Product
        public static Product MapToProductFromProductDto(ProductDto productDto)
        {
            Product result = new Product
            {
                BuyPrice = productDto.BuyPrice,
                Msrp = productDto.Msrp,
                ProductCode = productDto.ProductCode,
                ProductDescription = productDto.ProductDescription,
                ProductLine = productDto.ProductLine,
                ProductName = productDto.ProductName,
                ProductScale = productDto.ProductScale,
                ProductVendor = productDto.ProductVendor,
                QuantityInStock = productDto.QuantityInStock
            };

            return result;
        }

        //Product -> ProductDto
        public static ProductDto MapToProductDtoFromProduct(Product product)
        {
            ProductDto result = new ProductDto
            {
                BuyPrice = product.BuyPrice,
                Msrp = product.Msrp,
                ProductCode = product.ProductCode,
                ProductDescription = product.ProductDescription,
                ProductLine = product.ProductLine,
                ProductName = product.ProductName,
                ProductScale = product.ProductScale,
                ProductVendor = product.ProductVendor,
                QuantityInStock = product.QuantityInStock
            };

            return result;
        }
    }
}
