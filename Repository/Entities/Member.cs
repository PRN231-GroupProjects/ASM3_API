namespace Repository.Entities;

public class Member : BaseEntity
{
    public string Email { get; set; } = null!;
    public string CompanyName { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int Role { get; set; }
    
    // Navigation properties
    public ICollection<Order> Orders { get; set; } = new List<Order>();
}