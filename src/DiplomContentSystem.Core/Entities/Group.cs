﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class Group : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; }

        public int PeriodId {get;set;}
        public Period Period {get;set;}
        
        public List<Student> Students { get; set; }
    }
}
