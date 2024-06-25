using Blogedium_api.Modals;

namespace Blogedium_api.Interfaces
{
    public interface IUserRepository
    {
        Task<UserModal> CreateUser (UserModal userModal);
        Task<UserModal> LoginUser (UserModal userModal);
        Task<UserModal> FindUser (int id);
        Task<UserModal> DeleteUser (int id);
        Task<IEnumerable<UserModal>> GetAllUsers ();
        Task<UserModal?> FindUserByEmailAddress (string emaildddress);
    }
}