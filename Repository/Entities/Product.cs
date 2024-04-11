namespace Repository.Entities;

public class Product : BaseEntity
{
    public int CategoryId { get; set; }
    public string ProductName { get; set; } = null!;
    public double Weight { get; set; }
    public double UnitPrice { get; set; }
    public int UnitInStock { get; set; }
    
    // Navigation properties
    public Category Category { get; set; } = null!;
    public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}