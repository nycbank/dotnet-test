using dotnet_test.Models;

namespace dotnet_test.Repositorios.Interfaces
{
    public interface ICategoriaRepositorio
    {        
            Task<List<Categoria>> BuscarTodasCategorias();
            Task<Categoria> BuscarPorId(int id);
            Task<Categoria> Adicionar(Categoria categoria);
            Task<Categoria> Atualizar(Categoria categoria, int id);
            Task<bool> Apagar(int id);
        
    }
}
