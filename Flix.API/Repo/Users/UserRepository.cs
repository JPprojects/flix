using System;
using System.Collections.Generic;
using System.Linq;
using AcebookApi.Models;

namespace Flix.API.Repo
{
    public class UserRepository
    {
        public readonly FlixContext _context;

        public UserRepository(FlixContext context)
        {
            _context = context;
        }


        public List<User> ViewAll()
        {
            return _context.Users.ToList();
        }

        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

    }
}
