using nh.qhatu.homedelivery.application.core.dto;

namespace nh.qhatu.homedelivery.application.core.interfaces
{
    public interface IHomeDeliveryService
    {
        ICollection<HomeDeliveryDto> GetAllHomeDeliveries();
    }
}
