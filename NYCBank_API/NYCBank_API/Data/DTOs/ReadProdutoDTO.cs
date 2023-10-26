using System;
using System.ComponentModel.DataAnnotations;

namespace NYCBank_API.Data.DTOs;

public class ReadProdutoDTO
{

    public string Nome { get; set; }

    public decimal Preco { get; set; }

    public string Categoria { get; set; }
}

