using Microsoft.EntityFrameworkCore;
using RentEasy.Domain.Entities;

namespace RentEasy.Infra.Contexts
{
    public partial class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
             : base(options)
        { }

        public DbSet<House> Houses { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
