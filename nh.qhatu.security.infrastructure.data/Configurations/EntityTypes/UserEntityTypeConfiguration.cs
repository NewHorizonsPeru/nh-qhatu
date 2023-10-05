using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using nh.qhatu.security.domain.core.Entities;
using System.Reflection.Emit;

namespace nh.qhatu.security.infrastructure.data.Configurations.EntityTypes
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.Id)
                .ToJsonProperty("id");

            builder.Property(e => e.Username)
                .ToJsonProperty("username");

            builder.Property(e => e.Password)
                .ToJsonProperty("password");

            builder.Property(e => e.CustomerId)
                .ToJsonProperty("customerId");

            builder.Property(e => e.Role)
                .ToJsonProperty("role");

            builder.HasNoDiscriminator();

            builder.HasPartitionKey(e => e.Id);

            builder.UseETagConcurrency();
        }
    }
}
