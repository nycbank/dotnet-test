using System;
using System.ComponentModel.DataAnnotations;

namespace NYCBank_API.Data.DTOs;

public class CreateProdutoDTO
{

    [Required(ErrorMessage = "O nome do produto é obrigatório.")]
    [StringLength(50, ErrorMessage = "O nome do produto não pode exceder 50 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O preço do produto é obrigatório.")]
    [Range(0.01, 10000, ErrorMessage = "O preço deve ser maior que R$0.01 e menor que R$10.000")]
    public decimal Preco { get; set; }

}

