using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace dotnet_test.Models;

public class Categorias
{
    [Key]
    public int id { get; set; }
    public string nome { get; set; }
    [JsonIgnore]
    public virtual ICollection<Produtos> Produtos { get; set; }

    public Categorias()
    {
        Produtos = new List<Produtos>();
    }
}