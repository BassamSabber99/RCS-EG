using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RCS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.ApplicationInsights.Extensibility.Implementation.Tracing;
using RCS.Models.CustomeDataAnnotation;

namespace RCS.viewModels
{
    public class productViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public int id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Product Name")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Department")]
        public byte DepartmentID { get; set; }
        [Required]
        [Display(Name = "Category")]
        public byte CategoryID { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string description { get; set; }
        [Required]
        [DisplayName("Upload Images")]
        public string ImagePath { get; set; }
        [AllowFile]
        public HttpPostedFileBase[] ImageFile { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Product Address")]
        public string address { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Product Price")]
        [priceValidation]
        public Decimal price { get; set; }
       
        [Display(Name = "Owner Name")]
        public string ownerName { get; set; }
   
        [Display(Name = "Owner Phone")]
        public string ownerPhone { get; set; }
        
        [Display(Name = "Owner Email")]
        public string ownerEmail { get; set; }
    }
}