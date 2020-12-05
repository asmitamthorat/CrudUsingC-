using GreetingAppModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingAppBL
{
    public interface IService
    {
       List<Employee> GetEmployees();
       Employee GetEmployee(int id);
       Employee AddEmployee(Employee employee);
       int RemoveEmployee(int id);
        Employee UpdateEmployee(int id, Employee employee);
    }
}
