using AutoMapper;
using DiplomContentSystem.Dto;
using DiplomContentSystem.Core;
namespace DiplomContentSystem.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Teacher, TeacherListItem>()
                .ForMember(item => item.Department, opt => opt.MapFrom(src => (src.Department != null) ? src.Department.ShortName : null))
                .ForMember(item => item.Position, opt => opt.MapFrom(src => (src.Position != null) ? src.Position.Name : null));
            
            CreateMap<Group, GroupListItem>()
                .ForMember(item => item.Speciality, opt => opt.MapFrom(src => (src.Speciality != null) ? src.Speciality.Name : null))
                .ForMember(item => item.Department, opt => opt.MapFrom(src => (src.Speciality.Department != null) ? src.Speciality.Department.ShortName : null));
                //.ForMember(item=> item.StudentsCount, opt=>opt.MapFrom)

            CreateMap<TeacherEditItem, Teacher>()
                .ForMember(item => item.Id, opt => opt.MapFrom(src => src.Id == null ? 0 : src.Id))
                .ForMember(item => item.PositionId, opt => opt.MapFrom(src => src.PositionId))
                .ForMember(item => item.DepartmentId, opt => opt.MapFrom(src=>src.DepartmentId))
                .ForMember(item => item.Position, opt => opt.Ignore())
                .ForMember(item => item.Department, opt => opt.Ignore());

            CreateMap<Student, StudentListItem>()
                .ForMember(item => item.DiplomWork, opt => opt.MapFrom(src => (src.DiplomWork != null) ? src.DiplomWork.Name : null))
                .ForMember(item => item.Group, opt => opt.MapFrom(src => (src.Group != null) ? src.Group.Name : null))
                .ForMember(item => item.Teacher, opt => opt.MapFrom(src => (src.Teacher != null) ? src.Teacher.FIO : null));

            CreateMap<DiplomWork, DiplomWorkListItem>()
                .ForMember(item => item.Teacher, opt => opt.MapFrom(src => (src.Teacher != null) ? src.Teacher.FIO : null));
        }
    }
}
