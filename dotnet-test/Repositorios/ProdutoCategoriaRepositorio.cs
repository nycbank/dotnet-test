using dotnet_test.Data;
using dotnet_test.Models;
using dotnet_test.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace dotnet_test.Repositorios
{
    public class ProdutoCategoriaRepositorio:ControllerBase
    {
        private readonly TestDBContext _dbContext;

        public ProdutoCategoriaRepositorio(TestDBContext testDBContext)
        {
            _dbContext = testDBContext;
        }

        public async Task<bool> AssociarProdutoCategoria(int produtoId, int categoriaId)
        {
            var produto = await _dbContext.Produtos.FindAsync(produtoId);
            var categoria = await _dbContext.Categorias.FindAsync(categoriaId);

            if(produto != null && categoria != null)
            {
                var produtoCategoria = new ProdutoCategoria
                {
                    ProdutoId = produtoId,
                    CategoriaId = categoriaId
                };

                _dbContext.ProdutoCategoria.Add(produtoCategoria);
            }

            return true;
        }
                
    }
}
