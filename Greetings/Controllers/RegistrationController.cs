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
        private IRegistrationServices _regisService;

        public RegistrationController(IRegistrationServices registration)
        {
            this._regisService = registration;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser([FromForm]RegistrationModel registrationModel)
        {
            try
            {
                var result = _regisService.checkLoginUser(registrationModel);
                if (result== null)
                {
                    return NotFound(new ServiceResponse<RegistrationModel> { StatusCode = (int)HttpStatusCode.NotFound, Message = "user is not identified", Data = null });
                }
                return Ok(new ServiceResponse<string> { StatusCode = (int)HttpStatusCode.OK,  Message = "login successfully", Data = result });
            }
            catch (Exception)
            {
                return BadRequest(new ServiceResponse<RegistrationModel> { StatusCode = (int)HttpStatusCode.BadRequest, Message = "Page not found ", Data = null });
            }
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult AddUser( [FromForm]  RegistrationModel registrationModel)
        {
            try
            {
                var result= _regisService.AddUser(registrationModel);
                if (result == null) {

                    return NotFound(new ServiceResponse<RegistrationModel> { StatusCode = (int)HttpStatusCode.NotFound,  Message = "Internal server error", Data = null });
                }
                return Ok(new ServiceResponse<RegistrationModel> { StatusCode = (int)HttpStatusCode.OK,  Message = "Added Successful", Data = result });
            }
            catch (Exception)
            {
                return BadRequest(new ServiceResponse<RegistrationModel> { StatusCode = (int)HttpStatusCode.BadRequest, Message = "Page not found ", Data = null  });
            }     
        }

        [HttpGet]
        public IActionResult GetUser() {
            try
            {
                List<RegistrationModel> result = _regisService.GetUsers();
                if (result==null) {
                    return NotFound(new ServiceResponse<RegistrationModel> { StatusCode = (int)HttpStatusCode.NotFound, Message = "Internal server error", Data = null });
                }
                return Ok(new ServiceResponse<List<RegistrationModel>> { StatusCode = (int)HttpStatusCode.OK, Message = "successful", Data = result });
            }
            catch (Exception )
            {
                return BadRequest(new ServiceResponse<RegistrationModel> { StatusCode = (int)HttpStatusCode.BadRequest, Message = "Page not found ", Data = null  });
            }
        }
    }
}
