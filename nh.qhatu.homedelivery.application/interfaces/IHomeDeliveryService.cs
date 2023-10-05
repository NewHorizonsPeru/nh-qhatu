using nh.qhatu.homedelivery.application.dto;

namespace nh.qhatu.homedelivery.application.interfaces
{
    public interface IHomeDeliveryService
    {
        ICollection<HomeDeliveryDto> GetAllHomeDeliveries();
        HomeDeliveryDto CreateHomeDelivery(HomeDeliveryDto homeDeliveryDto);
    }
}
