using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workloud.Challenge.Abstractions;
using Workloud.Challenge.Domain;

namespace Workloud.Challenge.DataAccess.EntityFramework
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbContext dbContext) : base(dbContext)
        { }
    }
}
