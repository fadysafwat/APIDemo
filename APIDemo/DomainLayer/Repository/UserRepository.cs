using APIDemo.DataLayer.DataAccess;
using APIDemo.DataLayer.Models;

namespace APIDemo.DomainLayer.Repository
{
    public class UserRepository : Repository<UserModel>
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

    }
}