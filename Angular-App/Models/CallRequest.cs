using System.ComponentModel.DataAnnotations;

namespace Angular_App.Models
{
    public class CallRequest
    {
        public int Id { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; } = "";

        [Required]
        public DateTime DateTime { get; set; }
    }
}
