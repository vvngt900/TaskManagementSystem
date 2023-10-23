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
        [Required(ErrorMessage = "The Task Title field is required.")]
        [StringLength(100, ErrorMessage = "The Task Title cannot exceed 100 characters.")]
        public string TaskTitle { get; set; }

        [Required(ErrorMessage = "The Deadline Date field is required.")]
        [Display(Name = "Deadline Date")]
        [DataType(DataType.Date)]
        public DateTime DeadlineDate { get; set; }

        [Required(ErrorMessage = "The Details field is required.")]
        [DataType(DataType.MultilineText)]
        public string Details { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase Attachment { get; set; }

        [Required(ErrorMessage = "The Department field is required.")]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please select at least one team member.")]
        [Display(Name = "Team Members")]
        public List<int> SelectedTeamMembers { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }

        public SelectList Departments { get; set; }
        public MultiSelectList TeamMembers { get; set; }
        public SelectList Statuses { get; set; }
    }

}

