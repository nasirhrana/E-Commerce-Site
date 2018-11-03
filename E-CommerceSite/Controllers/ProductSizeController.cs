using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_CommerceSite.Manager;
using E_CommerceSite.Models;

namespace E_CommerceSite.Controllers
{
    public class ProductSizeController : Controller
    {
        //
        // GET: /ProductSize/
        private ProductSizeManager aProductSizeManager=new ProductSizeManager();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateProductSize()
        {
            ViewBag.CategoryId = aProductSizeManager.GetAllCategory();
            return View();
        }
        [HttpPost]
        public ActionResult CreateProductSize(ProductSize productSize)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    ViewBag.Msg = aProductSizeManager.CreateProductSize(productSize);
                }
            }
            ViewBag.CategoryId = aProductSizeManager.GetAllCategory();
            return View();
        }
        public JsonResult GetSubCategoryByCategoryId(int catagoryId)
        {
            List<SubCategory> alList = aProductSizeManager.GetSubCategoryByCategoryId(catagoryId);
            return Json(alList, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult GetItemBySubCategoryId(int subCatagoryId)
        //{
        //    List<Item> alList = aProductSizeManager.GetItemBySubCategoryId(subCatagoryId);
        //    return Json(alList, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult IsProductSizeExists(string size)
        {
            bool isExist = aProductSizeManager.IsProductSizeExists(size);

            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }



	}
}