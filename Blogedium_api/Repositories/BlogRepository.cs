using Blogedium_api.Data;
using Blogedium_api.Modals;
using Blogedium_api.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Blogedium_api.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly ApplicationDbContext _context;
        public BlogRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BlogModal> CreateBlog(BlogModal blogModal)
        {
            await _context.Blogs.AddAsync(blogModal);
            await _context.SaveChangesAsync();
            return blogModal;
        }
        public async Task<IEnumerable<BlogModal>> GetAll ()
        {
            return await _context.Blogs.ToListAsync();
        }
        public async Task<BlogModal?> GetBlog (int id)
        {
            return await _context.Blogs.FindAsync(id);
        }
        public async Task<BlogModal?> DeleteBlog (int id)
        {
            var blog = await _context.Blogs.FindAsync(id); 
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
                await _context.SaveChangesAsync();
            }
            return blog;
        }
        public async Task<BlogModal?> UpdateBlog (int id, BlogModal blogModal)
        {
            var blog = await _context.Blogs.FindAsync(id);
            if (blog != null)
            {
                blog.Image = blogModal.Image;
                blog.Title = blogModal.Title;
                blog.Content = blogModal.Content;
                await _context.SaveChangesAsync();
            }
            return blog;
        }
        public async Task<BlogModal?> FindById (int id)
        {
            var blog = await _context.Blogs.FindAsync(id);
            return blog;
        }
 
    }
}