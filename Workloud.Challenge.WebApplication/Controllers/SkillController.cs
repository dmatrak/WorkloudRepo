using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Workloud.Challenge.WebApplication.ViewModels;

namespace Workloud.Challenge.WebApplication.Controllers
{
    public class SkillController : Controller
    {
        private readonly RestClient client;

        public SkillController()
        {
            client = new RestClient("http://workloudchallengewebservice20171228091627.azurewebsites.net/api/employeeSkills");
        }
         
        public ActionResult Get(int id)
        {
            //RestClient client2 = new RestClient("http://workloudchallengewebservice20171228091627.azurewebsites.net/api/employeeSkills");

            var request = new RestRequest("employee/" + id.ToString(), Method.GET);

            var response = client.Execute<List<EmployeeSkillViewModel>>(request);

            if (response.Data == null)
                return RedirectToAction("Get", id);

            ViewBag.EmployeeId = id;

            return View(response.Data);
        }

        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EmployeeSkillViewModel skillViewModel = new EmployeeSkillViewModel();

            skillViewModel.EmployeeId = (int)id;

            return View(skillViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeSkillViewModel employeeSkillViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var request = new RestRequest(Method.POST);
                    request.AddJsonBody(employeeSkillViewModel);
                    client.Execute(request);
                    return RedirectToAction("Get", new { id = employeeSkillViewModel.EmployeeId});
                }

                return View(employeeSkillViewModel);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var request = new RestRequest(id.ToString(), Method.GET);

            var response = client.Execute<EmployeeSkillViewModel>(request);

            if (response == null)
            {
                return HttpNotFound();
            }

            return View(response.Data);
        }

    }
}
