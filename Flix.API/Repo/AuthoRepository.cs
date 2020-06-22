using System;
namespace Acebook.Api.Models
{
    public class AuthoRepository
    {

        public bool SignInValidation(string password, string passwordEntered)
        {
            var decrpytedPassword = new EncrytpionRepository(password).ReturnDencrpyt();

            if (passwordEntered != decrpytedPassword)
            {
                return false;
            }
            else
            {
                return true;
            }
           
        }
    }

}