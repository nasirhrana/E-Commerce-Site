using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_CommerceSite.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        [DisplayName("Company Name")]
        [Remote("IsCompanyNameExists", "Admin", ErrorMessage = " Company Name Already exist!!!")]
        public string CategoryName { get; set; }
    }
}