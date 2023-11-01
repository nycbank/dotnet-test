using Repository.DatabaseContexts;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly RegisterContext _registerContext;
    
    public ProductRepository(RegisterContext registerContext)
    {
        _registerContext = registerContext;
    }
    public void Add(Product product)
    {
        _registerContext.Add(product);
        Save();
    }

    public void DeleteById(int productId)
    {
        var product = GetProductById(productId);
        _registerContext.Remove(product);
        Save();
    }

    public void Update(Product product)
    {
        _registerContext.Products.Update(product);
        Save();
    }

    public Product GetProductById(int productId)
    {
      return _registerContext.Products.Find(productId);
    }

    public IEnumerable<Product> GetProducts()
    {
        return _registerContext.Products.ToList();
    }

    public void Save()
    {
        _registerContext.SaveChanges();
    }

}