using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NycBank.Models
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

        public List<Produtos> Produtos { get; set; }
    }

}
