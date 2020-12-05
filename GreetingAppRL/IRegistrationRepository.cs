using GreetingAppModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingAppRL
{
    public interface IRegistrationRepository
    {
        RegistrationModel addUser(RegistrationModel registrationModel);
        List<RegistrationModel> getUsers();
        RegistrationModel checkLoginUser(RegistrationModel registrationModel);
    }
}
