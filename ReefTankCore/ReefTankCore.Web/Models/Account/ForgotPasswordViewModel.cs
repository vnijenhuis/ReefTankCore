﻿using System.ComponentModel.DataAnnotations;

namespace ReefTankCore.Web.Models.Account
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
