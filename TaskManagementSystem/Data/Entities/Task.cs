using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagementSystem.Data.Entities
{
    public class Task
    {
        public int TaskID { get; set; }
        public string Title { get; set; }
        public DateTime DeadlineDate { get; set; }
        public string Attachment { get; set; }

        // Add a navigation property to represent the users assigned to this task.
        public virtual ICollection<User> AssignedUsers { get; set; }

        // Add a navigation property to represent the department associated with this task.
        public virtual Department Department { get; set; }

        // Add a navigation property to represent the comments for this task.
        public virtual ICollection<Comment> Comments { get; set; }
    }

}