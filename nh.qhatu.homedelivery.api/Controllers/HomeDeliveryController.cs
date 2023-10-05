using Microsoft.AspNetCore.Mvc;
using nh.qhatu.homedelivery.application.dto;
using nh.qhatu.homedelivery.application.interfaces;

namespace nh.qhatu.homedelivery.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeDeliveryController : ControllerBase
    {
        private readonly IHomeDeliveryService _homeDeliveryService;

        public HomeDeliveryController(IHomeDeliveryService homeDeliveryService) 
        {
            _homeDeliveryService = homeDeliveryService;
        }

        [HttpGet("getAllHomeDeliveries")]
        public IActionResult GetAllHomeDeliveries()
        {
            return Ok(_homeDeliveryService.GetAllHomeDeliveries());
        }

        [HttpPost]
        public IActionResult CreateHomeDelivery([FromBody] HomeDeliveryDto homeDeliveryDto)
        {
            return Ok(_homeDeliveryService.CreateHomeDelivery(homeDeliveryDto));
        }
    }
}
