using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Workloud.Challenge.WebApplication.ViewModels
{
    public class EmployeeSkillViewModel
    {
        public int EmployeeSkillId { get; set; }

        [Required]
        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }

        [Required]
        public string Skill { get; set; }
    }
}