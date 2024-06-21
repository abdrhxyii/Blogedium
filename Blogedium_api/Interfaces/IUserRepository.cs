using Blogedium_api.Modals;

namespace Blogedium_api.Interfaces
{
    public interface IUserRepository
    {
        Task<UserModal> CreateUser (UserModal usermodal);
        Task<UserModal> LoginUser (UserModal usermodal);
        Task<UserModal> FindUser (int id);
        Task<UserModal> DeleteUser (int id);
        Task<IEnumerable<UserModal>> GetAllUsers ();
    }
}