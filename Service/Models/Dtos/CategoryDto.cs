using Repository.Entities;
using Service.Common.Mapping;

namespace Service.Models.Dtos;

public class CategoryDto : BaseDto, IMapFrom<Category>
{
    public string Name { get; set; }
}