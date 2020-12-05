using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingAppModelLayer
{
    public class RegistrationModel
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
}
