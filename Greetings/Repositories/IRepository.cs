using Greetings.DTOs.EmployeeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greetings.Repositories
{
   public interface IRepository<T>
    {
        List<T> Get();
        T Get(int id);

       void Add(T employeeData);

        void Remove(int id);

        void UpdateEmployee(int id, EmployeesDTO employee);

    }
}
