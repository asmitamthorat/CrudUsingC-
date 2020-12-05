using GreetingAppModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingAppBL
{
    public interface IRgistration
    {
        RegistrationModel AddUser(GreetingAppModelLayer.RegistrationModel registrationModel);
        List<RegistrationModel> GetUsers();
       RegistrationModel checkLoginUser(RegistrationModel registrationModel);
    }

}
