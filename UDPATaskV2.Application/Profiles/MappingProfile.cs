using AutoMapper;
using UDPATaskV2.Application.DTOs.Departments;
using UDPATaskV2.Application.DTOs.Employee;
using UDPATaskV2.Domain.Entities;

namespace UDPATaskV2.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            #region Department Mapping

            CreateMap<Departments, CreateNewDepartmentDto>().ReverseMap();
            CreateMap<Departments, DeleteDepartmentDto>().ReverseMap();
            CreateMap<Departments,UpdateDepartmentDto>().ReverseMap();
            CreateMap<Departments, GetDepartmentDetailDto>().ReverseMap();
            CreateMap<Departments, GetDepartmentDetailListDto>().ReverseMap();

            #endregion

            #region Employee Mapping 

            CreateMap<Employee, CreateNewEmployeeDto>().ReverseMap();
            CreateMap<Employee, GetEmployeeDetailListDto>().ReverseMap();
            CreateMap<Employee, GetEmployeeDetailDto>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDto>().ReverseMap();

            #endregion



        }
    }
}
