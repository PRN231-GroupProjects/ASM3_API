using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Entities;

namespace Repository.Persistence.Configurations;

public class OrderDetailConfigurations : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.HasKey(x => new { x.OrderId, x.ProductId});        

        builder.HasOne(x => x.Order)
            .WithMany(x => x.OrderDetails)
            .IsRequired()
            .HasForeignKey(x => x.OrderId);


        builder.HasOne(x => x.Product)
             .WithMany(x => x.OrderDetails)
             .IsRequired()
             .HasForeignKey(x => x.ProductId);

        builder.Property(x => x.OrderId).ValueGeneratedNever();
        builder.Property(x => x.ProductId).ValueGeneratedNever();
        builder.Property(x => x.UnitPrice).IsRequired();
        builder.Property(x => x.Quantity).IsRequired();
        builder.Property(x => x.Discount).IsRequired();
    }
}