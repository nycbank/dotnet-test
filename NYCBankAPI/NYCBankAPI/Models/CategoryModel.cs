using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace NYCBankAPI.Models;

public class CategoryModel
{

    public CategoryModel()
    {
        Products = new Collection<ProductModel>();
    }
    public int CategoryId { get; set; }
    public string? Name { get; set; }

    [JsonIgnore]
    public ICollection<ProductModel>? Products { get; set; }

}
