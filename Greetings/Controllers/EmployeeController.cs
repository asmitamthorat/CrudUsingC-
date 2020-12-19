
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreetingAppBL;
using GreetingAppModelLayer;
using EmployeeModel = GreetingAppModelLayer.EmployeeModel;
using Greetings.TokenAuthentification;
using Microsoft.Extensions.Logging;

namespace Greetings.Controllers

{
    [ApiController]
    [Route("[controller]")]
 
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _empService;
       // private  ILogger<EmployeeController> _logger;
        public EmployeeController(IEmployeeService empService)
        {
            this._empService = empService;
          //  _logger = logger;
        }

        [HttpGet]
        [Route("GetEmployees")]
        [TokenAuthenticationFilter]
        public IActionResult GetEmployees() 
        {          
            try
            {
                List<EmployeeModel> empList = _empService.GetEmployees();
                if (empList == null)
                {
                    return this.NotFound(new ServiceResponse<EmployeeModel> { StatusCode = (int)HttpStatusCode.NotFound, Message = "Internal server error", Data = null  });
                }
                return Ok(new ServiceResponse<List<EmployeeModel>> { StatusCode = (int)HttpStatusCode.OK, Message = "successful", Data = empList });
            } catch (Exception)
            {
                return BadRequest(new ServiceResponse<EmployeeModel> { StatusCode = (int)HttpStatusCode.BadRequest, Message = "Page not found ", Data = null   });
            }         
        }

        [HttpGet]
        [Route("GetEmployee/{id}")]
        public IActionResult GetEmployee(int id)
        {
            try
            {
                EmployeeModel employee = _empService.GetEmployee(id);
                if (employee == null)
                {
                    return this.NotFound(new ServiceResponse<EmployeeModel> { StatusCode = (int)HttpStatusCode.NotFound , Message = "Internal server error", Data = null });
                }
                return Ok(new ServiceResponse<EmployeeModel> { StatusCode = (int)HttpStatusCode.OK , Message = "successful", Data = employee});
            }
            catch (Exception)
            {
                return BadRequest(new ServiceResponse<EmployeeModel> { StatusCode = (int)HttpStatusCode.BadRequest, Message = "Page not Found", Data = null  });
            }
        }

        [HttpPost]
        [Route("addEmployee")]
        [TokenAuthenticationFilter]
        public IActionResult AddEmployee([FromForm] EmployeeModel employee)
        {
            try {
                var result = _empService.AddEmployee(employee);
                if (result==null)
                {
                    return this.NotFound(new ServiceResponse<EmployeeModel> { StatusCode = (int)HttpStatusCode.NotFound, Message = "Internal server error", Data = null});
                }
                return Ok(new ServiceResponse<EmployeeModel> { StatusCode = (int)HttpStatusCode.OK, Message = "employee added successfully", Data = result});
            }
            catch (Exception) {
                return BadRequest(new ServiceResponse<EmployeeModel> { StatusCode = (int)HttpStatusCode.BadRequest, Message = "Page not Found", Data = null});
            }
        }

        [HttpDelete]
       // [Route("{id}")]
        [Route("DeleteEmployee/{id}")]
        public IActionResult DeleteEmployee(int id)
        {  
            try {
                int result = _empService.RemoveEmployee(id);
                if (result==0)
                {
                    return this.NotFound(new ServiceResponse<EmployeeModel> { StatusCode = (int)HttpStatusCode.NotFound , Message = "Internal server error", Data = null});
                }
                return Ok(new ServiceResponse<int> { StatusCode = (int)HttpStatusCode.OK, Message = "employee deleted successfully", Data = result});
            }
            catch (Exception ) {
                return BadRequest(new ServiceResponse<EmployeeModel> { StatusCode = (int)HttpStatusCode.BadRequest, Message = "Page not Found", Data = null});
            }
        }

        [HttpPut]
        [Route("UpdateEmployee/{id}")]
        public IActionResult EditEmployee([FromForm] EmployeeModel employee) 
        {
            try {
                var result = _empService.UpdateEmployee(employee.ID,employee);
                if (result == null) {
                    return this.NotFound(new ServiceResponse<EmployeeModel> { StatusCode = (int)HttpStatusCode.NotFound ,  Message = "Internal server error", Data = null});
                }
                return Ok(new ServiceResponse<EmployeeModel> { StatusCode = (int)HttpStatusCode.OK , Message = "edited successfully", Data = result });
            }catch (Exception)
            {
                return BadRequest(new ServiceResponse<EmployeeModel> { StatusCode = (int)HttpStatusCode.BadRequest,  Message = "Page not Fount", Data = null });
            }
        }
    }
}
