using System.ComponentModel.DataAnnotations;

namespace dotnet_test.Models;

public class Categorias
{
    [Key]
    public int id { get; set; }
    public string nome { get; set; }
    public List<Produtos> Produtos { get; set; }
}