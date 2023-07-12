using dotnet_test.Models;

namespace dotnet_test.Data.Dtos.ProdutoDto;

public class ReadProdutoDto
{
    public int id { get; set; }
    public string nome { get; set; }
    public decimal preco { get; set; }
    public virtual ICollection<Categorias> Categorias { get; set; }
}