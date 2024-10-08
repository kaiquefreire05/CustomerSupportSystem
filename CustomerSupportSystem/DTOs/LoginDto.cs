﻿using System.ComponentModel.DataAnnotations;

namespace CustomerSupportSystem.DTOs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Enter your email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        public string Password { get; set; }
    }
}