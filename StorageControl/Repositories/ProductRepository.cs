using Microsoft.EntityFrameworkCore;
using StorageControl.Data;
using StorageControl.Models;
using StorageControl.Repositories.Interfaces;

namespace StorageControl.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StorageDBContext _dbContext;
        public ProductRepository(StorageDBContext storageDBContext) 
        { 
            _dbContext = storageDBContext;
        }
        public async Task<List<ProductModel>> ListAll()
        {
            return await _dbContext.Products.ToListAsync();
        }
        public async Task<ProductModel> FindById(int id)
        {
            var res = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (res == null)
            {
                throw new Exception($"Product ID: {id} not found on database");
            }
            return res;
        }

        public async Task<ProductModel> Add(ProductModel product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<ProductModel> Update(ProductModel product, int id)
        {
            ProductModel productById = await FindById(id);

            if (productById == null)
            {
                throw new Exception($"Product ID: {id} not found on database");
            }
            productById.Name = product.Name;
            productById.Description = product.Description;
            productById.Price = product.Price;
            productById.Amount = product.Amount;

            _dbContext.Products.Update(productById); ;
            await _dbContext.SaveChangesAsync();

            return productById;
        }

        public async Task<bool> Delete(int id)
        {
            ProductModel productById = await FindById(id);

            if (productById == null)
            {
                throw new Exception($"Product ID: {id} not found on database");
            }

            _dbContext.Products.Remove(productById);
            await _dbContext.SaveChangesAsync();

            return true;
        }


       
    }
}
