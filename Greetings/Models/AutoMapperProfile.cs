using AutoMapper;
using Greetings.DTOs.EmployeeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greetings.Models
{
    public class AutoMapperProfile:Profile
    {
       public AutoMapperProfile() {
            CreateMap<Employee, EmployeesDTO>();
            CreateMap<EmployeesDTO, Employee>();

        }
        
    }
}
