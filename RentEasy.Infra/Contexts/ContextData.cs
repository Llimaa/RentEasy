using Microsoft.EntityFrameworkCore;
using RentEasy.Infra.Mappings;

namespace RentEasy.Infra.Contexts
{
    public partial class Context
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new HouseMap());
            modelBuilder.ApplyConfiguration(new PhotoMap());
            modelBuilder.ApplyConfiguration(new ProfileMap());
            modelBuilder.ApplyConfiguration(new TenantMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}
