using Repository.Entities;
using Service.Common.Mapping;

namespace Service.Models.Models;

public class ProductModel : BaseModel, IMapFrom<OrderDetail>
{
    //public string Name { get; set; }
    //public string City { get; set; }
    //public string State { get; set; }
    //public string Country { get; set; }
    
    //// Navigations
    //public ICollection<UserModel> Users { get; set; }
    //public ICollection<OrderDetailModel> Books { get; set; }
}
