using AutoMapper;
using Repository.Entities;
using Service.Common.Mapping;

namespace Service.Models.Dtos;

public class OrderDetailDto : BaseDto, IMapFrom<OrderDetail>
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public double UnitPrice { get; set; }
    public int Quantity { get; set; }
    public double Discount { get; set; }
    
    public ProductDto Product { get; set; } = null!;
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<OrderDetail, OrderDetailDto>()
            .ForMember(dest => dest.OrderId,
                opt => opt.MapFrom(src => src.Order.Id))
            .ForMember(dest => dest.ProductId, 
                opt => opt.MapFrom(src => src.Product.Id));
    }
}