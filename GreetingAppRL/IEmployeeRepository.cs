using GreetingAppModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingAppRL
{
    public interface IRepository
    {
       List<EmployeeModel> Get();
       EmployeeModel Get(int id);
       EmployeeModel Add(EmployeeModel employeeData);
       int Remove(int id);
       EmployeeModel UpdateEmployee(int id, EmployeeModel employee);
    }
}
