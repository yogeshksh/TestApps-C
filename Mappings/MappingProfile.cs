using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TestApplication.Models;

namespace TestApplication

{
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Mapping profile to map the Data model object with view model object which will be returned in API response
        /// </summary>
        public MappingProfile()
        {
           
            CreateMap<Employee, EmployeeViewModel>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.HireDate, opt => opt.MapFrom(src => src.HireDate));          
        }
    }
}

