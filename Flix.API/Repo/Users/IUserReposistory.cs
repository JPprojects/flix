using System;
using System.Collections;
using System.Collections.Generic;
using AcebookApi.Models;

namespace Flix.API.Repo.Users
{
    public interface IUserReposistory
    {
        List<User> GetAllUsers();
        User GetUserByID(int Id);
        User AddUser(User user);
        void DeleteUser(int Id);
        User UpdateUser(User user);
    }
}
