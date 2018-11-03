using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_CommerceSite.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        [Required]
        public int SubCategoryId { get; set; }
        [Required]
        [DisplayName("Item Name")]
        [Remote("IsItemNameExists", "Admin", ErrorMessage = " Item Name Already exist!!!")]
        public string ItemName { get; set; }
    }
}