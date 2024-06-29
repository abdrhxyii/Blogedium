using Blogedium_api.Interfaces;
using Blogedium_api.Data;
using Blogedium_api.Modals;

namespace Blogedium_api.Repositories
{
    public class BlogRepository
    {
        private readonly ApplicationDbContext _context;
        public BlogRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // public async Task<UserModal> CreateBlog (BlogModal blogModal)
        // {
        //     try
        //     {
        //         // await _context.Blogs.AddAsync(blogModal);
        //         // await _context.SaveChangesAsync();
        //         // return blogModal;
        //     }
        //     catch (Exception ex)
        //     {
        //         throw new Exception("Error occurred while registering user.", ex);
        //     }
        // }
    }
}