using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Entities;
using Service.Common.Mapping;

namespace Service.Models.Dtos;

public class MemberDto : BaseDto, IMapFrom<Member>
{
    public string Email { get; set; } = null!;
    public string CompanyName { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Password { get; set; } = null!;
    public int Role { get; set; }
}