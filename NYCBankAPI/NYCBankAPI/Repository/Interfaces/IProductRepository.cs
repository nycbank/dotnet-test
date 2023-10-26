using NYCBankAPI.Models;

namespace NYCBankAPI.Repository.Interfaces;

public interface IProductRepository
{
    Task<List<ProductModel>> GetAllProducts();
    Task<ProductModel> GetProductById(int id);
    Task<ProductModel> AddProducts(ProductModel product);
    Task<ProductModel> UpdateProducts(ProductModel product, int id);
    Task<bool> DeleteProduct(int id);
}
