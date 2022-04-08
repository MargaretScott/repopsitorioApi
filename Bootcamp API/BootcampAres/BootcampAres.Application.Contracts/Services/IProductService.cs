using BootcampAres.BusinessModels.Models.Product;

namespace BootcampAres.Application.Contracts.Services
{
    public interface IProductService
    {
        ProductResponse? GetProductByCode(string code);
        ProductResponse AddProduct(ProductRequest product);
        bool DeleteProduct(string productCode);
        ProductResponse UpdateProduct(string code,
                                      ProductUpdateRequest product);
    }
}
