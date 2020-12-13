using GreetingAppModelLayer;
using GreetingAppRL;
using Greetings.TokenAuthentification;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingAppBL
{
    public class RegistrationServices:IRgistration
    {

        public IRegistrationRepository _repo;
        public ITokenManager tokenManager;
        public RegistrationServices(IRegistrationRepository repo , ITokenManager tokenManager)
        {
            _repo = repo;
            this.tokenManager = tokenManager;
        }

        public RegistrationModel AddUser(RegistrationModel registrationModel)
        {
            RegistrationModel data = _repo.addUser(registrationModel);
            return data;  
        }

        public List<RegistrationModel> GetUsers()
        {
            List<RegistrationModel> list = _repo.getUsers();
            return list;
        }

        public string checkLoginUser(RegistrationModel registrationModel)
        {
            RegistrationModel user = _repo.checkLoginUser(registrationModel);
            if (user == null)
            {
                return null;
            }
            else
            {
                var tokenString = tokenManager.GenerateToken(user);
                return tokenString;
            }
            
        }
    }
}
