namespace Repository.Models;

public class Product
{
    public Product(int id,string name, double price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public Product()
    {
        
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    
    public IEnumerable<Category> Categories { get; set; }
}