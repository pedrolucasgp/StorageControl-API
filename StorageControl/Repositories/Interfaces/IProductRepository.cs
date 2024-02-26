using StorageControl.Models;

namespace StorageControl.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> ListAll();
        Task<ProductModel> FindById(int id);
        Task<ProductModel> Add(ProductModel user);
        Task<ProductModel> Update(ProductModel user, int id);
        Task<bool> Delete(int id);
    }
}
