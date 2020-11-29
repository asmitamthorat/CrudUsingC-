using Greetings.DTOs.EmployeeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greetings.Services
{
    public interface IService
    {
        ServiceResponse<List<EmployeesDTO>> GetEmployees();
        ServiceResponse<EmployeesDTO> GetEmployee(int id);

        ServiceResponse<EmployeesDTO> AddEmployee(EmployeesDTO employee);

        ServiceResponse<EmployeesDTO> RemoveEmployee(int id);
    }
}
