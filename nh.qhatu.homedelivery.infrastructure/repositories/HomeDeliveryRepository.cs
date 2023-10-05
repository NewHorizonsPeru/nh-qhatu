using Microsoft.EntityFrameworkCore;
using nh.qhatu.homedelivery.domain.entities;
using nh.qhatu.homedelivery.domain.interfaces;
using nh.qhatu.homedelivery.infrastructure.context;

namespace nh.qhatu.homedelivery.infrastructure.repositories
{
    public class HomeDeliveryRepository : GenericRepository<HomeDelivery>, IHomeDeliveryRepository
    {
        public HomeDeliveryRepository(HomeDeliveryContext context) : base(context) { }
    }
}
