namespace Workloud.Challenge.DataAccess.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Domain;
    using Abstractions;

    public partial class WorkloudDbContext : DbContext, IDbContext
    {
        public WorkloudDbContext()
            : base("name=WorkloudChallengeDBConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<EmployeeSkill>().ToTable("EmployeeSkill");
        }
    }
}
