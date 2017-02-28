using System;
using System.Collections.Generic;

namespace DiplomContentSystem.Core
{
    public class PagedEnumerable<T> where T:class, IEntity
    {
        public IEnumerable<T> Items { get; set; }
        public long TotalCount { get; set; }
    }
}
