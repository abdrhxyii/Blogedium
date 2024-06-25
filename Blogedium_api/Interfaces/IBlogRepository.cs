using Blogedium_api.Modals;

namespace Blogedium_api.Interfaces
{
    public interface IBlogRepository
    {
        Task<UserModal> CreateBlog (BlogModal blogModal);
        Task<IEnumerable<UserModal>> GetAll (BlogModal blogModal);
        Task<UserModal> GetBlog (int id);
        Task<UserModal> DeleteBlog (int id); 
    }
}