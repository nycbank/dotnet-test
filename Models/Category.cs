using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dotnet_test.Models
{
    public class Category
    {
      [Key]
        public int Id { get; set; }
        public string Nome { get; set; }  = string.Empty;

        public List<Product> Products { get; set; } = new List<Product>();
  }
}
