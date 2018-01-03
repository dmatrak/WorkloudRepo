using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workloud.Challenge.Abstractions;
using Workloud.Challenge.Domain;

namespace Workloud.Challenge.DataAccess.EntityFramework
{
    public class EmployeeSkillsRepository : Repository<EmployeeSkill>, IEmployeeSkillsRepository
    {
        public EmployeeSkillsRepository(IDbContext dbContext) : base(dbContext)
        { }
    }
}
