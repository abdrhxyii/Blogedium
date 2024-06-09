using Blogedium_api.Data;
using Blogedium_api.Modals;
using Microsoft.AspNetCore.Mvc;

namespace Blogedium_api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserModal>> Registration(UserModal newuser)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            _context.Users.Add(newuser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserByID), new { id = newuser.Id }, newuser);
        }

        [HttpGet("profile")]
        public async Task<ActionResult<UserModal>> GetUserByID (int Id)
        {
            var user = await _context.Users.FindAsync(Id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
    }
}