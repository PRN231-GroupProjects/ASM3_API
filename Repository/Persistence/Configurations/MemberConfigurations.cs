using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Entities;

namespace Repository.Persistence.Configurations;

public class MemberConfigurations : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.CompanyName).IsRequired();
        builder.Property(x => x.City).IsRequired();
        builder.Property(x => x.Country).IsRequired();
        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.Role).IsRequired();
    }
}