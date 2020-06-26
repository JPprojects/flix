using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Flix.API.Models;
using Flix.API.Repo.Users;

namespace Flix.API.Repo.Users
{


    public class UserRepository : IUserReposistory
    {
        private  FlixContext context;

        public UserRepository(FlixContext context)
        {
            this.context = context;
        }



        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserByID(int id)
        {

            return context.Users.Find(id);
        }

        public User AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }
       
        public User DeleteUser(int id)
        {
            var user = GetUserByID(id);
            context.Users.Remove(user);
            context.SaveChanges();
            return user;
        }        

        public User UpdateUser(User user)
        {
            return user;
        }
    }
}
