using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workloud.Challenge.WebService.DTOs
{
    public class EmployeeSkillDto
    {
        public int EmployeeSkillId { get; set; }

        public int EmployeeId { get; set; }

        public string Skill { get; set; }
    }
}