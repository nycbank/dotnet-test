using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_test.Models;

namespace dotnet_test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
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
            new Category() { Id = 10, Nome = "Categoria 10" }
        };

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = categories.Find(category => category.Id == id);
            if (category == null)
            {
                return NotFound("Categoria não encontrada");
            }
            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult<List<Category>>> AddCategory(Category category)
        {
            categories.Add(category);
            return Ok(categories);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Category>>> UpdateCategory(int id, Category category)
        {
            var categoryUpdate = categories.Find(category => category.Id == id);
            if (categoryUpdate == null)
            {
                return NotFound("Categoria não encontrada");
            }
            categoryUpdate.Nome = category.Nome;
            return Ok(categories);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Category>>> DeleteCategory(int id)
        {
            var categoryDelete = categories.Find(category => category.Id == id);
            if (categoryDelete == null)
            {
                return NotFound("Categoria não encontrada");
            }
            categories.Remove(categoryDelete);
            return Ok(categories);
        }
    }
}
