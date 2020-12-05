using GreetingAppModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingAppRL
{
    public interface IRepository
    {
       List<Employee> Get();
       Employee Get(int id);

       Employee Add(Employee employeeData);

       int Remove(int id);
       Employee UpdateEmployee(int id, Employee employee);
    }
}
