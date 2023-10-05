using Microsoft.EntityFrameworkCore;
using nh.qhatu.security.domain.entities;
using nh.qhatu.security.infrastructure.configurations.entityTypes;

namespace nh.qhatu.security.infrastructure.context
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
