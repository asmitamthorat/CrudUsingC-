
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreetingAppBL;
using GreetingAppModelLayer;
using Employee = GreetingAppModelLayer.Employee;
using Greetings.TokenAuthentification;

namespace Greetings.Controllers

{
    [ApiController]
    [Route("[controller]")]
 
    public class EmployeeController : ControllerBase
    {
        private IService _empService;
        public EmployeeController(IService empService)
        {
            this._empService = empService;   
        }

        [HttpGet]
        [Route("GetEmployees")]
        [TokenAuthenticationFilter]
        public IActionResult GetEmployees() 
        {          
            try
            {
                List<Employee> empList = _empService.GetEmployees();
                if (empList == null)
                {
                    return this.NotFound(new ServiceResponse<Employee> { Data = null, Message = "internal server error", Response = (int)HttpStatusCode.NotFound });
                }
                return Ok(new ServiceResponse<List<Employee>> { Data = empList, Message = "successful", Response = (int)HttpStatusCode.OK });
            } catch (Exception)
            {
                return BadRequest(new ServiceResponse<Employee> { Data = null, Message = "Page not found ", Response = (int)HttpStatusCode.BadRequest });
            }         
        }

        [HttpGet]
        [Route("GetEmployee/{id}")]
        public IActionResult GetEmployee(int id)
        {
            try
            {
                Employee employee = _empService.GetEmployee(id);
                if (employee == null)
                {
                    return this.NotFound(new ServiceResponse<Employee> { Data = null, Message = "internal server error", Response = (int)HttpStatusCode.NotFound });
                }
                return Ok(new ServiceResponse<Employee> { Data = employee, Message = "successful", Response = (int)HttpStatusCode.OK });
            }
            catch (Exception)
            {
                return BadRequest(new ServiceResponse<Employee> { Data = null, Message = "Page not Found", Response= (int)HttpStatusCode.BadRequest });
            }
        }

        [HttpPost]
        [Route("addEmployee")]
        public IActionResult AddEmployee([FromForm] Employee employee)
        {
            try {
                var result = _empService.AddEmployee(employee);
                if (result==null)
                {
                    return this.NotFound(new ServiceResponse<Employee> { Data = null, Message = "internal server error", Response = (int)HttpStatusCode.NotFound });
                }
                return Ok(new ServiceResponse<Employee> { Data = result, Message = "employee added successfully", Response = (int)HttpStatusCode.OK });
            }
            catch (Exception) {
                return BadRequest(new ServiceResponse<Employee> { Data = null, Message = "Page not Found", Response = (int)HttpStatusCode.BadRequest });
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
                    return this.NotFound(new ServiceResponse<Employee> { Data = null, Message = "internal server error", Response = (int)HttpStatusCode.NotFound });
                }
                return Ok(new ServiceResponse<int> { Data = result, Message = "employee deleted successfully", Response = (int)HttpStatusCode.OK });
            }
            catch (Exception ) {
                return BadRequest(new ServiceResponse<Employee> { Data = null, Message = "Page not Found", Response = (int)HttpStatusCode.BadRequest });
            }
        }

        [HttpPut]
        [Route("UpdateEmployee/{id}")]
        public IActionResult EditEmployee([FromForm] Employee employee) 
        {
            try {
                var result = _empService.UpdateEmployee(employee.ID,employee);
                if (result == null) {
                    return this.NotFound(new ServiceResponse<Employee> { Data = null, Message = "internal server error", Response = (int)HttpStatusCode.NotFound });
                }
                return Ok(new ServiceResponse<Employee> { Data = result, Message = "edited successfully", Response = (int)HttpStatusCode.OK });
            }catch (Exception)
            {
                return BadRequest(new ServiceResponse<Employee> { Data = null, Message = "Page not Fount", Response = (int)HttpStatusCode.BadRequest });
            }
        }
    }
}
