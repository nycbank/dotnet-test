using System.ComponentModel.DataAnnotations;

namespace NycbankAPI.Data.Dto
{
    public class UpdateCategoriaDto


    {
        [Required(ErrorMessage = "O campo Nome é obrigatorio")]
        public string Nome { get; set; }

    }
}
