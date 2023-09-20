using Microsoft.EntityFrameworkCore;
using nh.qhatu.homedelivery.domain.core.entities;
using nh.qhatu.homedelivery.domain.core.interfaces;
using nh.qhatu.homedelivery.infrastructure.data.context;

namespace nh.qhatu.homedelivery.infrastructure.data.repositories
{
    public class HomeDeliveryRepository : GenericRepository<HomeDelivery>, IHomeDeliveryRepository
    {
        public HomeDeliveryRepository(QhatuContext context) : base(context) { }
    }
}
