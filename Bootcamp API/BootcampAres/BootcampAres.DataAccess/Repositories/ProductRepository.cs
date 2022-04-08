using BootcampAres.DataAccess.Contracts.Entities;
using BootcampAres.DataAccess.Contracts.Repositories;
using BootcampAres.DataAccess.Mappers;

namespace BootcampAres.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private BootcampAresContext _context;

        public ProductRepository(BootcampAresContext context)
        {
            _context = context;
        }

        public ProductDto? GetProductById(string productCode)
        {
            var query =
                from product in _context.Products
                where product.ProductCode == productCode
                select ProductMapper.MapToProductDtoFromProduct(product);

            return query.FirstOrDefault();
        }

        public ProductDto AddProduct(ProductDto product)
        {
            Product newProduct = ProductMapper.MapToProductFromProductDto(product);

            var productInserted = _context.Products.Add(newProduct);

            ProductDto result = ProductMapper.MapToProductDtoFromProduct(productInserted.Entity);

            return result;
        }

        public void DeleteProduct(ProductDto product)
        {
            Product productToDelete = ProductMapper.MapToProductFromProductDto(product);

            _context.Products.Remove(productToDelete);
        }

        public ProductDto UpdateProduct(ProductDto product)
        {
            Product productToUpdate = ProductMapper.MapToProductFromProductDto(product);

            var productUpdated = _context.Products.Update(productToUpdate);

            ProductDto result = ProductMapper.MapToProductDtoFromProduct(productUpdated.Entity);

            return result;
        }
    }
}
