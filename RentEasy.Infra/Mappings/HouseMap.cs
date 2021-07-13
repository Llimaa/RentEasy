using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentEasy.Domain.Entities;

namespace RentEasy.Infra.Mappings
{
    public class HouseMap : IEntityTypeConfiguration<House>
    {
        public void Configure(EntityTypeBuilder<House> builder)
        {
            builder.ToTable("House");
            builder.HasKey(h => h.Id);
            builder.Property(e => e.Descricao).HasMaxLength(1000).HasColumnType("varchar(1000)").IsRequired();
            builder.Property(e => e.Status).HasColumnType("int").IsRequired();
            builder.Property(e => e.RentAmount).HasColumnType("decimal").IsRequired();

            builder.OwnsOne(m => m.Address, a =>
            {
                a.Property(p => p.Street).HasMaxLength(100).HasColumnType("varchar(100)").HasColumnName("Street").IsRequired();
                a.Property(p => p.Number).HasMaxLength(10).HasColumnType("varchar(10)").HasColumnName("HouseNumber").IsRequired();
                a.Property(p => p.Neighborhood).HasMaxLength(100).HasColumnType("varchar(100)").HasColumnName("Neighborhood").IsRequired();
                a.Property(p => p.City).HasMaxLength(50).HasColumnType("varchar(50)").HasColumnName("City").IsRequired();
                a.Property(p => p.State).HasMaxLength(50).HasColumnType("varchar(50)").HasColumnName("State").HasColumnName("State").IsRequired();
                a.Property(p => p.ZipCode).HasMaxLength(10).HasColumnType("char(10)").HasColumnName("ZipCode").IsRequired();
            });

            builder.Property(e => e.ProfileId).HasColumnType("uniqueidentifier").IsRequired();
            builder.HasOne(e => e.Profile).WithMany(e => e.Houses).HasForeignKey(e => e.ProfileId).IsRequired(true);

        }
    }
}
