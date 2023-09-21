using AutoMapper;
using nh.qhatu.homedelivery.application.core.dto;
using nh.qhatu.homedelivery.application.core.interfaces;
using nh.qhatu.homedelivery.domain.core.entities;
using nh.qhatu.homedelivery.domain.core.interfaces;

namespace nh.qhatu.homedelivery.application.core.services
{
    public class HomeDeliveryrService : IHomeDeliveryService
    {
        private readonly IHomeDeliveryRepository _homeDeliveryRepository;
        private readonly IMapper _mapper;

        public HomeDeliveryrService(IHomeDeliveryRepository homeDeliveryRepository, IMapper mapper)
        {
            _homeDeliveryRepository = homeDeliveryRepository;
            _mapper = mapper;
        }

        public ICollection<HomeDeliveryDto> GetAllHomeDeliveries()
        {
            var homeDeliveries = _homeDeliveryRepository.List();
            var homeDeliveriesDto = _mapper.Map<ICollection<HomeDeliveryDto>>(homeDeliveries);
            return homeDeliveriesDto;
        }

        public HomeDeliveryDto CreateHomeDelivery(HomeDeliveryDto homeDeliveryDto)
        {
            var homeDelivery = _mapper.Map<HomeDelivery>(homeDeliveryDto);
            _homeDeliveryRepository.Add(homeDelivery);
            _homeDeliveryRepository.Save();
            return homeDeliveryDto;
        }
    }
}
