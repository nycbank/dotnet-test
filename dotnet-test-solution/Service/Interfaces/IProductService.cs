using Repository.Models;

namespace Service.Interfaces;

public interface IProductService
{
    public void Add(Product product);

    public void Delete(int productId);
    
    public void Update(Product product);
    
    public Product GetProductById(int productId);
    
    public IEnumerable<Product> GetAllProducts();
    public void SetProductCategories(Product product);

}