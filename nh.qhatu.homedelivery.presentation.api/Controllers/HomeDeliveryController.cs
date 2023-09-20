using Microsoft.AspNetCore.Mvc;
using nh.qhatu.homedelivery.application.core.interfaces;

namespace nh.qhatu.homedelivery.presentation.api.Controllers
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
    }
}
