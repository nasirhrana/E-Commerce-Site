using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_CommerceSite.Manager;
using E_CommerceSite.Models;

namespace E_CommerceSite.Controllers
{
    public class ProductQuantityController : Controller
    {
        //
        // GET: /ProductQuantity/
        private QuantityManager aQuantityManager=new QuantityManager();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SaveQuantity()
        {
            ViewBag.CategoryId = aQuantityManager.GetAllCategory();
            return View();
        }
        [HttpPost]
        public ActionResult SaveQuantity(ProductQuantity productQuantity)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    if (ModelState.IsValid)
                    {
                        ViewBag.Msg = aQuantityManager.SaveQuantity(productQuantity);
                    }
                }
            }
            ViewBag.CategoryId = aQuantityManager.GetAllCategory();
            return View();
        }
        public JsonResult GetSubCategoryByCategoryId(int catagoryId)
        {
            List<SubCategory> alList = aQuantityManager.GetSubCategoryByCategoryId(catagoryId);
            return Json(alList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetItemBySubCategoryId(int subCatagoryId)
        {
            List<Item> alList = aQuantityManager.GetItemBySubCategoryId(subCatagoryId);
            return Json(alList, JsonRequestBehavior.AllowGet);
        }
	}
}