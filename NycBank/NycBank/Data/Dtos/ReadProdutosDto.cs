using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NycBank.Data.Dtos
{
    public class ReadProdutosDto
    {
       
        public int ID { get; set; }
     
        public string Nome { get; set; }
      
        public double Preco { get; set; }
    }
}
