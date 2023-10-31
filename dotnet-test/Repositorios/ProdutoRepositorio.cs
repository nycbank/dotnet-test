using dotnet_test.Data;
using dotnet_test.Models;
using dotnet_test.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dotnet_test.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly TestDBContext _dbcontext;

        public ProdutoRepositorio(TestDBContext testDBContext)
        {
            _dbcontext= testDBContext;
        }
        public async Task<Produto> BuscarPorId(int id)
        {
            return await _dbcontext.Produtos.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Produto>> BuscarTodosProdutos()
        {
            return await _dbcontext.Produtos.ToListAsync();
        }
        public async Task<Produto> Adicionar(Produto produto)
        {
            await _dbcontext.Produtos.AddAsync(produto);
            await _dbcontext.SaveChangesAsync();

            return produto;
        }
        public async Task<Produto> Atualizar(Produto produto, int id)
        {
           Produto produtoPorId = await BuscarPorId(id);

            if(produtoPorId == null)
            {
                throw new Exception("Não foi encontrado um uxuáriom para o ID: " + id + ".");
            }
            produtoPorId.Nome = produto.Nome;
            produtoPorId.Preco = produto.Preco;
            produtoPorId.Categorias= produto.Categorias;

            _dbcontext.Produtos.Update(produtoPorId);
            await _dbcontext.SaveChangesAsync();

            return produtoPorId;
        }  
        public async Task<bool> Apagar(int id)
        {
            Produto produtoPorID = await BuscarPorId(id);

            if (produtoPorID == null)
            {
                throw new Exception("Não foi encontrado um uxuáriom para o ID:" + id + ".");
            }

            _dbcontext.Produtos.Remove(produtoPorID);
            await _dbcontext.SaveChangesAsync();

            return true;

        }


    }
}
