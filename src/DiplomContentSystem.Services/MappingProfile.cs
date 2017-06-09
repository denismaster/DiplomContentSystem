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
                .ForMember(item => item.Position, opt => opt.MapFrom(src => (src.Position != null) ? src.Position.Name : null))
                .ForMember(item => item.WorkCount, opt => opt.MapFrom(src => src.Students.Count));

            CreateMap<TeacherEditItem, Teacher>()
                .ForMember(item => item.Id, opt => opt.MapFrom(src => src.Id == null ? 0 : src.Id))
                .ForMember(item => item.PositionId, opt => opt.MapFrom(src => src.PositionId))
                .ForMember(item => item.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId))
                .ForMember(item => item.Position, opt => opt.Ignore())
                .ForMember(item => item.Department, opt => opt.Ignore());

            CreateMap<Template, TemplateListItem>()
                .ForMember(item => item.TemplateType, opt=>opt.MapFrom(src=>(src.TemplateType!=null)?src.TemplateType.Name:null));

            CreateMap<User, UserListItem>();
            CreateMap<Department, DepartmentListItem>()
            .ForMember(item => item.SpecialityCount, opt => opt.MapFrom(src => src.Specialities.Count));

            CreateMap<DepartmentEditItem, Department>()
                .ForMember(item => item.Id, opt => opt.MapFrom(src => src.Id == null ? 0 : src.Id))
                .ForMember(item => item.InstituteId, opt => opt.UseValue(1))
                .ForMember(item => item.Specialities, opt => opt.Ignore());

            CreateMap<UserEditItem, User>()
                .ForMember(item => item.Id, opt => opt.MapFrom(src => src.Id == null ? 0 : src.Id))
                .ForMember(item => item.PasswordHash, opt => opt.MapFrom(src => PasswordUtils.Hash(src.Password)));

            CreateMap<Group, GroupListItem>()
                .ForMember(item => item.Speciality, opt => opt.MapFrom(src => (src.Speciality != null) ? src.Speciality.Name : null))
                .ForMember(item => item.Department, opt => opt.MapFrom(src => (src.Speciality.Department != null) ? src.Speciality.Department.ShortName : null))
                .ForMember(item => item.StudentsCount, opt => opt.MapFrom(src => src.Students.Count));
            
            CreateMap<Speciality, SpecialityListItem>()
                .ForMember(item => item.Department, opt => opt.MapFrom(src => (src.Department != null) ? src.Department.Name : null))
                .ForMember(item=>item.Code, opt=>opt.MapFrom(src=>src.Сode))
                .ForMember(item => item.GroupCount, opt=>opt.Ignore());


            CreateMap<GroupEditItem, Group>()
                .ForMember(item => item.Id, opt => opt.MapFrom(src => src.Id == null ? 0 : src.Id))
                .ForMember(item => item.Period, opt => opt.MapFrom(src => Period.Current))
                .ForMember(item => item.SpecialityId, opt => opt.MapFrom(src => src.SpecialityId))
                .ForMember(item => item.PeriodId, opt => opt.Ignore())
                .ForMember(item => item.Speciality, opt => opt.Ignore());

            CreateMap<IStage,CalendarEventListItem>();

            CreateMap<Student, StudentListItem>()
                .ForMember(item => item.DiplomWork, opt => opt.MapFrom(src => (src.DiplomWork != null) ? src.DiplomWork.Name : null))
                .ForMember(item => item.Group, opt => opt.MapFrom(src => (src.Group != null) ? src.Group.Name : null))
                .ForMember(item => item.Teacher, opt => opt.MapFrom(src => (src.Teacher != null) ? src.Teacher.FIO : null));

            CreateMap<DiplomWork, DiplomWorkListItem>()
                .ForMember(item => item.Teacher, opt => opt.MapFrom(src => (src.Teacher != null) ? src.Teacher.FIO : null));
        }
    }
}
