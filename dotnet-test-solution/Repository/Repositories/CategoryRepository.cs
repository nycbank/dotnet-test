using Repository.DatabaseContexts;
using Repository.Interfaces;
using Repository.Models;

namespace Repository.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly RegisterContext _registerContext;
    
    public CategoryRepository(RegisterContext registerContext)
    {
        _registerContext = registerContext;
    }
    
    public void Add(Category category)
    {
        _registerContext.Categories.Add(category);
        Save();
    }

    public void DeleteById(int categoryId)
    {
        var category = GetCategoryById(categoryId);
        _registerContext.Categories.Remove(category);
        Save();
    }

    public void Update(Category category)
    {
        _registerContext.Update(category);
        Save();
    }

    public Category GetCategoryById(int categoryId)
    {
        return _registerContext.Categories.Find(categoryId);
    }

    public IEnumerable<Category> GetCategories()
    {
        return _registerContext.Categories.ToList();
    }

    public void Save()
    {
        _registerContext.SaveChanges();
    }
}