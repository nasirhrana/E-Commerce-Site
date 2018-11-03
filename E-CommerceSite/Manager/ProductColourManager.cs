using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_CommerceSite.Gateway;
using E_CommerceSite.Models;

namespace E_CommerceSite.Manager
{
    public class ProductColourManager
    {
        private ProductColourGateway aProductColourGateway=new ProductColourGateway();
        public string SaveColour(ProductColour productColour)
        {
            if (aProductColourGateway.SaveColour(productColour) > 0)
            {
                return "Product  Colour has been saved successfully";
            }
            else
            {
                return "Failed to save Product Colour";
            }
        }
        public bool IsColourExists(string colourname)
        {
            return aProductColourGateway.IsColourExists(colourname);
        }
    }
}