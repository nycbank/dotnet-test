using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_test.Models
{
    public class ProductCategory
    {
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
  }
}
