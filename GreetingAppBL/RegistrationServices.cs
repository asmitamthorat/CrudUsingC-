using GreetingAppModelLayer;
using GreetingAppRL;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingAppBL
{
    public class RegistrationServices:IRgistration
    {

        IRegistrationRepository _repo;
        public RegistrationServices(IRegistrationRepository repo)
        {
            _repo = repo;
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

        public RegistrationModel checkLoginUser(RegistrationModel registrationModel)
        {
            RegistrationModel data = _repo.checkLoginUser(registrationModel);
            return data;
        }
    }
}
