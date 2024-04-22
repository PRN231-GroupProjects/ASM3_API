namespace Repository.Entities;

public class Order : BaseEntity
{
    public int MemberId { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime RequiredDate{ get; set; }
    public DateTime ShippedDate { get; set; }
    public double Freight{ get; set; }   
        
    // Navigation properties
    public User User { get; set; }
    public ICollection<OrderDetail> OrderDetails{ get; set; }
}