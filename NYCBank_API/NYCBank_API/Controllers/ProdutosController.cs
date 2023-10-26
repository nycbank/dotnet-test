using System;
using Microsoft.AspNetCore.Mvc;
using NYCBank_API.Models;

namespace NYCBank_API.Controllers;

[ApiController]
[Route("[controller]")]

public class ProdutosController : ControllerBase
{
	private static List<Produto> produtos = new List<Produto>();

	[HttpPost]
	public void AdicionaProduto([FromBody] Produto produto)
	{
            produtos.Add(produto);
	}
}

