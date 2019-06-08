using System.Threading.Tasks;
using APIDemo.DataLayer.Models;

namespace APIDemo.DomainLayer.Services
{
    public interface IAuthontecationService
    {
        Task<bool> Registration(AuthontecatedUserModel user);
        Task<AuthontecatedUserModel> Login(string name,string password);
        Task<bool> IsExistName(string name);
    }
}