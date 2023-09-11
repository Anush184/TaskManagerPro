﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerPro.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }  
        public DateTime CreatedAt { get; set; }  
        public DateTime? UpdatedAt { get; set; }  
        public bool IsClosed { get; set; }  

        protected BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
