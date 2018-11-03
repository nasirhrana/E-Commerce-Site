using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_CommerceSite.Models
{
    public class ProductColour
    {
        public int ProductColourId { get; set; }
        [Required]
        [DisplayName("Product Colour")]
        [Remote("IsColourExists", "ProductColour", ErrorMessage = " Colour  Already exist!!!")]
        public string ProductColourName { get; set; }
    }
}