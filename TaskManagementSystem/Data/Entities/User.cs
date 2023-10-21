using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagementSystem.Data.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Username { get; set; }

        // Add a navigation property to represent the tasks assigned to this user.
        public virtual ICollection<Task> AssignedTasks { get; set; }

        // Add a foreign key property to link to the Department.
        public int DepartmentID { get; set; }

        // Add a navigation property to represent the department.
        public virtual Department Department { get; set; }
    }

}