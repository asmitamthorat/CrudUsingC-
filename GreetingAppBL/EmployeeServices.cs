using GreetingAppModelLayer;
using GreetingAppRL;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingAppBL
{
    public class EmployeeServices:IEmployeeService
    {
        IEmployeeRepository _repo;

        public EmployeeServices(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public EmployeeModel GetEmployee(int id)
        {  
           EmployeeModel list = _repo.GetEmployee(id);
           return list;
        }

        public EmployeeModel AddEmployee(EmployeeModel employee)
        {
          EmployeeModel data = _repo.AddEmployee(employee);
            return data;
        }

        public int RemoveEmployee(int id)
        {
          int result =  _repo.RemoveEmployee(id);
          return result;
        }

        public EmployeeModel UpdateEmployee(int id, EmployeeModel employee)
        {
           EmployeeModel result= _repo.UpdateEmployee(id, employee); 
           return result;
        }

        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> employees = _repo.GetEmployees();  
            return employees;
        }
    }
}
