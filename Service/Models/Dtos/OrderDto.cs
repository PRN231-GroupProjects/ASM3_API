using AutoMapper;
using Repository.Entities;
using Service.Common.Mapping;

namespace Service.Models.Dtos;

public class OrderDto : BaseDto, IMapFrom<Order>
{
    public int MemberId { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime RequiredDate { get; set; }
    public DateTime ShippedDate { get; set; }
    public double Freight { get; set; }
    public MemberDto Member { get; set; }
    public List<OrderDetailDto> OrderDetails { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.MemberId,
                opt => opt.MapFrom(src => src.Member.Id));
    }
}