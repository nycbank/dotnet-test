﻿using NYCBankAPI.Models;

namespace NYCBankAPI.Repository.Interfaces;

public interface IProductRepository
{
    Task<List<ProductModel>> GetAllProducts();
    Task<ProductModel> GetProductById(int id);
    Task<(ProductModel?, string)> AddProduct(ProductModel product);
    Task<ProductModel> UpdateProduct(ProductModel product, int id);
    Task<bool> DeleteProduct(int id);
}
