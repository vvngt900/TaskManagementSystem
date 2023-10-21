using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagementSystem.Data.Entities
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string Name { get; set; }

        // Add a navigation property to represent the tasks associated with this department.
        public virtual ICollection<Task> Tasks { get; set; }

        // Add a navigation property to represent the users in this department.
        public virtual ICollection<User> Users { get; set; }
    }

}