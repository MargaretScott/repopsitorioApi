using BootcampAres.BusinessModels.Models.Product;

namespace BootcampAres.Application.Contracts.Services
{
    public interface IProductService 
    {
        ProductResponse? GetProductByCode(string code);
    }
}
