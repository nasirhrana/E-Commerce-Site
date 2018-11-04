using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_CommerceSite.Manager;
using E_CommerceSite.Models;

namespace E_CommerceSite.Controllers
{
    public class RegistrationController : Controller
    {
        //
        // GET: /Registration/
        private RegistrationManager aRegistrationManager=new RegistrationManager();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Registration registration)
        {
            registration.UserTypeId = 1;
            registration.TimeOfRegistration = DateTime.Today;
            if (ModelState.IsValid )
            {
                ViewBag.Msg = aRegistrationManager.Registration(registration);
            }
            return View();
        }

        public JsonResult IsEmailExists(Registration registration)
        {
            registration.UserTypeId = 1;
            bool isExist = aRegistrationManager.IsEmailExists(registration);

            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }
	}
}