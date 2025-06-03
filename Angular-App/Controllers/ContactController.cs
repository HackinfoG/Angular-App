using Angular_App.Data;
using Angular_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Angular_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitContactForm([FromBody] ContactForm contactForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Duplicate check by email and subject
            bool exists = await _context.ContactForms.AnyAsync(c =>
                c.Email == contactForm.Email && c.Subject == contactForm.Subject);

            if (exists)
            {
                return Conflict(new { message = "Duplicate submission detected!" });
            }

            _context.ContactForms.Add(contactForm);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Contact form submitted successfully!" });
        }
    }
}
