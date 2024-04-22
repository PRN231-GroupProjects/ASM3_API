using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Entities;

namespace Repository.Persistence.Configurations;

public class OrderConfigurations : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(x => x.Id);    
        builder.Property(x => x.MemberId).IsRequired();
        builder.Property(x => x.OrderDate).IsRequired();
        builder.Property(x => x.RequiredDate).IsRequired();
        builder.Property(x => x.ShippedDate).IsRequired();
        builder.Property(x => x.Freight).IsRequired();        
    }
}