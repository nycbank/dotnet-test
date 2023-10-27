using Microsoft.EntityFrameworkCore;
using NYCBankAPI.Data;
using NYCBankAPI.Models;
using NYCBankAPI.Repository.Interfaces;

namespace NYCBankAPI.Repository;

public class ProductRepository : IProductRepository
{

    private readonly NycBankDBContext _dbContext;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ProductCategoryModel _productCategoryModel;
    public ProductRepository(NycBankDBContext nycBankDBContext, ICategoryRepository categoryRepository)
    {
        _dbContext = nycBankDBContext;
        _categoryRepository = categoryRepository;
    }

    public async Task<List<ProductModel>> GetAllProducts()
    {
        return await _dbContext.Products.ToListAsync();
    }

    public async Task<ProductModel> GetProductById(int id)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(x => x.ProductId == id);
    }

    public async Task<(ProductModel?, string)> AddProduct(ProductModel products)
    {
        var categories = await _categoryRepository.GetAllCategories();
        await _dbContext.Products.AddAsync(products);
        await _dbContext.SaveChangesAsync();

        foreach (var item in products.CategoryId)
        {
            var categoryId = await _categoryRepository.GetCategoryById(item);

            if (categoryId is null)
            {
                return (null, "Category not found");
            }

            if (categories.Select(c=>c.CategoryId).Contains(item))
            {
                var productCategoryModel = new ProductCategoryModel() { ProductId = products.ProductId, CategoryId = item };
                await _dbContext.ProductCategory.AddAsync(productCategoryModel);
                await _dbContext.SaveChangesAsync();
            }
        }

        return (products, "");
    }
    public async Task<ProductModel> UpdateProduct(ProductModel product, int id)
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
