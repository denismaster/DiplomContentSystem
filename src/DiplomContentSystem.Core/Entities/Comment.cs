using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        //Автор
        public List<TeacherComment> TeacherComments { get; set; }

        public List<StudentComment> StudentComments { get; set; }

        //Комментируемы объект
        public List<DiplomWorkComment> DiplomWorkComments { get; set; }

        public List<DiplomWorkMaterialComment> DiplomWorkMaterialComments { get; set; }

        public List<ImplementationStageComment> ImplementationStageComments { get; set; }

        public List<SubImplementationStageComment> SubImplementationStageComments { get; set; }

        public List<GostControlTryComment> GostControlTryComments { get; set; }
    }
}
