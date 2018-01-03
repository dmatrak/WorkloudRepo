using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workloud.Challenge.Domain
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }

        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public decimal? Salary { get; set; }

        public decimal? Bonus { get; set; }

        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}
