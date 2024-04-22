using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Entities;

namespace Repository.Persistence.Configurations;

public class ProductConfigurations : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();      
        builder.Property(x => x.CategoryId).IsRequired();
        builder.Property(x => x.ProductName).IsRequired();
        builder.Property(x => x.Weight).IsRequired();
        builder.Property(x => x.UnitPrice).IsRequired();
        builder.Property(x => x.UnitsInStock).IsRequired();
    }
}