using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_test.Models;

namespace dotnet_test.Services.ProductsService
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product? GetProduct(int id);
        List<Product> AddProduct(Product product);
        List<Product>? UpdateProduct(int id, Product product);
        List<Product>? DeleteProduct(int id);
    }
}
