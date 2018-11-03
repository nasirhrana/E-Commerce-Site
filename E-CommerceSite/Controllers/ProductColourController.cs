using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_CommerceSite.Manager;
using E_CommerceSite.Models;

namespace E_CommerceSite.Controllers
{
    public class ProductColourController : Controller
    {
        //
        // GET: /ProductColour/
        private ProductColourManager aProductColourManager=new ProductColourManager();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SaveColour()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveColour(ProductColour productColour)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Msg = aProductColourManager.SaveColour(productColour);
            }
            return View();
        }

        public JsonResult IsColourExists(ProductColour productColour)
        {
            bool isExist = aProductColourManager.IsColourExists(productColour.ProductColourName);

            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }
	}
}