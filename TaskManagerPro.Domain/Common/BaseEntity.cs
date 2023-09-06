using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerPro.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }  // Unique identifier for the entity
        public DateTime CreatedAt { get; set; }  // Date and time the entity was created
        public DateTime? UpdatedAt { get; set; }  // Date and time the entity was last updated (nullable)
        public bool IsDeleted { get; set; }  // Flag indicating if the entity is deleted

        // Constructor to initialize CreatedAt to the current date and time
        protected BaseEntity()
        {
            CreatedAt = DateTime.Now;
        }
    }
}
