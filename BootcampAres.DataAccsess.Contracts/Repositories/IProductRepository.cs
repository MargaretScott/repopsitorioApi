using BootcampAres.DataAccess.Contracts.Entities;

namespace BootcampAres.DataAccess.Contracts.Repositories
{
    public interface IProductRepository
    {
        ProductDto? GetProductById(string productCode);
    }
}
