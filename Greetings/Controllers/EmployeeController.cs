

using Greetings.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GreetingAppBL;
using GreetingAppModelLayer;
using Employee = GreetingAppModelLayer.Employee;

namespace Greetings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private IService _empService;

        public EmployeeController(IService empService) {
            this._empService = empService;   
        }

        public IActionResult Get() 
        {          
            try
            {
                return Ok(_empService.GetEmployees());

            } catch (Exception e) {

                return this.BadRequest();
            }          
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                return Ok(_empService.GetEmployee(id));
            }
            catch (Exception e)
            {
                return this.BadRequest();
            }
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            try {
                return Ok(_empService.AddEmployee(employee));
            }
            catch (Exception e) {
                return this.BadRequest();
            }





            //if (employee.Name == null && employee.Email == null)
            //{
            //    throw new ArgumentNullException("you haven't provided any data");
            //}
            //else
            //{
            //    return Ok(_empService.AddEmployee(employee));
            //}
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try {
                return Ok(_empService.RemoveEmployee(id));
            }
            catch (Exception e) {
              return  this.BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult EditEmployee(int id, Employee employee) 
        {
            try {
                return Ok(_empService.UpdateEmployee(id, employee));
            }catch (Exception) {
                return this.BadRequest();
            }   
        }

      


       
    }
}
