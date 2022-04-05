using BootcampAres.DataAccess.Contracts.Entities;
using BootcampAres.DataAccess.Contracts.Repositories;

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
                select new ProductDto
                {
                    BuyPrice = product.BuyPrice,
                    Msrp = product.Msrp,
                    ProductCode = productCode,
                    ProductDescription = product.ProductDescription,
                    ProductLine = product.ProductLine,
                    ProductName = product.ProductName,
                    ProductScale = product.ProductScale,
                    ProductVendor = product.ProductVendor,
                    QuantityInStock = product.QuantityInStock,

                };

            return query.FirstOrDefault();
        }
        public ProductDto AddProduct(ProductDto product)
        {
            Product newproduct = new Product
            {
                BuyPrice = product.BuyPrice,
                Msrp = product.Msrp,
                ProductCode = product.ProductCode,
                ProductDescription = product.ProductDescription,
                ProductLine = product.ProductLine,
                ProductName = product.ProductName,
                ProductScale = product.ProductScale,
                ProductVendor = product.ProductVendor,
                QuantityInStock = product.QuantityInStock,
            };
        }
    }
   
}
