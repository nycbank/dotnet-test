namespace dotnet_test.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public List<Categoria> Categorias { get; set; } 

    }
}
