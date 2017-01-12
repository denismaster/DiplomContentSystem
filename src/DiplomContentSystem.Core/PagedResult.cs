using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiplomContentSystem.Core
{
    public class PagedResult<T> where T:class, IEntity
    {
        public IEnumerable<T> Items { get; set; }
        public long TotalCount { get; set; }
        public long LoadedCount { get;set; }
    }
}
