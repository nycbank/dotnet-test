using Repository.Models;
using Repository.Repositories;

namespace Repository.Interfaces;

public interface IProductCategoryRepository
{
    public void Add(ProductCategory productCategory);
    public void Remove(int productCategoryId);
    public void DeleteByProductId(int productId);
    public void DeleteByCategoryId(int categoryId);

    public ProductCategory GetById(int productCategoryId);
    public IEnumerable<ProductCategory> GetAll();
    public IEnumerable<ProductCategory> GetByProductId(int productId);
    public IEnumerable<ProductCategory> GetByCategoryId(int categoryId);
    public void Save();
}