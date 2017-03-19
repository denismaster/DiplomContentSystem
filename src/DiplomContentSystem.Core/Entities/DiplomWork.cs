﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class DiplomWork : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int PeriodId { get; set; }
        public Period Period { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public List<Student> Students { get; set; }
        public List<DiplomWorkMaterial> DiplomWorkMaterials { get; set; }
        public List<Stage> Stages { get; set; }
        public List<DiplomWorkComment> DiplomWorkComments { get; set; }
    }
}
