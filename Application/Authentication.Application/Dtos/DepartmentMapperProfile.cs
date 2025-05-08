using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.Domain.Models;
using AutoMapper;

namespace Authentication.Application.Dtos
{
    public class DepartmentMapperProfile : Profile
    {
        public DepartmentMapperProfile()
        {
            // Map between Department and DepartmentGetDto
            CreateMap<Department, DepartmentGetDto>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.DepartmentName))
                .ForMember(dest => dest.ParentDepartmentName, opt => opt.MapFrom(src => src.ParentDepartmentName));

            // Map between CreateDepartmentDto and Department
            CreateMap<CreateDepartmentDto, Department>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.DepartmentName))
                .ForMember(dest => dest.ParentDepartmentName, opt => opt.MapFrom(src => src.ParentDepartmentName));

            // Additional mapping for DepartmentFakeDeleteDto
            CreateMap<DepartmentFakeDeleteDto, Department>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted));
        }

    }
}
