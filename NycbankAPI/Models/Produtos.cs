using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace NycbankAPI.Models
{
    [Table("Produtos")]
    public class Produtos
    {
        [Key]
        [Column]
        [Display(Name = "Codigo")]
        public int ID { get; set; }
        [Column]
        public string Nome { get; set; }
        [Column]
        public double Preco { get; set; }
        public ICollection<CategoriaProduto> Categorias { get; set; }
    }
}
