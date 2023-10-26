using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using NYCBankAPI.Models;
using NYCBankAPI.Repository.Interfaces;

namespace NYCBankAPI.Controllers;

[Route("/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;
    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductModel>>> GetAllProducts()
    {
        List<ProductModel> products = await _productRepository.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductModel>> GetProductsById(int id)
    {
        ProductModel product = await _productRepository.GetProductById(id);
        return Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult<ProductModel>> AddProduct([FromBody] ProductModel productModel)
    {
        ProductModel product = await _productRepository.AddProduct(productModel);
        return Ok(product);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductModel>> UpdateProduct([FromBody] ProductModel productModel, int id)
    {
        productModel.ProductId = id;
        ProductModel product = await _productRepository.UpdateProduct(productModel, id);
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ProductModel>> DelectProduct(int id)
    {
        bool response = await _productRepository.DeleteProduct(id);
        return Ok(response);
    }
}
