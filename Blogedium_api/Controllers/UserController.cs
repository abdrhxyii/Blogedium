using Blogedium_api.Data;
using Blogedium_api.Interfaces.Services;
using Blogedium_api.Modals;
using Microsoft.AspNetCore.Mvc;

namespace Blogedium_api.Controllers
{
    [Route("auth")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;  
        private readonly IUserService _userService;
        public UserController(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserModal>> CreateUser( UserModal newuser)
        {
            try
            {
                var user = await _userService.CreateUserAsync(newuser);
                return CreatedAtAction(nameof(GetUserByID), new {id = user.Id}, user);
            }
            catch ( Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserModal>> LoginUser (UserModal userModal)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            try
            {
                var user = await _userService.FindUserByEmailAddressAsync(userModal.EmailAddress); // null

                if (user == null)
                {
                    return BadRequest("User Does Not Exist, Please Register to Continue");
                }

                if (userModal.Password != user.Password)
                {
                    return BadRequest("Incorrect Password");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
 
        [HttpGet("profile/{id}")]
        public async Task<ActionResult<UserModal>> GetUserByID (int id)
        {
            try
            {
                var user = await _userService.FindUserAsync(id); // not null
                if (user != null)
                {
                    return Ok(user);
                }
                return NotFound("User Not Found");
            }
            catch ( Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModal>> DeleteUser (int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result)
            {
                return NotFound("User Not Found");
            }
            return NoContent();
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<UserModal>>> GetAllUsers ()
        {
            try 
            {
                var users = await _userService.GetAllUsersAsync(); // 
                if (users == null)
                {
                    return NotFound();
                }
                return Ok(users);
            }
            catch ( Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}