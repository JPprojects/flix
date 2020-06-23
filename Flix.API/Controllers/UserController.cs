using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AcebookApi.Models;
using Flix.API.Repo;
using Flix.API.Repo.Users;

namespace AcebookApi.Controllers
{
    [Route("api/[controller]")]
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
        public ActionResult<User> GetById(long id)
        {
            var item = _context.Users.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public object Create(User user)
        {
            var encrpyt = new EncrytpionRepository(user.Password).ReturnEncrpyt();
            user.Password = encrpyt;
            return this.userReposistory.AddUser(user);
        }
      
      
    }
}