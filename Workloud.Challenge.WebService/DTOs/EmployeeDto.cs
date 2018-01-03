using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workloud.Challenge.WebService.DTOs
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime HireDate { get; set; }

        public string PhoneNumber { get; set; }

        public decimal? Salary { get; set; }

        public decimal? Bonus { get; set; }
    }
}