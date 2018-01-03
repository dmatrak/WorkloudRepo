using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Workloud.Challenge.Abstractions;
using Workloud.Challenge.Domain;

namespace Workloud.Challenge.Business
{
    public class EmployeeManager : IQuery<Employee>, ICommand<Employee>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Employee>> GetAsync(Expression<Func<Employee, bool>> predicate)
        {
            return await _unitOfWork.Employee.FindAsync(predicate);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _unitOfWork.Employee.GetAllAsync();
        }

        public async Task<Domain.Employee> GetAsync(int EmployeeId)
        {
            return await _unitOfWork.Employee.GetAsync(EmployeeId);
        }

        public async Task Create(Employee entity)
        {
            _unitOfWork.Employee.Add(entity);
            await _unitOfWork.Complete();
        }

        public async Task Update(Employee entity)
        {
            var employee = await _unitOfWork.Employee.GetAsync(entity.EmployeeId);

            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
            employee.HireDate = entity.HireDate;
            employee.PhoneNumber = entity.PhoneNumber;
            employee.Salary = entity.Salary;
            employee.Bonus = entity.Bonus;

            await _unitOfWork.Complete();
        }

        public async Task Delete(Employee entity)
        {
            _unitOfWork.EmployeeSkills.RemoveRange(await _unitOfWork.EmployeeSkills.FindAsync(x => x.EmployeeId == entity.EmployeeId));
            _unitOfWork.Employee.Remove((await _unitOfWork.Employee.GetAllAsync()).FirstOrDefault(x => x.EmployeeId == entity.EmployeeId));
            await _unitOfWork.Complete();
        }
    }
}
