using Microsoft.AspNetCore.Mvc;
using nh.qhatu.common.application.interfaces;
using System.Runtime.CompilerServices;

namespace nh.qhatu.common.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommonController : ControllerBase
    {
        private readonly ICommonService _commonService;

        public CommonController(ICommonService commonService)
        {
            _commonService = commonService;
        }

        [HttpGet("getAllBrands")]
        public IActionResult GetAllBrands()
        {
            return Ok(_commonService.GetAllBrands());
        }

        [HttpGet("getAllProducts")]
        public IActionResult GetAllProducts()
        {
            return Ok(_commonService.GetAllProducts());
        }

        [HttpGet("validateProductExistence/{productId}")]
        public IActionResult ValidateProductExistence(string productId)
        {
            return Ok(_commonService.ValidateProductExistence(productId));
        }
    }
}
