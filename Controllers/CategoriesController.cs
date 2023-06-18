using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_test.Models;
using dotnet_test.Services.CategoriesService;

namespace dotnet_test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoriesService;

        public CategoriesController(ICategoryService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAllCategories()
        {
            return categoriesService.GetAllCategories();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var result = categoriesService.GetCategory(id);
            if (result == null)
            {
                return NotFound("Categoria não encontrada");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Category>>> AddCategory(Category category)
        {
            var result = categoriesService.AddCategory(category);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Category>>> UpdateCategory(int id, Category category)
        {
            var result = categoriesService.UpdateCategory(id, category);
            if (result == null)
            {
                return NotFound("Categoria não encontrada");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Category>>> DeleteCategory(int id)
        {
            var result = categoriesService.DeleteCategory(id);
            if (result == null)
            {
                return NotFound("Categoria não encontrada");
            }
            return Ok(result);
        }
    }
}
