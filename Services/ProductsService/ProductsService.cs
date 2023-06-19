using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_test.Data;
using dotnet_test.Models;
using Microsoft.EntityFrameworkCore;
using dotnet_test.Errors;

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
            var productDelete = await dataContext.Product.FindAsync(id) ?? throw new NotFoundException("Produto não encontrado");

            dataContext.Product.Remove(productDelete);
            await dataContext.SaveChangesAsync();

            return await dataContext.Product.ToListAsync();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await dataContext.Product.ToListAsync() ?? throw new NotFoundException("Não há produtos cadastrados");
        }

        public async Task<Product> GetProduct(int id)
        {
            return await dataContext.Product.FindAsync(id) ?? throw new NotFoundException("Produto não encontrado");
        }

    public async Task<List<Product>> UpdateProduct(int id, Product product)
        {
            var productUpdate = await dataContext.Product.FindAsync(id) ?? throw new NotFoundException("Produto não encontrado");

            productUpdate.Nome = product.Nome;
            productUpdate.Preco = product.Preco;

            await dataContext.SaveChangesAsync();

            return await dataContext.Product.ToListAsync();
        }
    }
}
