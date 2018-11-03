using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_CommerceSite.Gateway;
using E_CommerceSite.Models;

namespace E_CommerceSite.Manager
{
    public class ProductManager
    {
        private ProductGateway aProductGateway=new ProductGateway();
        public List<Category> GetAllCategory()
        {
            return aProductGateway.GetAllCategory();
        }
        public List<SubCategory> GetSubCategoryByCategoryId(int id)
        {
            return aProductGateway.GetSubCategoryByCategoryId(id);
        }
        public List<Item> GetItemBySubCategoryId(int subCatagoryId)
        {
            return aProductGateway.GetItemBySubCategoryId(subCatagoryId);
        }
        public List<ProductSize> GetProductSizeBySubCategoryId(int subCatagoryId)
        {
            return aProductGateway.GetProductSizeBySubCategoryId(subCatagoryId);
        }
        public string PublishProduct(Product product)
        {
            if (aProductGateway.PublishProduct(product) > 0)
            {
                return "Product   has been Publish successfully";
            }
            else
            {
                return "Failed to Publish Product";
            }
        }
    }
}