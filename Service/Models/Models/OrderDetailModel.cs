using AutoMapper;
using Repository.Entities;
using Service.Common.Mapping;

namespace Service.Models.Models;

public class OrderDetailModel : BaseModel, IMapFrom<Order>
{
    //public string Title { get; set; }
    //public string Type { get; set; }
    //public int PublisherId { get; set; }
    //public double Price { get; set; }
    //public double Advance { get; set; }
    //public double Royalty { get; set; }
    //public double ytdSales { get; set; }
    //public string Notes { get; set; }
    //public DateTime PublishedDate { get; set; }
    
    //// Navigation properties
    //public ProductModel Publisher { get; set; }
    //public List<OrderModel> BookAuthors { get; set; }
    
    //public void Mapping(Profile profile)
    //{
    //    profile.CreateMap<Order, OrderDetailModel>()
    //        .ForMember(dest => dest.PublisherId,
    //            opt => opt.MapFrom(src => src.Publisher.Id));
    //}
}