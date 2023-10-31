using System.ComponentModel.DataAnnotations;

namespace NycbankAPI.Models
{
    public class CategoriaProduto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public int ProdutoId { get; set; }
        public Produtos Produto { get; set; }
    }
}
