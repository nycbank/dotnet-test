using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_test.Models;
using dotnet_test.Services.ProductsService;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            return productService.GetAllProducts();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var result = productService.GetProduct(id);
            if (result == null)
            {
                return NotFound("Produto não encontrado");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
            var result = productService.AddProduct(product);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Product>>> UpdateProduct(int id, Product product)
        {
            var result = productService.UpdateProduct(id, product);
            if (result == null)
            {
                return NotFound("Produto não encontrado");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            var result = productService.DeleteProduct(id);
            if (result == null)
            {
                return NotFound("Produto não encontrado");
            }
            return Ok(result);
        }
    }
}
