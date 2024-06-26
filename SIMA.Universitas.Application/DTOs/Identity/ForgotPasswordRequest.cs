﻿using System.ComponentModel.DataAnnotations;

namespace SIMA.Universitas.Application.DTOs.Identity
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}