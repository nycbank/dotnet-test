using Repository.Interfaces;
using Repository.Models;
using Service.Interfaces;

namespace Service.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IProductRepository _productRepository;
    private readonly IProductCategoryRepository _productCategoryRepository;
    
    public CategoryService(ICategoryRepository categoryRepository, IProductRepository productRepository, IProductCategoryRepository productCategoryRepository)
    {
        _categoryRepository = categoryRepository;
        _productRepository = productRepository;
        _productCategoryRepository = productCategoryRepository;
    }
    public void Add(Category category)
    {
        category.Id = 0;
        _categoryRepository.Add(category);
    }

    public void Delete(int categoryId)
    {
        _productCategoryRepository.DeleteByCategoryId(categoryId);
        _categoryRepository.DeleteById(categoryId);
    }

    public void Update(Category category)
    {
        _categoryRepository.Update(category);
    }

    public Category GetCategoryById(int categoryId)
    {
        var category =  _categoryRepository.GetCategoryById(categoryId);
        if (category != null)
        {
            category.Products = GetCategoryProducts(categoryId);
        }
        return category;
    }

    public IEnumerable<Category> GetAllCategories()
    {
        var categories =  _categoryRepository.GetCategories();
        foreach (var category in categories)
        {
            category.Products = GetCategoryProducts(category.Id);
        }
        return categories;
    }
    
    private List<Product> GetCategoryProducts(int categoryId)
    {
        var categoryProducts =  _productCategoryRepository.GetByCategoryId(categoryId);
        var products = categoryProducts
            .Select(productCategory => _productRepository
                .GetProductById(productCategory.ProductId)).ToList();
        return products;
    }
}