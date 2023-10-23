using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskManagementSystem.ViewModels
{
    public class TaskCreateViewModel
    {
        [Required]
        public string TaskTitle { get; set; }

        [Required]
        public DateTime DeadlineDate { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required]
        [Display(Name = "Team Members")]
        public List<int> SelectedTeamMembers { get; set; }

        public SelectList Departments { get; set; }
        public MultiSelectList TeamMembers { get; set; }

        // New property to handle the attachment file.
        [Display(Name = "Attachment")]
        public HttpPostedFileBase AttachmentFile { get; set; }
    }
}

