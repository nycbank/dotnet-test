using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NYCBankAPI.Models;
using NYCBankAPI.Repository;
using NYCBankAPI.Repository.Interfaces;

namespace NYCBankAPI.Controllers;

[Route("/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoriasRepository;
    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoriasRepository = categoryRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<CategoryModel>>> GetAllCategories()
    {
        List<CategoryModel> categories = await _categoriasRepository.GetAllCategories();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryModel>> GetCategoriesById(int id)
    {
        CategoryModel category = await _categoriasRepository.GetCategoryById(id);
        return Ok(category);
    }

    [HttpPost]
    public async Task<ActionResult<CategoryModel>> AddCategories([FromBody] CategoryModel categoryModel)
    {
        CategoryModel category = await _categoriasRepository.AddCategories(categoryModel);
        return Ok(category);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<CategoryModel>> UpdateCategory([FromBody] CategoryModel categoryModel, int id)
    {
        categoryModel.CategoryId = id;
        CategoryModel category = await _categoriasRepository.UpdateCategory(categoryModel, id);
        return Ok(category);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<CategoryModel>> DelectCategory(int id)
    {
        bool response = await _categoriasRepository.DeleteCategory(id);
        return Ok(response);
    }
}
