namespace Service.Models.Payload.Requests.Member;

public class LoginRequest
{
    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}