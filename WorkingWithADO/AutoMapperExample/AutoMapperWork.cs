using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMapperExample
{
    class AutoMapperWork
    {
        public void EmployeeDTOObject()
        {

            //Initialize the mapper
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<Employee, EmployeeDTO>()
                          .ForMember(dest => dest.FullName, act => act.MapFrom(src => src.Name))
                          .ForMember(dest => dest.Dept, act => act.MapFrom(src => src.Department))
                          .ForMember(dest => dest.City, act => act.MapFrom(src => src.address.State))
                          .ForMember(dest => dest.State, act => act.MapFrom(src => src.address.State))
                          .ForMember(dest => dest.Country, act => act.MapFrom(src => src.address.Country))
            );

            //Creating the source object

            Address empAddres = new Address()
            {
                City = "Mumbai",
                State = "Maharashtra",
                Country = "India"
            };

            Employee emp = new Employee
            {
                Name = "Selva",
                Salary = 21000,
                Address = "Chennai",
                Department = "IT",
                address = empAddres
            };

           //Using automapper
            IMapper mapper = config.CreateMapper();

            EmployeeDTO empDTO = mapper.Map<Employee, EmployeeDTO>(emp);

            //Console.WriteLine("Name:" + empDTO.FullName + ", Salary:" + empDTO.Salary +
            //                  ", Address:" + empDTO.Address + ", Department:" + empDTO.Dept);

            Console.WriteLine("Name:" + empDTO.FullName + ", Salary:" + empDTO.Salary + ", Department:" + empDTO.Dept);
            Console.WriteLine("City:" + empDTO.City + ", State:" + empDTO.State + ", Country:" + empDTO.Country);
        }
    }
}
