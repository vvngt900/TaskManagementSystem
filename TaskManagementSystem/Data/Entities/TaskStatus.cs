using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagementSystem.Data.Entities
{
    public class TaskStatus
    {
        public int TaskStatusID { get; set; }
        public string Name { get; set; }

        // Add a navigation property to link tasks to this status.
        public virtual ICollection<Task> Tasks { get; set; }
    }

}