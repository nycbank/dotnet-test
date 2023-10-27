using NYCBankAPI.Models;

namespace NYCBankAPI.Repository.Interfaces;

public interface ICategoryRepository
{
    Task<List<CategoryModel>> GetAllCategories();
    Task<CategoryModel> GetCategoryById(int id);
    Task<CategoryModel> AddCategories(CategoryModel category);
    Task<CategoryModel> UpdateCategory(CategoryModel category, int id);
    Task<bool> DeleteCategory(int id);
}
