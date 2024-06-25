using Blogedium_api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Blogedium_api.Controllers
{
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public BlogController(ApplicationDbContext context)
        {
            _context = context;
        }
        
    }
}