using Angular_App.Data;
using Angular_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Angular_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HireRequestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HireRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SubmitRequest([FromBody] HireRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Duplicate check
            bool exists = await _context.HireRequests.AnyAsync(x =>
                x.Name == model.Name &&
                x.Email == model.Email &&
                x.Service == model.Service &&
                x.Description == model.Description
            );

            if (exists)
            {
                return Conflict(new { message = "You have already submitted this request." });
            }

            _context.HireRequests.Add(model);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Request submitted successfully." });
        }

    }
}
