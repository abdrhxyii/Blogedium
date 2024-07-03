using Blogedium_api.Exceptions;
using Blogedium_api.Interfaces.Repository;
using Blogedium_api.Interfaces.Services;
using Blogedium_api.Modals;

namespace Blogedium_api.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IBlogRepository _blogRepository;
        public CommentService(ICommentRepository commentRepository, IBlogRepository blogRepository)
        {
            _commentRepository = commentRepository;
            _blogRepository = blogRepository;
        }
        public async Task<CommentModal> CreateCommentAsync(int blogId, CommentModal commentModal)
        {
            var blog = await _blogRepository.FindById(blogId);
            if (blog != null)
            {
                commentModal.BlogId = blogId;
                return await _commentRepository.CreateComment(blogId, commentModal);
            }
            throw new NotFoundException($"The provided BlogId '{blogId}' does not exist");
        }

        public async Task<CommentModal> DeleteCommentAsync(int id)
        {
            var comment = await _commentRepository.FindComment(id); 
            if (comment != null)
            {   
                return await _commentRepository.DeleteComment(id);
            }
            throw new NotFoundException($"The comment '{id}' does not exist");
        }

        public Task<CommentModal> UpdateCommentAsync(int id, CommentModal commentModal)
        {
            var comment = _commentRepository.FindComment(id);
            if (comment != null)
            {
                return _commentRepository.UpdateComment(id, commentModal);
            }
            throw new NotFoundException($"The comment '{id}' does not exist to update");
        }

    }
}