﻿using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos
{
    public record UserForAuthenticationDto
    {
        [Required(ErrorMessage = "User name is required!")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        public string? Password { get; set; }
    }
}
