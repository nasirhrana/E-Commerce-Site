using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_CommerceSite.Models
{
    public class ProductQuantity
    {
        public int ProductQuantityId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        [Range(1, Double.MaxValue, ErrorMessage = "Value must be non-negative and greater than 0")]
        public double Quantity { get; set; }
    }
}