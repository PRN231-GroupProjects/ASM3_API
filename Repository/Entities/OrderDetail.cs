namespace Repository.Entities;

public class OrderDetail : BaseEntity
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public double UnitPrice { get; set; }
    public int Quantity { get; set; }
    public double Discount { get; set; }
    
    // Navigation properties
    public Product Product { get; set; } = null!;
    public Order Order { get; set; } = null!;
}