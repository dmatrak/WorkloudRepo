using System;
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
    public class EmployeeController : ApiController
    {
        #region private Fields

        private readonly IQuery<Employee> _employeeQuery;
        private readonly ICommand<Employee> _employeeCommand;

        #endregion

        #region ctor

        public EmployeeController(IQuery<Employee> employeeQuery, ICommand<Employee> employeeCommand)
        {
            _employeeQuery = employeeQuery;
            _employeeCommand = employeeCommand;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _employeeQuery.GetAllAsync();
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            var employee = await _employeeQuery.GetAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            EmployeeDto employeeDto = new EmployeeDto
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                HireDate = employee.HireDate,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary,
                Bonus = employee.Bonus
            };

            return Ok(employeeDto);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, ModelState);
            }

            /* Prevent post if the First Name and Last Name already exists */
            var employees = await _employeeQuery.GetAllAsync();

            if (employees.Any(c => c.FirstName == employee.FirstName && c.LastName == employee.LastName))
            {
                return Content(HttpStatusCode.Forbidden, ModelState);
            }

            try
            {
                await _employeeCommand.Create(employee);
                return Content(HttpStatusCode.Created, employee);
            }
            catch
            {
                return Content(HttpStatusCode.Conflict, employee);
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put([FromBody]Employee employee)
        {
            try
            {
                Employee employeeFound = await _employeeQuery.GetAsync(employee.EmployeeId);

                if (employeeFound == null)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                /* Prevent update if the updated First Name and Last Name is the same as another employee */
                var employees = await _employeeQuery.GetAllAsync();

                if (employees.Where(x => x.EmployeeId != employee.EmployeeId).Any(c => c.FirstName == employee.FirstName && c.LastName == employee.LastName))
                {
                    return Content(HttpStatusCode.Forbidden, ModelState);
                }

                employeeFound.FirstName = employee.FirstName;
                employeeFound.LastName = employee.LastName;
                employeeFound.HireDate = employee.HireDate;
                employeeFound.PhoneNumber = employee.PhoneNumber;
                employeeFound.Salary = employee.Salary;
                employeeFound.Bonus = employee.Bonus;

                await _employeeCommand.Update(employeeFound);
                return Ok(employeeFound);
            }
            catch
            {
                return Content(HttpStatusCode.Conflict, employee);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                Employee employeeFound = (await _employeeQuery.GetAsync(x => x.EmployeeId == id)).FirstOrDefault();

                if (employeeFound == null)
                {
                    return NotFound();
                }

                await _employeeCommand.Delete(employeeFound);

                return Content(HttpStatusCode.NoContent, employeeFound);
            }
            catch
            {
                return Content(HttpStatusCode.Conflict, id);
            }
        }
    }
    #endregion
}
