using GreetingAppModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingAppRL
{
    public interface IEmployeeRepository
    {
       List<EmployeeModel> GetEmployees();
       EmployeeModel GetEmployee(int id);
       EmployeeModel AddEmployee(EmployeeModel employeeData);
       int RemoveEmployee(int id);
       EmployeeModel UpdateEmployee(int id, EmployeeModel employee);
    }
}
