using Service.Models;
using Service.Models.Dtos;
using Service.Models.Payload.Requests.Member;

namespace Service.Interfaces;

public interface IMemberService
{
    Task<PaginatedList<MemberDto>> GetMembers(GetMembersRequest request);
    Task<MemberDto> GetMemberById(int id);
    Task<MemberDto> CreateMember(CreateMemberRequest request);
    Task<MemberDto> UpdateMember(int id, UpdateMemberRequest request);
    Task<MemberDto> DeleteMember(int id);
}