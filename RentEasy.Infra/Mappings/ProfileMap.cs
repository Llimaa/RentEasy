using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentEasy.Domain.Entities;

namespace RentEasy.Infra.Mappings
{
    public class ProfileMap : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("Profile");
            builder.HasKey(h => h.Id);
            builder.Property(e => e.Name).HasMaxLength(300).HasColumnType("varchar(300)").IsRequired();
            builder.Property(e => e.Phone).HasColumnType("varchar(30)").IsRequired();

            builder.OwnsOne(m => m.Address, a =>
              {
                  a.Property(p => p.Street).HasMaxLength(100).HasColumnType("varchar(100)").HasColumnName("Street").IsRequired();
                  a.Property(p => p.Number).HasMaxLength(10).HasColumnType("varchar(10)").HasColumnName("HouseNumber").IsRequired();
                  a.Property(p => p.Neighborhood).HasMaxLength(100).HasColumnType("varchar(100)").HasColumnName("Neighborhood").IsRequired();
                  a.Property(p => p.City).HasMaxLength(50).HasColumnType("varchar(50)").HasColumnName("City").IsRequired();
                  a.Property(p => p.State).HasMaxLength(50).HasColumnType("varchar(50)").HasColumnName("State").HasColumnName("State").IsRequired();
                  a.Property(p => p.ZipCode).HasMaxLength(10).HasColumnType("char(10)").HasColumnName("ZipCode").IsRequired();
              });

            builder.HasMany(e => e.Houses).WithOne(e => e.Profile).HasForeignKey(e => e.ProfileId).IsRequired();
            builder.Property(e => e.IdUser).HasColumnType("uniqueidentifier").IsRequired();
            builder.HasOne(e => e.User).WithOne(e => e.Profile).HasForeignKey<Profile>(e => e.IdUser).IsRequired(true);
        }
    }
}
