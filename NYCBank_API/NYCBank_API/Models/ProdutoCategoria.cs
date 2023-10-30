using System;
using System.ComponentModel.DataAnnotations;
namespace NYCBank_API.Models;

public class ProdutoCategoria
{
    [Key]
    [Required]
    public int Id { get; set; }

    public int ProdutoId { get; set; }
    public virtual Produto Produto { get; set; }

    public int CategoriaId { get; set; }
    public virtual Categoria Categoria { get; set; }
}

