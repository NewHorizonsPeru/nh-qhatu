﻿namespace nh.qhatu.security.application.core.dto
{
    public class CreateUserDto
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string CustomerId { get; set; } = null!;
    }
}
