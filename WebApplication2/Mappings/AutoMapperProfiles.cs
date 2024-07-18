using AutoMapper;
using WebApplication2.Models.Domain;
using WebApplication2.Models.DTO;

namespace WebApplication2.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<AddStudentRequestDto, Student>().ReverseMap();
            CreateMap<UpdateStudentRequestDto, Student>().ReverseMap();
            CreateMap<AddDepartmentRequestDto, Department>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
        }
    }
}
