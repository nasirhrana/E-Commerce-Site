using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_CommerceSite.Gateway;
using E_CommerceSite.Models;

namespace E_CommerceSite.Manager
{
    public class ProductSizeManager
    {
        private ProductSizeGateway aProductSizeGateway=new ProductSizeGateway();
        public List<Category> GetAllCategory()
        {
            return aProductSizeGateway.GetAllCategory();
        }
        public List<SubCategory> GetSubCategoryByCategoryId(int id)
        {
            return aProductSizeGateway.GetSubCategoryByCategoryId(id);
        }
        //public List<Item> GetItemBySubCategoryId(int subCatagoryId)
        //{
        //    return aProductSizeGateway.GetItemBySubCategoryId(subCatagoryId);
        //}

        public string CreateProductSize(ProductSize productSize)
        {
            if (aProductSizeGateway.CreateProductSize(productSize) > 0)
            {
                return "Product Size has been saved successfully";
            }
            else
            {
                return "Failed to save Product Size";
            }
        }
        public bool IsProductSizeExists(string productSize)
        {
            return aProductSizeGateway.IsProductSizeExists(productSize);
        }
    }
}