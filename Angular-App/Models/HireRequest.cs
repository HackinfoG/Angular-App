using System.ComponentModel.DataAnnotations;

namespace Angular_App.Models
{
    public class HireRequest
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public string Service { get; set; } = "";

        [Required]
        public string Description { get; set; } = "";
    }
}
