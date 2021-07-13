using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentEasy.Domain.Entities;

namespace RentEasy.Infra.Mappings
{
    public class PhotoMap : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.ToTable("Photo");
            builder.HasKey(h => h.Id);
            builder.Property(e => e.Data).HasMaxLength(1000).IsRequired();
            builder.Property(e => e.Format).HasColumnType("varchar(20)").IsRequired();
            builder.Property(e => e.HouseId).HasColumnType("uniqueidentifier").IsRequired();

            builder.HasOne(e => e.House).WithMany(e => e.Photos).HasForeignKey(e => e.HouseId).IsRequired();
        }
    }
}
