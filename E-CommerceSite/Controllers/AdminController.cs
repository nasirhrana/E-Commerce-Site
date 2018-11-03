using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_CommerceSite.Manager;
using E_CommerceSite.Models;

namespace E_CommerceSite.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private AdminManager adminManager = new AdminManager();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Msg = adminManager.SaveCategory(category);
            }
            return View();
        }
        public JsonResult IsCompanyNameExists(string companyName)
        {
            bool isExist = adminManager.IsCompanyNameExists(companyName);

            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }

    }
}