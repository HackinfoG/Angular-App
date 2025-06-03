using System.ComponentModel.DataAnnotations;

namespace Angular_App.Models
{
    public class ContactForm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [MinLength(3, ErrorMessage = "Full name must be at least 3 characters")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mobile is required")]
        [RegularExpression(@"^[0-9]{10,15}$", ErrorMessage = "Mobile must be 10 to 15 digits")]
        public string Mobile { get; set; } = string.Empty;

        [Required(ErrorMessage = "Subject is required")]
        [MinLength(5, ErrorMessage = "Subject must be at least 5 characters")]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Message is required")]
        [MinLength(10, ErrorMessage = "Message must be at least 10 characters")]
        public string Message { get; set; } = string.Empty;

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
    }
}
