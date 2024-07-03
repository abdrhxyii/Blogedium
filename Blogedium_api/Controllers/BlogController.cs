using Blogedium_api.Data;
using Blogedium_api.Interfaces.Services;
using Blogedium_api.Modals;
using Microsoft.AspNetCore.Mvc;

namespace Blogedium_api.Controllers
{
    [Route("blog")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpPost("")]
        public async Task<ActionResult<BlogModal>> CreateBlog(BlogModal blogModal)
        {
            try
            {
                var blog = await _blogService.CreateBlogAsync(blogModal);
                return CreatedAtAction(nameof(GetBlogById), new {id = blogModal.Id}, blog);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogModal>> GetBlogById (int id)
        {
            try 
            {
                var user = await _blogService.GetBlogAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<BlogModal>>> GetAllBlogs ()
        {
            try
            {       
                var users = await _blogService.GetAllAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BlogModal>> DeleteBlog (int id)
        {
            try
            {
                var user = await _blogService.DeleteBlogAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}