using dotnet_test_solution.Utils;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service.Interfaces;
using Newtonsoft.Json;

namespace dotnet_test_solution.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpGet(Name = "GetCategories")]
    public IActionResult GetCategories()
    {
        try
        {
            var categories = _categoryService.GetAllCategories();

            string output = Tools.GetJSONfromObject(categories);
            return Ok(output);
        }
        catch(Exception e)
        {
            return BadRequest(e);
        }
       
    }
    
    [HttpGet(Name = "GetCategoryById")]
    public IActionResult GetCategoryById(int categoryId)
    {
        try
        {
            var category = _categoryService.GetCategoryById(categoryId);
            if (category == null)
                return BadRequest("ID não encontrado");
            
            string output = Tools.GetJSONfromObject(category);

            return Ok(output);
        }
        catch(Exception e)
        {
            return BadRequest();
        }
    }

    [HttpPost(Name = "AddCategory")]
    public IActionResult AddCategory(Category category)
    {
        try
        {
            _categoryService.Add(category);
            string output = Tools.GetJSONfromObject(category);
            return Ok(output);
        }
        catch(Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost(Name = "UpdateCategory")]
    public IActionResult UpdateCategory(Category category)
    {
        try
        {
            _categoryService.Update(category);
            string output = Tools.GetJSONfromObject(category);
            return Ok(output);
        }
        catch(Exception e)
        {
            return BadRequest(e);
        } 
    }

    [HttpDelete(Name = "DeleteCategory")]
    public IActionResult DeleteCategory(int categoryId)
    {
        try
        {
            _categoryService.Delete(categoryId);
            return Ok("categoria deletada");
        }
        catch(Exception e)
        {
            return BadRequest(e);
        } 
    }
}