using Repository.Models;

namespace Repository.Interfaces;

public interface ICategoryRepository
{
    public void Add(Category category);

    public void DeleteById(int categoryId);

    public void Update(Category category);
    
    public Category GetCategoryById(int categoryId);
    public IEnumerable<Category> GetCategories();
    public void Save();
}