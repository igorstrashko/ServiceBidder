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
    public class DetailsController : BaseController
    {
        private IMessageRepository _repository = null;
        private IServiceRepository _serviceRepository = null;
        private IBidRepository _bidRepository = null;
        public DetailsController()
        {      
            this._repository = new MessageRepository();
            this._serviceRepository = new ServiceRepository();
            this._bidRepository = new BidRepository();
        }
        public DetailsController(IMessageRepository messageRepository, IServiceRepository serviceRepository, IBidRepository bidRepository)
        {
            _repository = messageRepository;
            _serviceRepository = serviceRepository;
            _bidRepository = bidRepository;
        }

        //
        // GET: /Service/Details/5
        public ActionResult Details(int id)
        {
            var r = _serviceRepository.GetById(id);
            var numBids = _bidRepository.GetBids(id).Count();
            return View(new ServiceRequestViewModel(r));
        }
        //
        // POST: /Details/SendMessage
        [HttpPost]
        [Authorize]
        public JsonResult SendMessage(Message model)
        {
            try
            {
                ///ServiceRequest serviceRequest = Mapper.Map<ServiceRequestViewModel, ServiceRequest>(model);
                model.CreatedDate = DateTime.Now;
                model.FromUserId = CurrentUser.UserId;
                _repository.Create(model);
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        //
        // POST: /Details/PlaceBid
        [HttpPost]
        [Authorize]
        public JsonResult PlaceBid(Bid model)
        {
            try
            {
                model.CreatedDate = DateTime.Now;
                model.UserId = CurrentUser.UserId;
                model.ServiceRequestId = model.ServiceRequestId;
                _bidRepository.Create(model);
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        //
        // POST: /Details/GetBids
        public JsonResult GetBids(int serviceRequestId)
        {
            IEnumerable<Bid> bids = _bidRepository.GetBids(serviceRequestId);
            var model = bids.Select(r => new 
            {
                BidAmount = r.BidAmount,
                CreatedDate = r.CreatedDate.ToShortDateString(),
                UserId = r.UserId,
                UserName = r.UserProfile.UserName
            }).ToList();

            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}
