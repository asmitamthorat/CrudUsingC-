using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingAppModelLayer
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }

        public bool Success { get; set; } 

        public String Message { get; set; } = null;


        //public ServiceResponse(T data, int Success, string Message) {
        //    this.Data = data;
        //    this.Success = Success;
        //    this.Message = Message;
        
        //}
    }
}
