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

        public EmployeeModel GetEmployee(int id)
        {  
           EmployeeModel list = _repo.Get(id);
           return list;
        }

        public EmployeeModel AddEmployee(EmployeeModel employee)
        {
          EmployeeModel data = _repo.Add(employee);
            return data;
        }

        public int RemoveEmployee(int id)
        {
          int result =  _repo.Remove(id);
          return result;
        }

        public EmployeeModel UpdateEmployee(int id, EmployeeModel employee)
        {
           EmployeeModel result= _repo.UpdateEmployee(id, employee); 
           return result;
        }

        public List<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> employees = _repo.Get();  
            return employees;
        }
    }
}
