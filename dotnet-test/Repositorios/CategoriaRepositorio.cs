using dotnet_test.Data;
using dotnet_test.Models;
using dotnet_test.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace dotnet_test.Repositorios

{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly TestDBContext _dbcontext;

        public CategoriaRepositorio(TestDBContext testDBContext)
        {
            _dbcontext = testDBContext;
        }
        public async Task<Categoria> BuscarPorId(int id)
        {
            return await _dbcontext.Categorias.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Categoria>> BuscarTodasCategorias()
        {
            return await _dbcontext.Categorias.ToListAsync();
        }
        public async Task<Categoria> Adicionar(Categoria categoria)
        {
            await _dbcontext.Categorias.AddAsync(categoria);
            await _dbcontext.SaveChangesAsync();

            return categoria;
        }
        public async Task<Categoria> Atualizar(Categoria categoria, int id)
        {
            Categoria categoriaPorId = await BuscarPorId(id);

            if (categoriaPorId == null)
            {
                throw new Exception("Não foi encontrado um uxuáriom para o ID: " + id + ".");
            }

            categoriaPorId.Nome = categoria.Nome;


            _dbcontext.Categorias.Update(categoriaPorId);
            await _dbcontext.SaveChangesAsync();

            return categoriaPorId;
        }
        public async Task<bool> Apagar(int id)
        {
            Categoria categoriaPorID = await BuscarPorId(id);

            if (categoriaPorID == null)
            {
                throw new Exception("Não foi encontrado um uxuáriom para o ID:" + id + ".");
            }

            _dbcontext.Categorias.Remove(categoriaPorID);
            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
