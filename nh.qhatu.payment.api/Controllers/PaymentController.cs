﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nh.qhatu.payment.application.dto.Creates;
using nh.qhatu.payment.application.interfaces;

namespace nh.qhatu.payment.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public IActionResult CreatePayment([FromBody] CreatePaymentDto createPaymentDto)
        {
            _paymentService.CreatePayment(createPaymentDto);
            return Ok();
        }
    }
}
