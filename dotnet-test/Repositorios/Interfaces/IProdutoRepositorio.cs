using dotnet_test.Models;

namespace dotnet_test.Repositorios.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<Produto>> BuscarTodosProdutos();
        Task<Produto> BuscarPorId(int id);
        Task<Produto> Atualizar(Produto produto, int id);
        Task<bool> Apagar(int id);
        Produto Adicionar(Produto produto);
    }
}
