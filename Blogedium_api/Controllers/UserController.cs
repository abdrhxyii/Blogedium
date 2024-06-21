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
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _user_repository;

        public UserController(ApplicationDbContext context, IConfiguration configuaryion, IUserRepository user_repository)
        {
            _context = context;
            _configuration = configuaryion;
            _user_repository = user_repository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserModal>> Registration( UserModal newuser)
        {
            try
            {
                var user = await _user_repository.CreateUser(newuser);
                return CreatedAtAction(nameof(GetUserByID), new {id = user.Id}, user)
            } 
            catch(ArgumentException ex)
            {
                return BadRequest("User Already Exist, Please login to continue")
            }
            catch (Exception ex)
            {
                Console.WriteLine(error);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error occured while registerring");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserModal>> LoginUser (UserModal usermodal)
        {
            try
            {
                var user = await _user_repository.LoginUser(usermodal)
                return Ok(usermodal);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex)
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest (ex)
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("profile")]
        public async Task<ActionResult<UserModal>> GetUserByID (int Id)
        {
            try
            {
                var user = await _user_repository.FindUser(id);
                return user;
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
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

        // private string GeneratrJWTToken (UserModal usermodal)
        // {

        // }
    }
}