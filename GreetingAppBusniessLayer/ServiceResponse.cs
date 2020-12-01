using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingAppBusniessLayer
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }

        public bool Success { get; set; } = true;

        public String Message { get; set; } = null;
    }
}
