namespace Service.Models.Payload.Requests.Member;

public class UpdateMemberRequest
{
    public string CompanyName { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int Role { get; set; }
}