using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagementSystem.Data.Entities
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign key property to relate Comment to User.
        public int UserID { get; set; }

        // Navigation property to access the associated User.
        public virtual User User { get; set; }
    }

}