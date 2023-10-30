using System;
using System.ComponentModel.DataAnnotations;
namespace NYCBank_API.Models;

public class Categoria
{
	[Key]
	[Required]
	public int Id { get; set; }

	[Required(ErrorMessage = "O nome da categoria é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O nome da categoria não pode exceder 50 caracteres")]
    public string Nome { get; set; }

    public virtual ICollection<ProdutoCategoria> ProdutoCategorias { get; set; }

}

