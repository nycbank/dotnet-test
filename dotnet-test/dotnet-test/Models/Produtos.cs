using System.ComponentModel.DataAnnotations;

namespace dotnet_test.Models;

public class Produtos
{
    [Key]
    public int id { get; set; }
    public string nome { get; set; }
    public decimal preco { get; set; }
    public List<Categorias> Categorias { get; set; }
}