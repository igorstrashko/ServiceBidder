using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMI.Turf.Orchestrators;
using IMI.Turf.Repository;
using IMI.Turf.DataModels;

namespace IMI.Turf.Web.Controllers
{
    public class BaseController : Controller
    {
        private IUserRepository _userRepository = null;
        //
        // GET: /Base/
        public BaseController()
        {
            this._userRepository = new UserRepository();
        }
        protected UserProfile CurrentUser
        {
            get
            {
                if (User.Identity.IsAuthenticated)
                    return _userRepository.GetByEmail(User.Identity.Name);
                else
                    return null;
            }
        }

    }
}
