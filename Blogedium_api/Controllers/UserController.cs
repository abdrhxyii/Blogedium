using Blogedium_api.Data;
using Blogedium_api.Modals;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            try{
                var user = await _context.Users.FirstOrDefaultAsync(u => u.EmailAddress == newuser.EmailAddress);
                if (user != null)
                {
                    return BadRequest("User Already Exist, Please signin to continue");
                }
                else 
                {
                    _context.Users.Add(newuser);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction(nameof(GetUserByID), new { id = newuser.Id }, newuser);
                }
            } 
            catch (Exception error)
            {
                Console.WriteLine(error);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while registerring");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserModal>> LoginUser (UserModal usermodal)
        {
            if (usermodal == null || string.IsNullOrEmpty(usermodal.EmailAddress))
            {
                return BadRequest("Please enter valid data");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.EmailAddress == usermodal.EmailAddress);
            if (user == null)
            {
                return NotFound("User Not Found");
            }

            if (user.Password != usermodal.Password)
            {
                return BadRequest("Incorrect Password");
            }
            return Ok();
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModal>> DeleteUser (int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound("User not Found");
                } 
                else 
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    return StatusCode(StatusCodes.Status204NoContent);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModal>>> GetAllUsers ()
        {
            try
            {
                var users = await _context.Users.ToListAsync(); // ToListAsync -> if there is nothing then this will return an empty list 
                if (users.Count == 0)
                {
                    return NotFound("No users found");
                } else
                {
                    return Ok(users);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}