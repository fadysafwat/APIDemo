using System.Linq;
using System.Threading.Tasks;
using APIDemo.DataLayer.DataAccess;
using APIDemo.DataLayer.Models;
using APIDemo.DomainLayer.Repository;
using Microsoft.EntityFrameworkCore;

namespace APIDemo.DomainLayer.Services
{
    public class AuthontecationService : IAuthontecationService
    {
        private AuthontecatedUserRepository _AuthontecatedUserRepository;
        public AuthontecationService(DataContext context)
        {
            _AuthontecatedUserRepository = new AuthontecatedUserRepository(context);
        }

        public async Task<bool> Registration(AuthontecatedUserModel user)
        {
            return await _AuthontecatedUserRepository.Add(user);
        }
        public async Task<AuthontecatedUserModel> Login(string name,string password)
        {
            return await _AuthontecatedUserRepository.GetAllQuerable().Where(x=>x.Name==name & x.Password==password).SingleOrDefaultAsync();          
        }

        public async Task<bool> IsExistName(string name)
        {
            if( await _AuthontecatedUserRepository.GetAllQuerable().Where(x=>x.Name==name).SingleOrDefaultAsync() == null)
            {
                return false;
            }
            return true;
        }

    }
}