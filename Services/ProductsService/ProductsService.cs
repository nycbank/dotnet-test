using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_test.Models;

namespace dotnet_test.Services.ProductsService
{
    public class ProductsService : IProductService
    {
        public static List<Product> products = new()
        {
            new Product() { Id = 1, Nome = "Produto 1", Preco = 10.00M },
            new Product() { Id = 2, Nome = "Produto 2", Preco = 20.00M },
            new Product() { Id = 3, Nome = "Produto 3", Preco = 30.00M },
            new Product() { Id = 4, Nome = "Produto 4", Preco = 40.00M },
            new Product() { Id = 5, Nome = "Produto 5", Preco = 50.00M },
            new Product() { Id = 6, Nome = "Produto 6", Preco = 60.00M },
            new Product() { Id = 7, Nome = "Produto 7", Preco = 70.00M },
            new Product() { Id = 8, Nome = "Produto 8", Preco = 80.00M },
            new Product() { Id = 9, Nome = "Produto 9", Preco = 90.00M },
            new Product() { Id = 10, Nome = "Produto 10", Preco = 100.00M },
        };

        public List<Product> AddProduct(Product product)
        {
            products.Add(product);
            return products;
        }

        public List<Product>? DeleteProduct(int id)
        {
            var productDelete = products.Find(product => product.Id == id);
            if (productDelete == null)
            {
                return null;
            }

            products.Remove(productDelete);
            return products;
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product? GetProduct(int id)
        {
            var productGet = products.Find(product => product.Id == id);
            return productGet == null ? null : productGet;
        }

    public List<Product>? UpdateProduct(int id, Product product)
        {
            var productUpdate = products.Find(product => product.Id == id);
            if (productUpdate == null)
            {
                return null;
            }

            productUpdate.Nome = product.Nome;
            productUpdate.Preco = product.Preco;

            return products;
        }
    }
}
