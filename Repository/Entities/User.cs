using Microsoft.AspNetCore.Identity;

namespace Repository.Entities;

public class User : IdentityUser<int>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Source { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }            
    
    // Navigation properties
    public ICollection<Order> Orders{ get; set; }
    
}