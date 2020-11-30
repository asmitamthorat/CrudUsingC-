
using Greetings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greetings.Services
{
    public interface IService
    {
        ServiceResponse<List<Employee>> GetEmployees();
        ServiceResponse<Employee> GetEmployee(int id);

        ServiceResponse<Employee> AddEmployee(Employee employee);

        ServiceResponse<Employee> RemoveEmployee(int id);

        ServiceResponse<Employee> UpdateEmployee(int id, Employee employee);
    }
}
