using System;
using System.Collections;
using System.Collections.Generic;
using Flix.API.Models;

namespace Flix.API.Repo.Users
{
    public interface IUserReposistory
    {
        List<User> GetAllUsers();
        User GetUserByID(int Id);
        User AddUser(User user);
        User DeleteUser(int Id);
        User UpdateUser(User user);
    }
}
