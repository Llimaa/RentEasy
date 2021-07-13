using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentEasy.Domain.Entities;
using System;

namespace RentEasy.Infra.Mappings
{
    public class TenantMap : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.ToTable("Tenant");
            builder.HasKey(h => h.Id);
            builder.Property(e => e.Name).HasMaxLength(300).HasColumnType("varchar(300)").IsRequired();
            builder.Property(e => e.Phone).HasMaxLength(30).HasColumnType("varchar(30)").IsRequired();
            builder.Property(e => e.StatusPayment).HasColumnType("int").IsRequired();
            builder.Property(e => e.StatusTenant).HasColumnType("int").IsRequired();

            builder.Property(e => e.PayDay).HasColumnType("int").IsRequired();
            builder.Property(e => e.DateStart).HasColumnType("datetime").IsRequired();
            builder.Property(e => e.DateExit).HasColumnType("datetime").IsRequired();
            builder.Property(e => e.LastPaymentDate).HasColumnType("datetime").IsRequired();

            builder.Property(e => e.HouseId).HasColumnType("uniqueidentifier").IsRequired();
            builder.HasOne(e => e.House).WithOne(e => e.Tenant).HasForeignKey<Tenant>(e => e.HouseId).IsRequired(true);
        }
    }
}
