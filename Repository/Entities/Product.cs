namespace Repository.Entities;

public class Product : BaseEntity
{
    public int CategoryId { get; set; }
    public string ProductName { get; set; }
    public double Weight{ get; set; }
    public double UnitPrice{ get; set; }
    public int UnitsInStock{ get; set; }

    // Navigation properties
    public ICollection<OrderDetail> OrderDetails{ get; set; }
    public Category Category{ get; set; }
}