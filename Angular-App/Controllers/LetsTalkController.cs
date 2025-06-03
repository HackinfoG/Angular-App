using Angular_App.Data;
using Angular_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Angular_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LetsTalkController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LetsTalkController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("contact")]
        public async Task<IActionResult> SubmitContact([FromBody] ContactRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try {
                bool exists = await _context.ContactRequests.AnyAsync(x =>
               x.Name == model.Name &&
               x.Email == model.Email &&
               x.Message == model.Message
           );

                if (exists)
                    return Conflict(new { message = "Duplicate contact request." });

                _context.ContactRequests.Add(model);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Contact request submitted successfully." });
            }
            catch
            {
                throw;
            }
           
        }

        [HttpPost("call")]
        public async Task<IActionResult> SubmitCall([FromBody] CallRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool exists = await _context.CallRequests.AnyAsync(x =>
                x.Phone == model.Phone &&
                x.DateTime == model.DateTime
            );

            if (exists)
                return Conflict(new { message = "Duplicate call request." });

            _context.CallRequests.Add(model);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Call request submitted successfully." });
        }
    }
}
