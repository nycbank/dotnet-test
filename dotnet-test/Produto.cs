namespace dotnet_test
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public List<Categoria> Produtos { get; set; }

    }
}
