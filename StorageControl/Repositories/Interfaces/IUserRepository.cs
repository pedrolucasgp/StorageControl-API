using StorageControl.Models;

namespace StorageControl.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> ListAll();
        Task<UserModel> FindById(int id);
        Task<UserModel> Add(UserModel user);
        Task<UserModel> Update(UserModel user, int id);
        Task<bool> Delete(int id);
    }
}
