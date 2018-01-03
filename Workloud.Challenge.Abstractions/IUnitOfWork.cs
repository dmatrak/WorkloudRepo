using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workloud.Challenge.Abstractions
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employee { get; }

        IEmployeeSkillsRepository EmployeeSkills { get; }
        
        Task<int> Complete();
    }
}
