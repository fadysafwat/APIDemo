using System.Collections.Generic;
using System.Threading.Tasks;
using APIDemo.DataLayer.DataAccess;
using APIDemo.DataLayer.Models;
using APIDemo.DomainLayer.Repository;

namespace APIDemo.DomainLayer.Services
{
    public class UserService
    {
        private UserRepository _UserRepository;
        public UserService(DataContext context)
        {
            _UserRepository = new UserRepository(context);
        }

        public  async Task<List<UserModel>> Users()
        {
            return await _UserRepository.GetAll();
        }
        public  async Task<UserModel> UserByID(int id)
        {
            return await _UserRepository.GetByID(id);
        }
        public  async Task<bool> RegistUser(UserModel user)
        {
            return await _UserRepository.Add(user);
        }
        public  async Task<bool> UpdateUser(UserModel user)
        {
            return await _UserRepository.Update(user);
        }
        public async Task<bool> DeleteUser(UserModel user)
        {
            return await _UserRepository.Delete(user);
        }
    }
}