using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workloud.Challenge.Domain
{
    public partial class EmployeeSkill
    {
        public int EmployeeSkillId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [StringLength(50)]
        [Required]
        public string Skill { get; set; }       

        public virtual Employee Employee { get; set; }
    }
}
