using APIDemo.DataLayer.DataAccess;
using APIDemo.DataLayer.Models;

namespace APIDemo.DomainLayer.Repository 
{
    public class AuthontecatedUserRepository: Repository<AuthontecatedUserModel>
    {
         public AuthontecatedUserRepository(DataContext context) : base(context)
        {
        }
    }
}