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
    public class EmployeeSkillManager : IQuery<EmployeeSkill>, ICommand<EmployeeSkill>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeSkillManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<EmployeeSkill>> GetAsync(Expression<Func<EmployeeSkill, bool>> predicate)
        {
            return (await _unitOfWork.EmployeeSkills.FindAsync(predicate)).ToList();
        }

        public async Task<IEnumerable<EmployeeSkill>> GetAllAsync()
        {
            return await _unitOfWork.EmployeeSkills.GetAllAsync();
        }

        public async Task<EmployeeSkill> GetAsync(int EmployeeSkillId)
        {
            return await _unitOfWork.EmployeeSkills.GetAsync(EmployeeSkillId);
        }

        public async Task Create(EmployeeSkill entity)
        {
            _unitOfWork.EmployeeSkills.Add(entity);
            await _unitOfWork.Complete();
        }

        public async Task Update(EmployeeSkill entity)
        {
            var employeeSkill = await _unitOfWork.EmployeeSkills.GetAsync(entity.EmployeeSkillId);

            employeeSkill.Skill = entity.Skill;

            await _unitOfWork.Complete();
        }

        public async Task Delete(EmployeeSkill entity)
        {
            _unitOfWork.EmployeeSkills.Remove((await _unitOfWork.EmployeeSkills.GetAllAsync()).FirstOrDefault(x => x.EmployeeSkillId == entity.EmployeeSkillId));

            await _unitOfWork.Complete();
        }
    }
}
