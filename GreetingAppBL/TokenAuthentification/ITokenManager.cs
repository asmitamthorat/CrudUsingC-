using GreetingAppModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Greetings.TokenAuthentification
{
    public interface ITokenManager
    {
        string GenerateToken(RegistrationModel registrationModel);
        ClaimsPrincipal GetPrincipal(string token);
        string ValidateToken(string token);
    }
}
