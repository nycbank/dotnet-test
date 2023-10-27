using System;
using System.ComponentModel.DataAnnotations;
namespace NYCBank_API.Models;

public class ProdutoCategorizado
{
	[Key]
	[Required]
	public int Id { get; set; }
}

