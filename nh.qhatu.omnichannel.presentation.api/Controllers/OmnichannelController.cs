using Microsoft.AspNetCore.Mvc;
using nh.qhatu.omnichannel.application.core.dto;
using nh.qhatu.omnichannel.application.core.dto.Creates;
using nh.qhatu.omnichannel.application.core.interfaces;

namespace nh.qhatu.omnichannel.presentation.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OmnichannelController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OmnichannelController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("getAllOrders")]
        public IActionResult GetAllOrders() 
        {
            return Ok(_orderService.GetAllOrders());
        }

        [HttpPost("createOrder")]
        public IActionResult CreateOrder(CreateOrderDto orderDto) 
        {
            _orderService.CreateOrder(orderDto);
            return Ok();
        }
    }
}
