using Blogedium_api.Modals;
using Blogedium_api.Data;
using Blogedium_api.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Blogedium_api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserModal> CreateUser (UserModal userModal)
        {
            try
            {
                var existinguser = await _context.Users.FirstOrDefaultAsync(u => u.EmailAddress == userModal.EmailAddress);
                if (existinguser != null)
                {
                    throw new ArgumentException("User Already Exist");
                }
                _context.Users.Add(userModal);
                await _context.SaveChangesAsync();
                return userModal;       
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while registering user.", ex);
            }
        }

        public async Task<UserModal> LoginUser (UserModal userModal)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.EmailAddress == userModal.EmailAddress);
                if (user == null)
                {
                    throw new InvalidOperationException("User Not Found");
                }
                if (user.Password != userModal.Password)
                {
                    throw new ArgumentException("Incorrect password");
                }
                return user;
            }
            catch(Exception ex)
            {
                throw new Exception("Error occurred while login", ex);
            }
        }

        public async Task<UserModal> FindUser (int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    throw new InvalidOperationException("User Not Found");
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred when retrieving the user", ex);
            }
        }

        public async Task<UserModal> DeleteUser(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    throw new ArgumentException("User does not exist");
                }
                else 
                {
                    _context.Users.Remove(user);
                    await _context.SaveChangesAsync();
                    return user;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while deleting the user", ex);
            }

        }

        public async Task<IEnumerable<UserModal>> GetAllUsers ()
        {
            try
            {
                var users = await _context.Users.ToListAsync();
                if (users.Count == 0)
                {
                    throw new InvalidOperationException("User not found");
                }
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving the users", ex);
            }
        }
    }
}