using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIDemo.DataLayer.DataAccess;
using APIDemo.DataLayer.Models;
using APIDemo.DomainLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserService _UserService;
        public UsersController(DataContext context)
        {
            _UserService = new UserService(context);
        }

        // GET api/Users
        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> Get()
        {
            return await _UserService.Users();
        }

        
        // GET api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> Get(int id)
        {
            return await _UserService.UserByID(id);
        }

        // POST api/Users
        [HttpPost]
        public async Task Post([FromBody] UserModel user)
        {
            await _UserService.RegistUser(user);
        }

        // PUT api/Users/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] UserModel user)
        {
            UserModel UserModel = await _UserService.UserByID(id);
            UserModel.Name = user.Name;
            UserModel.IsActive = user.IsActive;
            await _UserService.UpdateUser(UserModel);
        }

        // DELETE api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             UserModel UserModel =await _UserService.UserByID(id);
             if(UserModel!=null){                 
             UserModel.IsActive=false;
             await _UserService.UpdateUser(UserModel);
             return Ok();
             }
             else{
                 return NotFound();
             }
        }
    }
}
