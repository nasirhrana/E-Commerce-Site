using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_CommerceSite.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string UploadFile { get; set; }
        [Required]
        public int ProductSizeId { get; set; }
        [Required]
        [Range(1, Double.MaxValue, ErrorMessage = "Value must be non-negative and greater than 0")]
        public double Prize { get; set; }
        [Required]
        [Range(0, Double.MaxValue, ErrorMessage = "Value must be non-negative")]
        public double Discount { get; set; }
        [Required]
        public string Colour { get; set; }
        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfPublish { get; set; }

        public string Status { get; set; }
    }
}