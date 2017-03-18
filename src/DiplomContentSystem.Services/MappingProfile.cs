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
                .ForMember(item => item.Speciality, opt => opt.MapFrom(src => (src.Speciality!=null)?src.Speciality.ShortName:null))
                .ForMember(item => item.Position, opt => opt.MapFrom(src => (src.Position!=null)?src.Position.Name:null));
            CreateMap<TeacherEditItem, Teacher>()
                .ForMember(item=>item.Id, opt=>opt.MapFrom(src=>src.Id==null?0:src.Id))
                .ForMember(item=>item.PositionId,opt=>opt.MapFrom(src=>src.PositionId))
                .ForMember(item=>item.SpecialityId, opt=>opt.UseValue(1))
                .ForMember(item=>item.Position, opt=>opt.Ignore())
                .ForMember(item=>item.Speciality, opt=>opt.Ignore());
        }
    }
}
