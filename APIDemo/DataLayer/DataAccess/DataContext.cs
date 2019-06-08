using APIDemo.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace APIDemo.DataLayer.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option)
        {

        }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AuthontecatedUserModel> AuthontecatedUsers { get; set; }
    }
}