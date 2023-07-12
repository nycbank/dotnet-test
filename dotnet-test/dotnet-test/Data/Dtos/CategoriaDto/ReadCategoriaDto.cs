using dotnet_test.Models;

namespace dotnet_test.Data.Dtos.CategoriaDto;

public class ReadCategoriaDto
{
    public int id { get; set; }
    public string nome { get; set; }
    public List<Produtos> ProdutosList { get; set; }
}