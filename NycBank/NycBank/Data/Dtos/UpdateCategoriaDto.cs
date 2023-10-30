using System.ComponentModel.DataAnnotations;

namespace NycBank.Data.Dtos
{
    public class UpdateCategoriaDto


    {
        [Required(ErrorMessage = "O campo Nome é obrigatorio")]
        public string Nome { get; set; }
        
    }
}
