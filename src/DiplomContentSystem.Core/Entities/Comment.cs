﻿using System;
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

        public int UserId { get;set; }
        public User User {get;set;}

        
    }
}
