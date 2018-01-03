using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workloud.Challenge.Domain;

namespace Workloud.Challenge.Abstractions
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }
}
