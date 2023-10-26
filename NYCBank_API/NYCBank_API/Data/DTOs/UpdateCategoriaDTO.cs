using System;
using System.ComponentModel.DataAnnotations;

namespace NYCBank_API.Data.DTOs;

public class UpdateCategoriaDTO
{

    [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O nome da categoria não pode exceder 50 caracteres")]
    public string Nome { get; set; }

}

