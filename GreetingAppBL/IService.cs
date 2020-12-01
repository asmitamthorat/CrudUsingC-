using GreetingAppModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingAppBL
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
