using GreetingAppModelLayer;
using GreetingAppRL;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingAppBL
{
    public class EmployeeServices:IService
    {
        IRepository _repo;

        public EmployeeServices(IRepository repo)
        {
            _repo = repo;
        }

        public Employee GetEmployee(int id)
        {  
           Employee list = _repo.Get(id);
           return list;
        }

        public Employee AddEmployee(Employee employee)
        {
          Employee data = _repo.Add(employee);
            return data;
        }

        public int RemoveEmployee(int id)
        {
          int result =  _repo.Remove(id);
          return result;
        }

        public Employee UpdateEmployee(int id, Employee employee)
        {
           Employee result= _repo.UpdateEmployee(id, employee); 
           return result;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = _repo.Get();  
            return employees;
        }
    }
}
