using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Flix.API.Repo;
using Flix.API.Repo.Users;
using Microsoft.AspNetCore.Http;
using Flix.API.Models;

namespace Flix.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserReposistory _userRepo;

        private readonly FlixContext _context;

        public UserController(IUserReposistory user, FlixContext context)
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
                return RedirectToAction("LogIn", "Home");

            }

        }

        [HttpPost(Name = "Login")]
        [Route("/User/Login")]
        public IActionResult Login()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];


            var user = _context.Users.FirstOrDefault(i => i.UserName == username);



            if (user != null)
            {
                var db_password = user.Password;
                var doesItMatch = new AuthoRepository();
                var result = doesItMatch.SignInValidation(db_password, password);


                if (result == true)
                {
                    HttpContext.Session.SetString("username", user.UserName);
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    return RedirectToAction("UserIndex", "Home");
                }
                else
                {
                    return RedirectToAction("Log_in", "Home");
                };
            }
            else
            {
                return RedirectToAction("Log_in", "Home");
            }

        }
    }
}