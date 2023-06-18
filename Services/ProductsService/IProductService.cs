using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_test.Models;

namespace dotnet_test.Services.ProductsService
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProduct(int id);
        Task<List<Product>> AddProduct(Product product);
        Task<List<Product>> UpdateProduct(int id, Product product);
        Task<List<Product>> DeleteProduct(int id);
    }
}
