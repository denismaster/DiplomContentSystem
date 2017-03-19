using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiplomContentSystem.Dto;
using DiplomContentSystem.Core;
namespace DiplomContentSystem.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Teacher, TeacherListItem>()
                .ForMember(item => item.Speciality, opt => opt.MapFrom(src => (src.Speciality != null) ? src.Speciality.ShortName : null))
                .ForMember(item => item.Position, opt => opt.MapFrom(src => (src.TeacherPosition != null) ? src.TeacherPosition.Name : null));
            CreateMap<TeacherEditItem, Teacher>()
                .ForMember(item => item.Id, opt => opt.MapFrom(src => src.Id == null ? 0 : src.Id))
                .ForMember(item => item.TeacherPositionId, opt => opt.MapFrom(src => src.PositionId))
                .ForMember(item => item.SpecialityId, opt => opt.UseValue(1))
                .ForMember(item => item.TeacherPosition, opt => opt.Ignore())
                .ForMember(item => item.Speciality, opt => opt.Ignore());

            CreateMap<Student, StudentListItem>()
                .ForMember(item => item.DiplomWork, opt => opt.MapFrom(src => (src.DiplomWork != null) ? src.DiplomWork.Name : null))
                .ForMember(item => item.Group, opt => opt.MapFrom(src => (src.Group != null) ? src.Group.Name : null))
                .ForMember(item => item.Teacher, opt => opt.MapFrom(src => (src.Teacher != null) ? src.Teacher.FIO : null));

            CreateMap<DiplomWork, DiplomWorkListItem>()
                .ForMember(item => item.Teacher, opt => opt.MapFrom(src => (src.Teacher != null) ? src.Teacher.FIO : null));
        }
    }
}
