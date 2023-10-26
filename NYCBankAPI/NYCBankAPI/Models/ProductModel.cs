﻿using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NYCBankAPI.Models;

public class ProductModel
{
    public ProductModel()
    {
        Categories = new Collection<CategoryModel>();
    }

    public int ProductId { get; set; }
    public string? Name { get; set; }

    public decimal Price { get; set; }


    public int CategoryId { get; set; }

    [JsonIgnore]
    public ICollection<CategoryModel>? Categories { get; set; }

}