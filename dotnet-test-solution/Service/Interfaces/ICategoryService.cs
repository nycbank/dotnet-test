using Repository.Models;

namespace Service.Interfaces;

public interface ICategoryService
{
    public void Add(Category category);
    
    public void Delete(int categoryId);
    
    public void Update(Category category);
    
    public Category GetCategoryById(int categoryId);
    
    public IEnumerable<Category> GetAllCategories();

}