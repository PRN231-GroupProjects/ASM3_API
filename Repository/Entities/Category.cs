namespace Repository.Entities;

public class Category : BaseEntity
{
    public string CategoryName { get; set; }
    
    // Navigation properties
    public ICollection<Product> Products{ get; set; }
}