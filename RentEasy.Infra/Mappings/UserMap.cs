using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentEasy.Domain.Entities;

namespace RentEasy.Infra.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.ToTable("User");
            builder.HasKey(h => h.Id);
            builder.Property(e => e.Role).HasMaxLength(300).HasColumnType("varchar(100)").IsRequired();
            builder.Property(e => e.Status).HasColumnType("int").IsRequired();
            builder.OwnsOne(m => m.Email, a =>
            {
                a.Property(p => p.Address).HasMaxLength(100).HasColumnType("varchar(100)").HasColumnName("Email").IsRequired();
            });
            builder.OwnsOne(m => m.Password, a =>
            {
                a.Property(p => p.Value).HasMaxLength(50).HasColumnType("varchar(50)").HasColumnName("Password").IsRequired();
            });
        }
    }
}
