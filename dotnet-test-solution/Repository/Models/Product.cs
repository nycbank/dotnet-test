namespace Repository.Models;

public class Product
{
    public Product(string name, double price)
    {
        Name = name;
        Price = price;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    
    public IEnumerable<Category> Categories { get; set; }
}