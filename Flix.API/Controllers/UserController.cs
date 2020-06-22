using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AcebookApi.Models;
using Acebook.Api.Models;
using System;
using Microsoft.AspNetCore.Http;

namespace AcebookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly PostContext _context;

        public UserController(PostContext context)
        {
            _context = context;

        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return _context.Users.ToList();
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

        [HttpPost(Name = "SignUp")]
        [Route("/User/SignUp")]
        public ActionResult SignUp()
        {
            string username = Request.Form["username"];
            string emailAddress = Request.Form["emailAddress"];
            string password = Request.Form["password"];
            string firstName = Request.Form["firstName"];
            string lastName = Request.Form["lastName"];

            var user = new User()
            {
                UserName = username,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                EmailAddress = emailAddress
            };

           var result = _context.Users.FirstOrDefault(c => c.UserName == user.UserName);

            if (result != null)
            {
                return RedirectToAction("Sign_Up", "Home");
            }
            else
            {
                var encyrt = new EncrytpionRepository(user.Password).ReturnEncrpyt();
                user.Password = encyrt;
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Log_in", "Home");
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
                    HttpContext.Session.SetString("UserId", user.Id.ToString());
                    return RedirectToAction("Index", "Post");
                 } else {
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
