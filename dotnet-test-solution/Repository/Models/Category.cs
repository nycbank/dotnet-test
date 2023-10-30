namespace Repository.Models;

public class Category
{
    public Category(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    
    public IEnumerable<Product> Products { get; set; }
}