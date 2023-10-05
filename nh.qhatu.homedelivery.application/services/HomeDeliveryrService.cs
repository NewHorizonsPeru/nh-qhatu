using AutoMapper;
using nh.qhatu.homedelivery.application.dto;
using nh.qhatu.homedelivery.application.interfaces;
using nh.qhatu.homedelivery.domain.entities;
using nh.qhatu.homedelivery.domain.interfaces;

namespace nh.qhatu.homedelivery.application.services
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
