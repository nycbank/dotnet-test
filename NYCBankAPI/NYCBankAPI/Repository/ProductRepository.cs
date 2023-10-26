using Microsoft.EntityFrameworkCore;
using NYCBankAPI.Data;
using NYCBankAPI.Models;
using NYCBankAPI.Repository.Interfaces;

namespace NYCBankAPI.Repository;

public class ProductRepository : IProductRepository
{

    private readonly NycBankDBContext _dbContext;
    public ProductRepository(NycBankDBContext nycBankDBContext)
    {
        _dbContext = nycBankDBContext;
    }

    public async Task<List<ProductModel>> GetAllProducts()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task<ProductModel> GetProductById(int id)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);
    }

    public async Task<ProductModel> AddProducts(ProductModel product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();

        return product;
    }
    public async Task<ProductModel> UpdateProducts(ProductModel product, int id)
    {
        var productById = await GetProductById(id);

        if (productById == null)
        {
            throw new Exception("Product not found");
        }

        productById.Name = product.Name;
        productById.Price = product.Price;

        _dbContext.Update(productById);
        await _dbContext.SaveChangesAsync();

        return productById;

    }

    public async Task<bool> DeleteProduct(int id)
    {
        var productById = await GetProductById(id);

        if (productById == null)
        {
            throw new Exception("Product not found");
        }

        _dbContext.Products.Remove(productById);
        await _dbContext.SaveChangesAsync();

        return true;
    }

}
