using Repository.Models;

namespace Repository.Interfaces;

public interface IProductRepository
{
    public void Add(Product product);
    
    public void DeleteById(int productId);
    
    public void Update(Product product);
    
    public Product GetProductById(int productId);
    
    public IEnumerable<Product> GetProducts();

    protected void Save();
}