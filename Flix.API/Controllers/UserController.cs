using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AcebookApi.Models;
using Flix.API.Repo;
using Flix.API.Repo.Users;

namespace AcebookApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly FlixContext _context;
        private IUserReposistory userReposistory;


        public PostController(FlixContext context)
        {
            _context = context;
            this.userReposistory = new UserRepository(_context);
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {

            return this.userReposistory.GetAllUsers();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<User> GetById(int id)
        {
            var item = userReposistory.GetUserByID(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public bool SignUp(string username, string emailAddress, string password,string firstname, string lastname)
        {
            var user = new User()
            {
                UserName = username,
                Password = password,
                FirstName = firstname,
                LastName = lastname,
                EmailAddress = emailAddress
            };

            var result = _context.Users.FirstOrDefault(c => c.UserName == user.UserName);

            if (result != null)
            {
                return false;
            }
            else
            { 
                var encrpyt = new EncrytpionRepository(user.Password).ReturnEncrpyt();
                user.Password = encrpyt;
                this.userReposistory.AddUser(user);
                return true;

            }
        
        
 
        }


}
}