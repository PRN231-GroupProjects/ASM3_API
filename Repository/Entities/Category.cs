namespace Repository.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = null!;
    
    // Navigation properties
    public ICollection<Product> Products { get; set; } = new List<Product>();
}