using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_test.Models;

namespace dotnet_test.Services.CategoriesService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategory(int id);
        Task<List<Category>> AddCategory(Category category);
        Task<List<Category>> UpdateCategory(int id, Category category);
        Task<List<Category>> DeleteCategory(int id);
    }
}
