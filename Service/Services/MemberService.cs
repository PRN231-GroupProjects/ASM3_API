using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Interfaces;
using Service.Extensions;
using Service.Interfaces;
using Service.Models;
using Service.Models.Dtos;
using Service.Models.Payload.Requests.Member;

namespace Service.Services;

public class MemberService : IMemberService
{
    private readonly IUnitOfWork _uow;
    private readonly IRepository<Member> _memberRepository;
    private readonly IMapper _mapper;

    public MemberService(IUnitOfWork uow, IMapper mapper)
    {
        _uow = uow;
        _memberRepository = _uow.GetRequiredRepository<Member>();
        _mapper = mapper;
    }

    public async Task<PaginatedList<MemberDto>> GetMembers(GetMembersRequest request)
    {
        var members = _memberRepository
            .GetAll()
            .AsQueryable();

        return await members
            .ListPaginateWithSortAsync<Member, MemberDto>(
                request.Page, 
                request.Size, 
                request.SortBy, 
                request.SortOrder, 
                _mapper.ConfigurationProvider);
    }

    public async Task<MemberDto> GetMemberById(int id)
    {
        var member = await _memberRepository.GetByIdAsync(id);

        if (member is null)
        {
            throw new KeyNotFoundException("Product does not exist!");
        }

        var result = _mapper.Map<MemberDto>(member);
        return result;
    }

    public async Task<MemberDto> CreateMember(CreateMemberRequest request)
    {
        var member = await _memberRepository.FindByCondition(x => x.Email == request.Email).FirstOrDefaultAsync();
        if (member is not null)
        {
            throw new InvalidOperationException("This email already exist!");
        }

        if (request.Email.Length > 320)
        {
            throw new InvalidOperationException("Email is too long");
        }

        var entity = new Member
        {
            City = request.City,
            Country = request.Country,
            Email = request.Email,
            Password = request.Password,
            CompanyName = request.CompanyName,
            Role = request.Role
        };
        
        var result = await _memberRepository.AddAsync(entity);
        await _uow.CommitAsync();

        return _mapper.Map<MemberDto>(result);
    }

    public async Task<MemberDto> UpdateMember(int id, UpdateMemberRequest request)
    {
        var member = await _memberRepository.GetByIdAsync(id);
        if (member is null)
        {
            throw new KeyNotFoundException("Member does not exist!");
        }

        member.CompanyName = request.CompanyName;
        member.City = request.City;
        member.Password = request.Password;
        member.Country = request.Country;
        member.Role = request.Role;

        var result = _memberRepository.Update(member);
        await _uow.CommitAsync();
        return _mapper.Map<MemberDto>(result);
    }

    public async Task<MemberDto> DeleteMember(int id)
    {
        var member = await _memberRepository.GetByIdAsync(id);
        if (member is null)
        {
            throw new KeyNotFoundException("Member does not exist!");
        }

        var result = _memberRepository.Remove(id);
        await _uow.CommitAsync();
        return _mapper.Map<MemberDto>(result);
    }
}