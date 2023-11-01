using Repository.DatabaseContexts;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Repositories;

public class ProductCategoryRepository : IProductCategoryRepository
{
    private readonly RegisterContext _registerContext;
    public ProductCategoryRepository(RegisterContext registerContext)
    {
        _registerContext = registerContext;
    }
    public void Add(ProductCategory productCategory)
    {
        _registerContext.ProductCategories.Add(productCategory);
        Save();
    }

    public void Remove(int productCategoryId)
    {
        var productCategory = GetById(productCategoryId);
        _registerContext.ProductCategories.Remove(productCategory);
        Save();
    }

    public void DeleteByProductId(int productId)
    {
        var productCategories = GetByProductId(productId);
        foreach (var productCategory in productCategories)
        {
            _registerContext.ProductCategories.Remove(productCategory);
            Save();
        }
    }
    
    public void DeleteByCategoryId(int categoryId)
    {
        var productCategories = GetByCategoryId(categoryId);
        foreach (var productCategory in productCategories)
        {
            _registerContext.ProductCategories.Remove(productCategory);
            Save();
        }
    }

    public ProductCategory GetById(int productCategoryId)
    {
        return _registerContext.ProductCategories.Find(productCategoryId);
    }

    public IEnumerable<ProductCategory> GetAll()
    {
        return _registerContext.ProductCategories.ToList();
    }

    public IEnumerable<ProductCategory> GetByProductId(int productId)
    {
        return _registerContext.ProductCategories.Where(e => e.ProductId == productId).ToList();
    }

    public IEnumerable<ProductCategory> GetByCategoryId(int categoryId)
    {
        return _registerContext.ProductCategories.Where(e => e.CategoryId == categoryId).ToList();
    }

    public void Save()
    {
        _registerContext.SaveChanges();
    }
}