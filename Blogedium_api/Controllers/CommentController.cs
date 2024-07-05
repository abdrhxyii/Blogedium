using Blogedium_api.Exceptions;
using Blogedium_api.Interfaces.Services;
using Blogedium_api.Modals;
using Microsoft.AspNetCore.Mvc;

namespace Blogedium_api.Controllers
{
    [Route("comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {   
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<CommentModal>> CreateComment (int id, CommentModal commentModal)
        {
            try
            {
                commentModal.BlogId = id;
                var comment = await _commentService.CreateCommentAsync(id, commentModal);
                return CreatedAtAction(nameof(GetCommentByID), new {id = commentModal.Id}, comment);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch ( ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentModal>> GetCommentByID (int id)
        {
            try
            {
                var comment = await _commentService.GetCommentByIDAsync(id);
                return Ok(comment);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch ( Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CommentModal>> DeleteComment (int id)
        {
            try
            {
                var comment = await _commentService.DeleteCommentAsync(id);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch ( Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CommentModal>> UpdateComment (int id, CommentModal commentModal)
        {
            try
            {
                var comment = await _commentService.UpdateCommentAsync(id, commentModal);
                return NoContent();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch ( Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}