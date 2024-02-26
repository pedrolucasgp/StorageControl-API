using Microsoft.EntityFrameworkCore;
using StorageControl.Data;
using StorageControl.Models;
using StorageControl.Repositories.Interfaces;

namespace StorageControl.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StorageDBContext _dbContext;
        public UserRepository(StorageDBContext storageDBContext) 
        { 
            _dbContext = storageDBContext;
        }

        public async Task<UserModel> FindById(int id)
        {
            var res = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (res == null)
            {
                throw new Exception($"User ID: {id} not found on database");
            }
            return res;
        }

        public async Task<List<UserModel>> ListAll()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<UserModel> Add(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userById = await FindById(id);

            if (userById == null)
            {
                throw new Exception($"User ID: {id} not found on database");
            }
            userById.Name = user.Name;
            userById.Email = user.Email;

            _dbContext.Users.Update(userById); ;
            await _dbContext.SaveChangesAsync();

            return userById;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userById = await FindById(id);

            if (userById == null)
            {
                throw new Exception($"User ID: {id} not found on database");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }


       
    }
}
