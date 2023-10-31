using System.ComponentModel.DataAnnotations;

namespace NycbankAPI.Data.Dto
{
    public class CreateProdutosDto
    {


        [Required(ErrorMessage = "O campo nome é obrigatorio")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo preço é obrigatorio")]
        public double Preco { get; set; }
    }
}
