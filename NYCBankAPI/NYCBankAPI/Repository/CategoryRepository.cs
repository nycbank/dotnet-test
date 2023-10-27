using Microsoft.EntityFrameworkCore;
using NYCBankAPI.Data;
using NYCBankAPI.Models;
using NYCBankAPI.Repository.Interfaces;

namespace NYCBankAPI.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly NycBankDBContext _dbContext;
    public CategoryRepository(NycBankDBContext nycBankDBContext)
    {
        _dbContext = nycBankDBContext;
    }


    public async Task<List<CategoryModel>> GetAllCategories()
    {
        return await _dbContext.Categories.ToListAsync();
    }

    public async Task<CategoryModel> GetCategoryById(int id)
    {
        return await _dbContext.Categories.FirstOrDefaultAsync(x => x.CategoryId == id);
    }

    public async Task<CategoryModel> AddCategories(CategoryModel category)
    {
        await _dbContext.Categories.AddAsync(category);
        await _dbContext.SaveChangesAsync();
        return category;
    }

    public async Task<CategoryModel> UpdateCategory(CategoryModel category, int id)
    {
        CategoryModel categoryById = await GetCategoryById(id);

        if (categoryById == null)
        {
            throw new Exception("Category not found");
        }
        categoryById.Name = category.Name;
        
        _dbContext.Categories.Update(categoryById);
        await _dbContext.SaveChangesAsync();
        return categoryById;
    }

    public async Task<bool> DeleteCategory(int id)
    {
        CategoryModel categoryById = await GetCategoryById(id);

        if (categoryById == null)
        {
            throw new Exception("Category not found");
        }

        _dbContext.Categories.Remove(categoryById);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
