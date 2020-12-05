using GreetingAppBL;
using GreetingAppModelLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace Greetings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private IRgistration _regisService;

        public RegistrationController(IRgistration registration)
        {
            this._regisService = registration;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromForm]RegistrationModel registrationModel)
        {
            try
            {
                var result = _regisService.checkLoginUser(registrationModel);
                if (result== null)
                {
                    return NotFound(new ServiceResponse<RegistrationModel> { Data = null, Message = "user is not identified", Response = (int)HttpStatusCode.NotFound });
                }
                return Ok(new ServiceResponse<RegistrationModel> { Data = result, Message = "login successfully", Response = (int)HttpStatusCode.OK });
            }
            catch (Exception)
            {
                return BadRequest(new ServiceResponse<Employee> { Data = null, Message = "Page not found ", Response = (int)HttpStatusCode.BadRequest });
            }
        }

        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser( [FromForm]  RegistrationModel registrationModel)
        {
            try
            {
                var result= _regisService.AddUser(registrationModel);
                if (result == null) {

                    return NotFound(new ServiceResponse<RegistrationModel> { Data = null, Message = "internal server error", Response =(int)HttpStatusCode.NotFound});
                }
                return Ok(new ServiceResponse<RegistrationModel> { Data = result, Message = "Added Successful", Response = (int)HttpStatusCode.OK });
            }
            catch (Exception)
            {
                return BadRequest(new ServiceResponse<Employee> { Data = null, Message = "Page not found ", Response =(int)HttpStatusCode.BadRequest });
            }     
        }

        [HttpGet]
        public IActionResult Get() {
            try
            {
                List<RegistrationModel> result = _regisService.GetUsers();
                if (result==null) {
                    return NotFound(new ServiceResponse<RegistrationModel> { Data = null, Message = "internal server error", Response = (int)HttpStatusCode.NotFound });
                }
                return Ok(new ServiceResponse<List<RegistrationModel>> { Data = result, Message = "successful", Response = (int)HttpStatusCode.OK });
            }
            catch (Exception )
            {
                return BadRequest(new ServiceResponse<Employee> { Data = null, Message = "Page not found ", Response = (int)HttpStatusCode.BadRequest });
            }
        }
    }
}
