using Microsoft.EntityFrameworkCore;
using nh.qhatu.homedelivery.domain.core.entities;

namespace nh.qhatu.homedelivery.infrastructure.data.context
{
    public partial class QhatuContext : DbContext
    {
        public QhatuContext(DbContextOptions<QhatuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HomeDelivery> Addresses { get; set; } = null!;
    }
}
