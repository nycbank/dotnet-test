using Repository.Interfaces;
using Repository.Models;
using Service.Interfaces;

namespace Service.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly ICategoryRepository _categoryRepository;
    public ProductService(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository, ICategoryRepository categoryRepository )
    {
        _productRepository = productRepository;
        _productCategoryRepository = productCategoryRepository;
        _categoryRepository = categoryRepository;
    }
    public void Add(Product product)
    {
        product.Id = 0;
        _productRepository.Add(product);
    }

    public void Delete(int productId)
    {
        _productCategoryRepository.DeleteByProductId(productId);
        _productRepository.DeleteById(productId);
    }

    public void Update(Product product)
    {
        _productRepository.Update(product);
    }

    public Product GetProductById(int productId)
    {
        var product =  _productRepository.GetProductById(productId);
        if (product != null)
        {
            product.Categories = GetProductCategories(productId);
        }
        return product;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        var products =  _productRepository.GetProducts();
        foreach (var product in products)
        {
            product.Categories = GetProductCategories(product.Id);

        }
        return products;
    }

    private bool CheckIfCategoryExists(Category category)
    {
       var categoryFound = _categoryRepository.GetCategoryById(category.Id);

       if (categoryFound == null)
           return false;
       
       return true;
    }
    public void SetProductCategories(Product product)
    {
        var currentProductCategories = GetProductById(product.Id).Categories;
        
        var categories = product.Categories.ToList();

        foreach (var category in categories)
        {
            if (!CheckIfCategoryExists(category))
                throw new Exception("Não é possível atribuir um produto" +
                                    " a uma categoria não existente");
        }
        
        if (currentProductCategories != null)
        {
            var result = categories
                .Where(c => currentProductCategories
                .All(d => d.Id != c.Id));
            
            if(result.Any())
            {
                foreach (var category in result)
                {
                    _productCategoryRepository.Add(new ProductCategory
                    {
                        CategoryId = category.Id,
                        ProductId = product.Id
                    }); 
                }
            }
        }
        else
        {
            foreach (var category in categories)
            {
                _productCategoryRepository.Add(new ProductCategory
                {
                    CategoryId = category.Id,
                    ProductId = product.Id
                }); 
            }
        }
    }

    private List<Category> GetProductCategories(int productId)
    {
        var productCategories =  _productCategoryRepository.GetByProductId(productId);
        var categories = productCategories
            .Select(category => _categoryRepository
                .GetCategoryById(category.CategoryId)).ToList();
        return categories;
    }
}