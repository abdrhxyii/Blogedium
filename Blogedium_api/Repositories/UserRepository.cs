using Blogedium_api.Modals;
using Blogedium_api.Data;

namespace Blogedium_api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserModal> CreateUser (UserModal usermodal)
        {
            try
            {
                var existinguser = await _context.User.FirstOrDefaultAsync(u => u.EmailAddress == usermodal.EmailAddress);
                if (existinguser != null)
                {
                    throw new ArgumentException("User Already Exist")
                }
                _context.UserModal.Add(usermodal);
                await _context.SaveChangesAsync();
                return usermodal;       
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while registering user.", ex);
            }
        }

        public async Task<UserModal> LoginUser (UserModal usermodal)
        {
            try
            {
                var user = await _context.User.FirstOrDefaultAsync(u => u.EmailAddress == usermodal.EmailAddress);
                if (user == null)
                {
                    throw new InvalidOperationException("User Not Found");
                }
                if (user.Password != usermodal.Password)
                {
                    throw new ArgumentException("Incorrect password")
                }
                return user
            }
            catch(Exception ex)
            {
                throw new Exception("Error occurred while login", ex)
            }
        }

        public async Task<UserModal> FindUser (int id)
        {
            try
            {
                var user = await _context.User.FindAsync(id);
                if (user == null)
                {
                    throw new InvalidOperationException("User Not Found")
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred when retrieving the user", ex)
            }
        }
    }
}