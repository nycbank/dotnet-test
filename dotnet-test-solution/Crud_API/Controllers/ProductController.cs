using dotnet_test_solution.Utils;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Service.Interfaces;

namespace dotnet_test_solution.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet(Name = "GetProducts")]
    public IActionResult GetProducts()
    {
        try
        {
            var products = _productService.GetAllProducts();
            string output = Tools.GetJSONfromObject(products);
            return Ok(output);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
    
    [HttpGet(Name = "GetProductById")]
    public IActionResult GetProductById(int productId)
    {
        try
        {
            var product = _productService.GetProductById(productId);
            if (product != null)
            {
                string output = Tools.GetJSONfromObject(product);
                return Ok(output);
            }
            else
                return BadRequest("ID não encontrado");
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
    
    [HttpDelete(Name = "DeleteProduct")]
    public IActionResult DeleteProduct(int productId)
    {
        try
        {
            _productService.Delete(productId);
            return Ok("Produto deletado");
        }
        catch(Exception e)
        {
            return BadRequest(e);
        }
    }
    
    [HttpPost(Name ="SetProductCategories")]
    public IActionResult SetProductCategories(Product product)
    {
        try
        {
            _productService.SetProductCategories(product);
            string output = Tools.GetJSONfromObject(product);
            return Ok(output);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
    
    [HttpPost(Name ="UpdateProduct")]
    public IActionResult UpdateProduct(Product product)
    {
        try
        {
            _productService.Update(product);
            string output = Tools.GetJSONfromObject(product);
            return Ok(output);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
    
    [HttpPost(Name = "AddProduct")]
    public IActionResult AddProduct(Product product)
    {
        try
        {
            _productService.Add(product);
            string output = Tools.GetJSONfromObject(product);
            return Ok(output);
        }
        catch(Exception e)
        {
            return BadRequest(e);
        }
       
    }
}