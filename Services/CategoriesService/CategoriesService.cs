using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_test.Data;
using dotnet_test.Models;
using Microsoft.EntityFrameworkCore;
using dotnet_test.Errors;

namespace dotnet_test.Services.CategoriesService
{
    public class CategoriesService : ICategoryService
    {
        private readonly DataContext dataContext;

        public CategoriesService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<List<Category>> AddCategory(Category category)
        {
            dataContext.Category.Add(category);
            await dataContext.SaveChangesAsync();
            return await dataContext.Category.ToListAsync();
        }

        public async Task<List<Category>> DeleteCategory(int id)
        {
            var categoryDelete = await dataContext.Category.FindAsync(id) ?? throw new NotFoundException("Categoria não encontrada");

            dataContext.Category.Remove(categoryDelete);
            await dataContext.SaveChangesAsync();

            return await dataContext.Category.ToListAsync();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await dataContext.Category.ToListAsync() ?? throw new NotFoundException("Não há categorias cadastradas");
        }

        public async Task<Category> GetCategory(int id)
        {
            return await dataContext.Category.FindAsync(id) ?? throw new NotFoundException("Categoria não encontrada");
        }

    public async Task<List<Category>> UpdateCategory(int id, Category category)
        {
            var categoryUpdate = dataContext.Category.Find(id) ?? throw new NotFoundException("Categoria não encontrada");

            categoryUpdate.Nome = category.Nome;

            await dataContext.SaveChangesAsync();

            return await dataContext.Category.ToListAsync();
        }
    }
}
