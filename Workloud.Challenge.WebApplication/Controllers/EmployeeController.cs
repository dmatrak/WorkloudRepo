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
    public class EmployeeController : Controller
    {
        private readonly RestClient client;

        public EmployeeController()
        {
            client = new RestClient("http://workloudchallengewebservice20171228091627.azurewebsites.net/api/");
        }

        public ActionResult Index()
        {
            var request = new RestRequest("Employee", Method.GET);

            var response = client.Execute<List<EmployeeViewModel>>(request);

            if (response.Data == null)
                return RedirectToAction("Create");

            return View(response.Data);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var request = new RestRequest("Employee/" + id, Method.GET);

            var response = client.Execute<EmployeeViewModel>(request);

            return View(response.Data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeViewModel employeeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var request = new RestRequest("Employee/", Method.POST);
                    request.AddJsonBody(employeeViewModel);
                    client.Execute(request);
                    return RedirectToAction("Index");
                }

                return View(employeeViewModel);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var request = new RestRequest("Employee/" + id, Method.GET);

            var response = client.Execute<EmployeeViewModel>(request);

            if (response.Data == null)
            {
                return HttpNotFound();
            }

            return View(response.Data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeViewModel employeeViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var request = new RestRequest("Employee/" + employeeViewModel.EmployeeId, Method.PUT);
                    request.AddJsonBody(employeeViewModel);
                    client.Execute(request);

                    return View(employeeViewModel);
                }

                return RedirectToAction("Index");
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

            var request = new RestRequest("Employee/" + id, Method.GET);

            var response = client.Execute<EmployeeViewModel>(request);

            if (response == null)
            {
                return HttpNotFound();
            }

            return View(response.Data);
        }
    }
}
