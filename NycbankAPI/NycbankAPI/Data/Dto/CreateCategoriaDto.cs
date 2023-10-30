namespace NycbankAPI.Data.Dto
{
    public class CreateCategoriaDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatorio")]
        public string Nome { get; set; }
    }
}
