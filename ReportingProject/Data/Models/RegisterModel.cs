﻿using System.ComponentModel.DataAnnotations;

namespace ReportingProject.Data.Models
{
    public class RegisterModel
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public int CountryId { get; set; }

        [Required]
        public bool IsActive { get; set; }

    }
}
