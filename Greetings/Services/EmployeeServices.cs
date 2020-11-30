using AutoMapper;

using Greetings.Models;
using Greetings.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greetings.Services
{
   

    public class EmployeeServices:IService
    {
        IMapper _mapper;
        IRepository<Employee> _repo;

        public EmployeeServices(IMapper mapper, IRepository<Employee> repo) {
            _mapper = mapper;
            _repo = repo;
        }

        //public ServiceRespose<List<Employee>> IService.GetEmployees()
        //{
        //    ServiceResponse<List<Employee>> serviceResponse = new ServiceResponse<List<Employee>>();
        //    List<Employee> employees = _repo.Get();
        //    serviceResponse.Data = employees.Select(employee => _mapper.Map<Employee>(employee)).ToList();
        //    return serviceResponse;
        //}


        public ServiceResponse<Employee> GetEmployee(int id)
        {
            ServiceResponse<Employee> serviceResponse = new ServiceResponse<Employee>();
            serviceResponse.Data = _repo.Get(id);
            return serviceResponse;
        
        }

        public ServiceResponse<Employee> AddEmployee(Employee employee)
        {
            ServiceResponse<Employee> serviceResponse = new ServiceResponse<Employee>();
            serviceResponse.Data = employee;
            _repo.Add(employee);
            return serviceResponse;
        }


        public ServiceResponse<Employee> RemoveEmployee(int id)
        {
            ServiceResponse<Employee> serviceResponse = new ServiceResponse<Employee>();
            _repo.Remove(id);
            serviceResponse.Message = "Deleted Successfully";
            return serviceResponse;
        
        }


        public ServiceResponse<Employee> UpdateEmployee(int id, Employee employee)         
        {
            ServiceResponse<Employee> serviceResponse = new ServiceResponse<Employee>();
            _repo.UpdateEmployee( id,  employee);
            serviceResponse.Message = "Updated Successfully";
            return serviceResponse;
        }

        public ServiceResponse<List<Employee>> GetEmployees()
        {
            ServiceResponse<List<Employee>> serviceResponse = new ServiceResponse<List<Employee>>();
            List<Employee> employees = _repo.Get();
            serviceResponse.Data = employees;
            return serviceResponse;
        }
    }
}
