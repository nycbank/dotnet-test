using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_test.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Nome { get; set; }  = string.Empty;

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
