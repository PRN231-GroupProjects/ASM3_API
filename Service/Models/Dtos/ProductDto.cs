using AutoMapper;
using Repository.Entities;
using Service.Common.Mapping;

namespace Service.Models.Dtos;

public class ProductDto : BaseDto, IMapFrom<Product>
{
    public int CategoryId { get; set; }
    public string ProductName { get; set; } = null!;
    public double Weight { get; set; }
    public double UnitPrice { get; set; }
    public int UnitInStock { get; set; }
    public CategoryDto Category { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.CategoryId,
                opt => opt.MapFrom(src => src.Category.Id));
    }
}