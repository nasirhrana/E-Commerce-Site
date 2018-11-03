using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_CommerceSite.Gateway;
using E_CommerceSite.Models;

namespace E_CommerceSite.Manager
{
    public class AdminManager
    {
        private AdminGateway adminGateway=new AdminGateway();
        public string SaveCategory(Category category)
        {
            if (adminGateway.SaveCategory(category) > 0)
            {
                return "Category has been saved successfully";
            }
            else
            {
                return "Failed to save Category";
            }
        }

        public bool IsCategoryNameExists(string categoryname)
        {
            return adminGateway.IsCategoryNameExists(categoryname);
        }
        public string SaveSubCategory(SubCategory subCategory)
        {
            if (adminGateway.SaveSubCategory(subCategory) > 0)
            {
                return "Category has been saved successfully";
            }
            else
            {
                return "Failed to save Category";
            }
        }

        public bool IsSubCategoryNameExists(string subCategoryname)
        {
            return adminGateway.IsSubCategoryNameExists(subCategoryname);
        }

        public List<Category> GetAllCategory()
        {
            return adminGateway.GetAllCategory();
        }

        public List<SubCategory> GetSubCategoryByCategoryId(int id)
        {
            return adminGateway.GetSubCategoryByCategoryId(id);
        }

        public string SaveItem(Item item)
        {
            if (adminGateway.SaveItem(item) > 0)
            {
                return "Item has been saved successfully";
            }
            else
            {
                return "Failed to save Item";
            }
        }
        public bool IsItemNameExists(string itemName)
        {
            return adminGateway.IsItemNameExists(itemName);
        }
    }
}