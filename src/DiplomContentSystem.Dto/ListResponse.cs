using System.Collections.Generic;
namespace DiplomContentSystem.Dto
{
    public class ListResponse<T>
    {
        public IEnumerable<T> Items {get;set;}
        public long TotalCount{get;set;}
    }
}