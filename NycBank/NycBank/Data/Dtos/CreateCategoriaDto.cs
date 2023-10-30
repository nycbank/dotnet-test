using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NycBank.Data.Dtos
{
    public class CreateCategoriaDto
    {
        [Required(ErrorMessage ="O campo nome é obrigatorio")]
        public string Nome { get; set; }
    }
}
