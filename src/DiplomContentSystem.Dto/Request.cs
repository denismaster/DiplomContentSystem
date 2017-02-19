using System;
using System.Collections.Generic;
namespace  DiplomContentSystem.Dto
{
    public class Request
    {
        public int Skip {get;set;}
        public int Take {get;set;}
        public IEnumerable<SortingParam> Sortings {get;set;}
    }    
}