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
        public JsonResult IsCategoryNameExists(string categoryName)
        {
            bool isExist = adminManager.IsCategoryNameExists(categoryName);

            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public ActionResult CreateSubCategory()
        {
            ViewBag.CategoryId = adminManager.GetAllCategory();
            return View();
        }

        [HttpPost]
        public ActionResult CreateSubCategory(SubCategory subCategory)
        {
            
            if (ModelState.IsValid)
            {
                ViewBag.Msg = adminManager.SaveSubCategory(subCategory);
            }
            ViewBag.CategoryId = adminManager.GetAllCategory();
            return View();
        }


        public JsonResult IsSubCategoryNameExists(string subCategoryName)
        {
            bool isExist = adminManager.IsSubCategoryNameExists(subCategoryName);

            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }



        [HttpGet]
        public ActionResult CreateItem()
        {
            ViewBag.CategoryId = adminManager.GetAllCategory();
            return View();
        }

        [HttpPost]
        public ActionResult CreateItem(Item item)
        {

            if (ModelState.IsValid)
            {
                ViewBag.Msg = adminManager.SaveItem(item);
            }
            ViewBag.CategoryId = adminManager.GetAllCategory();
            return View();
        }

        public JsonResult GetSubCategoryByCategoryId(int catagoryId)
        {
            List<SubCategory> alList = adminManager.GetSubCategoryByCategoryId(catagoryId);
            return Json(alList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsItemNameExists(string itemName)
        {
            bool isExist = adminManager.IsItemNameExists(itemName);

            return Json(!isExist, JsonRequestBehavior.AllowGet);
        }




    }
}