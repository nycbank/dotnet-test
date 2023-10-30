namespace NycBank.Models
{
    public class ProdutoCategoria
    {
       
            public int ProdutoId { get; set; }
            public Produtos Produto { get; set; }
            public int CategoriaId { get; set; }
            public Categoria Categoria { get; set; }
        
    }
}
