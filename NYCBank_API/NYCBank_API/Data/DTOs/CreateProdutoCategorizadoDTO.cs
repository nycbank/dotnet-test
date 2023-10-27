using System;
using System.ComponentModel.DataAnnotations;

namespace NYCBank_API.Data.DTOs
{
	public class CreateProdutoCategorizadoDTO
	{
        [Key]
        [Required]
        public int Id { get; set; }
    }
}

