using Blogedium_api.Modals;
using Microsoft.EntityFrameworkCore;

namespace Blogedium_api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<UserModal> Users { get; set; }
        public DbSet<CommentModal> Comments {get; set;}
        public DbSet<BlogModal> Blogs {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<>

        }

    }
}