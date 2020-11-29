using Greetings.DTOs.EmployeeDTO;
using Greetings.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return Ok(_empService.GetEmployees());
        }

        [HttpGet("{id}")]
        public IActionResult Detail(int id)
        {
            return Ok(_empService.GetEmployee(id));
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeesDTO employee)
        {
            return Ok(_empService.AddEmployee(employee));
        
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return Ok(_empService.RemoveEmployee(id));
        
        }

        [HttpPut("{id}")]
        public IActionResult EditEmployee(int id, EmployeesDTO employee) 
        {
            return Ok(_empService.UpdateEmployee(id, employee));
        }

      


       
    }
}
