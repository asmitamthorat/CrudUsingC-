using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingAppModelLayer
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }

        public int Response { get; set; } 

        public String Message { get; set; } = null;
    }
}
