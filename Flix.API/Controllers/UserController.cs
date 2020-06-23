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
        private IUserReposistory _userRepo;

        private readonly FlixContext _context;

        public PostController(IUserReposistory user, FlixContext context)
        {

            _userRepo = user;
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {

            return this._userRepo.GetAllUsers();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<User> GetById(int id)
        {
            var item = _userRepo.GetUserByID(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        
        [HttpPost(Name = "SignUp")]
        [Route("/User/SignUp")]
        public ActionResult SignUp()
        {
            var user = new User()
            {
                UserName = Request.Form["username"],
                Password = Request.Form["password"],
                FirstName = Request.Form["firstName"],
                LastName = Request.Form["lastName"],
                EmailAddress = Request.Form["emailAddress"]
            };

            var result = _context.Users.FirstOrDefault(c => c.UserName == user.UserName);

            if (result != null)
            {
                return RedirectToAction("SignUp", "Home");
            }
            else
            {
                var encrpyt = new EncrytpionRepository(user.Password).ReturnEncrpyt();
                user.Password = encrpyt;
                _userRepo.AddUser(user);
                return RedirectToAction("Log-In", "Home");

            }

        }
    }
}