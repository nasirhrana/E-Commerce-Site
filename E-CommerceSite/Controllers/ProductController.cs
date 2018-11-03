using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using E_CommerceSite.Manager;
using E_CommerceSite.Models;

namespace E_CommerceSite.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        private ProductManager aProductManager=new ProductManager();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult PublishProduct()
        {
            
            ViewBag.CategoryId = aProductManager.GetAllCategory();
            ViewBag.ColourId = aProductManager.GetAllColour();
            return View();
        }
        [HttpPost]
        public ActionResult PublishProduct(Product product, HttpPostedFileBase UploadFile)
        {
            product.DateOfPublish = DateTime.Today;
            product.Status = "Publish";

            if (UploadFile != null)
            {
                if (UploadFile.ContentType == "image/jpeg" || UploadFile.ContentType == "image/png" || UploadFile.ContentType == "image/gif")
                {
                    var productId = product.ProductId;
                    string imageUrl = "";
                    var imageType = UploadFile.ContentType;
                    if (imageType == "image/jpeg")
                    {
                        imageUrl = productId + ".Jpg";
                    }
                    if (imageType == "image/png")
                    {
                        imageUrl = productId + ".png";
                    }
                    if (imageType == "image/gif")
                    {
                        imageUrl = productId + ".gif";
                    }

                    UploadFile.SaveAs(Server.MapPath("/") + "/UploadFile/" + imageUrl);
                    product.UploadFile = imageUrl;
                }
                else
                {
                    return View();
                }


                try
                {
                    if (ModelState.IsValid)
                    {
                        ViewBag.Msg = aProductManager.PublishProduct(product);
                    }


                }
                catch (Exception exception)
                {
                    ViewBag.Msg = exception.Message;
                }
            }

            ViewBag.CategoryId = aProductManager.GetAllCategory();
            ViewBag.ColourId = aProductManager.GetAllColour();

            return View();
        }
        public JsonResult GetSubCategoryByCategoryId(int catagoryId)
        {
            List<SubCategory> alList = aProductManager.GetSubCategoryByCategoryId(catagoryId);
            return Json(alList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetItemBySubCategoryId(int subCatagoryId)
        {
            List<Item> alList = aProductManager.GetItemBySubCategoryId(subCatagoryId);
            return Json(alList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetProductSizeBySubCategoryId(int subCatagoryId)
        {
            List<ProductSize> alList = aProductManager.GetProductSizeBySubCategoryId(subCatagoryId);
            return Json(alList, JsonRequestBehavior.AllowGet);
        }

	}
}