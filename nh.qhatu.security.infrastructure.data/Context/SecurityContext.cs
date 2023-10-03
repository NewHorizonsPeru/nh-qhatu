using Microsoft.EntityFrameworkCore;
using nh.qhatu.security.domain.core.Entities;
using nh.qhatu.security.infrastructure.data.Configurations.EntityTypes;

namespace nh.qhatu.security.infrastructure.data.Context
{
    public class SecurityContext : DbContext
    {
        public SecurityContext(DbContextOptions<SecurityContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultContainer("Users");
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
