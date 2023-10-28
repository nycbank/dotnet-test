using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NycBank.Data.Dtos
{
    public class UpdateProdutosDto
    {




        [Required(ErrorMessage = "O campo nome é obrigatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo preço é obrigatorio")]
        public double Preco { get; set; }
    }
}
