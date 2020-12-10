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
        string Encode(Employee employee);
        ClaimsPrincipal Decode(string token);
    }
}
