using BootcampAres.DataAccess.Contracts.Entities;

namespace BootcampAres.DataAccess.Contracts.Repositories
{
    public interface IProductRepository
    {
        ProductDto? GetProductById(string productCode);
        ProductDto AddProduct(ProductDto product);
        void DeleteProduct(ProductDto product);
        ProductDto UpdateProduct(ProductDto product);
    }
}
