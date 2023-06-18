using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_test.Models;

namespace dotnet_test.Services.CategoriesService
{
    public class CategoriesService : ICategoryService
    {
        public static List<Category> categories = new()
        {
            new Category() { Id = 1, Nome = "Categoria 1" },
            new Category() { Id = 2, Nome = "Categoria 2" },
            new Category() { Id = 3, Nome = "Categoria 3" },
            new Category() { Id = 4, Nome = "Categoria 4" },
            new Category() { Id = 5, Nome = "Categoria 5" },
            new Category() { Id = 6, Nome = "Categoria 6" },
            new Category() { Id = 7, Nome = "Categoria 7" },
            new Category() { Id = 8, Nome = "Categoria 8" },
            new Category() { Id = 9, Nome = "Categoria 9" },
            new Category() { Id = 10, Nome = "Categoria 10" },
        };

        public List<Category> AddCategory(Category category)
        {
            categories.Add(category);
            return categories;
        }

        public List<Category>? DeleteCategory(int id)
        {
            var categoryDelete = categories.Find(category => category.Id == id);
            if (categoryDelete == null)
            {
                return null;
            }

            categories.Remove(categoryDelete);
            return categories;
        }

        public List<Category> GetAllCategories()
        {
            return categories;
        }

        public Category? GetCategory(int id)
        {
            var categoryGet = categories.Find(category => category.Id == id);
            return categoryGet == null ? null : categoryGet;
        }

    public List<Category>? UpdateCategory(int id, Category category)
        {
            var categoryUpdate = categories.Find(category => category.Id == id);
            if (categoryUpdate == null)
            {
                return null;
            }

            categoryUpdate.Nome = category.Nome;
            return categories;
        }
    }
}
