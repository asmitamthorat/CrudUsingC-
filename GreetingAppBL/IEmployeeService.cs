using GreetingAppModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingAppBL
{
    public interface IService
    {
       List<EmployeeModel> GetEmployees();
       EmployeeModel GetEmployee(int id);
       EmployeeModel AddEmployee(EmployeeModel employee);
       int RemoveEmployee(int id);
        EmployeeModel UpdateEmployee(int id, EmployeeModel employee);
    }
}
