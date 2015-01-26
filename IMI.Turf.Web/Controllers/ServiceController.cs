using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMI.Turf.Web.Models;
using IMI.Turf.Orchestrators;
using IMI.Turf.Repository;
using IMI.Turf.DataModels;
using AutoMapper;

namespace IMI.Turf.Web.Controllers
{
    public class ServiceController : BaseController
    {
        private IServiceRepository _repository = null;
        private ServiceOrchestrator _orchestrator = null;

        public ServiceController()
        {      
            this._repository = new ServiceRepository();
            _orchestrator = new ServiceOrchestrator();
        }
        public ServiceController(IServiceRepository serviceRepository)
        {
            _repository = serviceRepository;
        }
        //
        // GET: /Service/

        public ActionResult Index()
        {
            IEnumerable<ServiceRequest> requests = _repository.Get();
            var model = requests.Select(r => new ServiceRequestViewModel(r)).ToList();

            return View(model);
        }


        //
        // GET: /Service/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Service/Create
        [HttpPost]
        [Authorize]
        public JsonResult Create(ServiceRequest model)
        {
            try
            {
                ///ServiceRequest serviceRequest = Mapper.Map<ServiceRequestViewModel, ServiceRequest>(model);
                model.CreatedDate = DateTime.Now;
                model.CreatedBy = CurrentUser.UserId;
                _repository.Create(model);
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        //
        // GET: /Service/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Service/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Service/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Service/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public JsonResult GetCategories()
        {
            var categories = _repository.GetServiceCategories();
            return Json(categories, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetRequests()
        {
            IEnumerable<ServiceRequest> requests = _repository.Get();
            var model = requests.Select(r => new ServiceRequestViewModel(r)).ToList();

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
