using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workloud.Challenge.Abstractions;

namespace Workloud.Challenge.DataAccess.EntityFramework
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly IDbContext _dbContext;

        public UnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
            Employee = new EmployeeRepository(dbContext);
            EmployeeSkills = new EmployeeSkillsRepository(dbContext);
        }

        public IEmployeeRepository Employee { get; }

        public IEmployeeSkillsRepository EmployeeSkills { get; }

        public Task<int> Complete()
        {
            return _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
