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
            // Add as many of these lines as you need to map your objects
            CreateMap<Teacher, TeacherListItem>();
        }
    }
}
