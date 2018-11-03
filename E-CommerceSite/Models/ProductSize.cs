using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_CommerceSite.Models
{
    public class ProductSize
    {
        public int ProductSizeId { get; set; }
        [Required]
        public int SubCategoryId { get; set; }
        [Required]
        [Remote("IsProductSizeExists", "ProductSize", ErrorMessage = "Product Size Already Exist!!!")]
        public string ProductSizeName { get; set; }
    }
}