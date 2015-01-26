using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMI.Turf.Web.Models;
using IMI.Turf.Orchestrators;
using IMI.Turf.Repository;
using IMI.Turf.DataModels;

namespace IMI.Turf.Web.Controllers
{
    public class ActivityController : BaseController
    {
        private MessageRepository _messageRepository = null;
        private ServiceRepository _serviceRepository = null;
        public ActivityController()
        {
            _messageRepository = new MessageRepository();
            _serviceRepository = new ServiceRepository();
        }
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult GetMessages(int serviceRequestId)
        {
            var messages = _messageRepository.GetMessages(serviceRequestId).Select(m=>new {
                MessageId =m.MessageId,
                MessageBody=m.MessageBody,
                FromUserId = m.FromUserId,
                CreatedDate=m.CreatedDate
            }).ToList();
            
            return Json(messages,JsonRequestBehavior.AllowGet);
        }
        [Authorize]
        public ActionResult GetRequests()
        {
            var requests = _serviceRepository.GetRequestsForUser(CurrentUser.UserId);
            return Json(requests, JsonRequestBehavior.AllowGet);
        }

    }
}
