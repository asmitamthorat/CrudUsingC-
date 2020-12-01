using GreetingAppModelLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreetingAppRL
{
    public interface IRepository<T>
    {
        List<T> Get();
        T Get(int id);

        void Add(T employeeData);

        void Remove(int id);

        void UpdateEmployee(int id, Employee employee);
    }
}
