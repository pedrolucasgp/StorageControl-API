using Microsoft.EntityFrameworkCore;
using StorageControl.Models;
using System.Security.Cryptography.X509Certificates;

namespace StorageControl.Data
{
    public class StorageDBContext : DbContext
    {
        public StorageDBContext(DbContextOptions<StorageDBContext> options)
            : base(options)
        {
        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ProductModel> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
