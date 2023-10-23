using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskManagementSystem.ViewModels
{
    public class UserCreateViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public SelectList Departments { get; set; }
    }

}