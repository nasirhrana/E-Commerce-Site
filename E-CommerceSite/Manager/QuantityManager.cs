using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_CommerceSite.Gateway;
using E_CommerceSite.Models;

namespace E_CommerceSite.Manager
{
    public class QuantityManager
    {
        private QuantityGateway aQuantityGateway=new QuantityGateway();
        public List<Category> GetAllCategory()
        {
            return aQuantityGateway.GetAllCategory();
        }
        public List<SubCategory> GetSubCategoryByCategoryId(int id)
        {
            return aQuantityGateway.GetSubCategoryByCategoryId(id);
        }
        public List<Item> GetItemBySubCategoryId(int subCatagoryId)
        {
            return aQuantityGateway.GetItemBySubCategoryId(subCatagoryId);
        }
        public string SaveQuantity(ProductQuantity productQuantity)
        {
            if (aQuantityGateway.SaveQuantity(productQuantity) > 0)
            {
                return "Product  Quantity has been saved successfully";
            }
            else
            {
                return "Failed to save Product Quantity";
            }
        }
    }
}