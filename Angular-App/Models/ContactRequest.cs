﻿using System.ComponentModel.DataAnnotations;

namespace Angular_App.Models
{
    public class ContactRequest
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public string Message { get; set; } = "";
    }
}
