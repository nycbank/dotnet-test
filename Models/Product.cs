using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace dotnet_test.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Nome { get; set; }  = string.Empty;
        public decimal Preco { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
  }
}
