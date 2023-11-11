using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace dotnet_test.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [JsonIgnore]
        [AllowNull]
        public List<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
