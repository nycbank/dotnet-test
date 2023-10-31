namespace NycbankAPI.Models
{
    public class CategoriaProduto
    {
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public int ProdutoId { get; set; }
        public Produtos Produto { get; set; }
    }
}
