using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NycbankAPI.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        [Column]
        [Display(Name = "Codigo")]
        public int Id { get; set; }
        [Column]
        public string Nome { get; set; }

        public ICollection<CategoriaProduto> Produtos { get; set; }
    }
}
