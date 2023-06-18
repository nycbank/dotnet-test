using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_test.Models;

namespace dotnet_test.Services.CategoriesService
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        Category? GetCategory(int id);
        List<Category> AddCategory(Category category);
        List<Category>? UpdateCategory(int id, Category category);
        List<Category>? DeleteCategory(int id);
    }
}
