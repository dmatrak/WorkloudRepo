using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Workloud.Challenge.Abstractions;
using Workloud.Challenge.Domain;
using Workloud.Challenge.WebService.DTOs;

namespace Workloud.Challenge.WebService.Controllers
{
    [EnableCors(origins: "http://workloudchallengewebservice20171228091627.azurewebsites.net", headers: "*", methods: "*")]
    public class EmployeeSkillsController : ApiController
    {
        private readonly IQuery<EmployeeSkill> _employeeSkillQuery;
        private readonly ICommand<EmployeeSkill> _employeeSkillCommand;

        public EmployeeSkillsController(IQuery<EmployeeSkill> employeeSkillQuery, ICommand<EmployeeSkill> employeeSkillCommand)
        {
            _employeeSkillQuery = employeeSkillQuery;
            _employeeSkillCommand = employeeSkillCommand;
        }

        [HttpGet]
        [Route("api/employeeSkills/employee/{id}")]
        public async Task<IEnumerable<EmployeeSkillDto>> GetAll(int id)
        {
            var result = await _employeeSkillQuery.GetAsync(x => x.EmployeeId == id);

            List<EmployeeSkillDto> dto = new List<EmployeeSkillDto>();

            foreach (var item in result)
            {
                EmployeeSkillDto skillDto = new EmployeeSkillDto
                {
                    EmployeeSkillId = item.EmployeeSkillId,
                    EmployeeId = item.EmployeeId,
                    Skill = item.Skill
                };

                dto.Add(skillDto);
            }

            return dto;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var employeeSkill = await _employeeSkillQuery.GetAsync(id);

            if (employeeSkill == null)
            {
                return NotFound();
            }

            EmployeeSkillDto skillDto = new EmployeeSkillDto
            {
                EmployeeSkillId = employeeSkill.EmployeeSkillId,
                EmployeeId = employeeSkill.EmployeeId,
                Skill = employeeSkill.Skill
            };

            return Ok(skillDto);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(EmployeeSkill employeeSkill)
        {
            if (employeeSkill == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState);
            }

            try
            {
                await _employeeSkillCommand.Create(employeeSkill);
                return Content(HttpStatusCode.Created, employeeSkill);
            }
            catch
            {
                return Content(HttpStatusCode.Conflict, employeeSkill);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody]EmployeeSkill employeeSkill)
        {
            try
            {
                EmployeeSkill skillFound = await _employeeSkillQuery.GetAsync(employeeSkill.EmployeeSkillId);

                if (skillFound == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                skillFound.Skill = employeeSkill.Skill;

                await _employeeSkillCommand.Update(skillFound);
                return Ok(skillFound);
            }
            catch
            {
                return Content(HttpStatusCode.Conflict, employeeSkill);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                EmployeeSkill skillFound = (await _employeeSkillQuery.GetAsync(x => x.EmployeeSkillId == id)).FirstOrDefault();

                if (skillFound == null)
                {
                    return NotFound();
                }

                await _employeeSkillCommand.Delete(skillFound);

                return Content(HttpStatusCode.NoContent, skillFound);
            }
            catch
            {
                return Content(HttpStatusCode.Conflict, id);
            }
        }
    }
}
