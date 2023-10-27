using System;
namespace NYCBank_API.Data.DTOs;

public class ReadProdutoCategoriaDTO
{
    public int Id { get; set; }
    public int ProdutoId { get; set; }
    public int CategoriaId { get; set; }
    public string NomeProduto { get; set; }
    public string NomeCategoria { get; set; }
}

