using GreetingAppModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingAppBL
{
    public interface IRegistrationServices
    {
        RegistrationModel AddUser(GreetingAppModelLayer.RegistrationModel registrationModel);
        List<RegistrationModel> GetUsers();
       string checkLoginUser(RegistrationModel registrationModel);
    }
}
