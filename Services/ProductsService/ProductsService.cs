using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_test.Data;
using dotnet_test.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_test.Services.ProductsService
{
    public class ProductsService : IProductService
    {

    private readonly DataContext dataContext;

    public ProductsService(DataContext dataContext)
    {
        this.dataContext = dataContext;
    }

        public async Task<List<Product>> AddProduct(Product product)
        {
            dataContext.Product.Add(product);
            await dataContext.SaveChangesAsync();
            return await dataContext.Product.ToListAsync();
        }

        public async Task<List<Product>> DeleteProduct(int id)
        {
            var productDelete = await dataContext.Product.FindAsync(id);
            if (productDelete == null)
            {
                return null;
            }

            dataContext.Product.Remove(productDelete);
            await dataContext.SaveChangesAsync();

            return await dataContext.Product.ToListAsync();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await dataContext.Product.ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            var productGet = await dataContext.Product.FindAsync(id);
            return productGet == null ? null : productGet;
        }

    public async Task<List<Product>> UpdateProduct(int id, Product product)
        {
            var productUpdate = await dataContext.Product.FindAsync(id);
            if (productUpdate == null)
            {
                return null;
            }

            productUpdate.Nome = product.Nome;
            productUpdate.Preco = product.Preco;

            await dataContext.SaveChangesAsync();

            return await dataContext.Product.ToListAsync();
        }
    }
}
