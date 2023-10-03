﻿using Microsoft.AspNetCore.Mvc;
using nh.qhatu.security.application.core.dto;
using nh.qhatu.security.application.core.interfaces;

namespace nh.qhatu.security.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;

        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpGet("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            return Ok(_securityService.GetAllUsers());
        }

        [HttpPost("signUp")]
        public IActionResult SignUp([FromBody] CreateUserDto userDto)
        {
            _securityService.SignUp(userDto);
            return Ok();
        }
    }
}
