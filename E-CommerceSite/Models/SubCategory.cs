using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_CommerceSite.Models
{
    public class SubCategory
    {
        public int SubCategoryId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [DisplayName("Company Name")]
        [Remote("IsSubCategoryNameExists", "Admin", ErrorMessage = " Category Name Already exist!!!")]
        public string SubCategoryName { get; set; }
    }
}