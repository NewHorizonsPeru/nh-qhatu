using Microsoft.AspNetCore.Mvc;
using nh.qhatu.customer.application.core.interfaces;

namespace nh.qhatu.customer.presentation.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("getAllCustomers")]
        public IActionResult GetAllCustomers()
        {
            return Ok(_customerService.GetAllCustomers());
        }
    }
}
