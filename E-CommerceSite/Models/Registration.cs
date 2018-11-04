using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_CommerceSite.Models
{
    public class Registration
    {
        public int UserId { get; set; }
        [Required]
        public int UserTypeId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        [Remote("IsEmailExists", "Registration", ErrorMessage = " Please choose another email")]
        public string UserEmail { get; set; }
        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public string UserContactNo { get; set; }
        [Required]
        public string UserAddress { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime TimeOfRegistration { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be 8 to 20 character")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}