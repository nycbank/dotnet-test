using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace dotnet_test.Models;

public class Produtos
{
    [Key]
    public int id { get; set; }
    public string nome { get; set; }
    public decimal preco { get; set; }
    [JsonIgnore]
    public virtual ICollection<Categorias> Categorias { get; set; }

    public Produtos()
    {
        Categorias = new List<Categorias>();
    }
}