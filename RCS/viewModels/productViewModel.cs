using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RCS.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.ApplicationInsights.Extensibility.Implementation.Tracing;
using RCS.Models.CustomeDataAnnotation;
using System.Security.AccessControl;

namespace RCS.viewModels
{
    public class productViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public int id { get; set; }
        [Required(ErrorMessageResourceName = "error",ErrorMessageResourceType = typeof(Resources.Resource))]
        [DataType(DataType.Text)]
        [Display(Name = "ProductName",ResourceType = typeof(Resources.Resource))]
        public string name { get; set; }
        [Required(ErrorMessageResourceName = "error", ErrorMessageResourceType = typeof(Resources.Resource))]
        [Display(Name = "DepartmentName", ResourceType = typeof(Resources.Resource))]
        public byte DepartmentID { get; set; }
        [Required(ErrorMessageResourceName = "error", ErrorMessageResourceType = typeof(Resources.Resource))]
        [Display(Name = "CategoryName",ResourceType = typeof(Resources.Resource))]
        public byte CategoryID { get; set; }
        [Required(ErrorMessageResourceName = "error", ErrorMessageResourceType = typeof(Resources.Resource))]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description",ResourceType = typeof(Resources.Resource))]
        public string description { get; set; }
        [Required(ErrorMessageResourceName = "error", ErrorMessageResourceType = typeof(Resources.Resource))]
        [Display(Name = "UploadImages", ResourceType = typeof(Resources.Resource))]
        public string ImagePath { get; set; }
        [AllowFile]
        public HttpPostedFileBase[] ImageFile { get; set; }
        [Required(ErrorMessageResourceName = "error", ErrorMessageResourceType = typeof(Resources.Resource))]
        [DataType(DataType.MultilineText)]
        [Display(Name = "ProductAddress",ResourceType = typeof(Resources.Resource))]
        public string address { get; set; }
        [Required(ErrorMessageResourceName = "error", ErrorMessageResourceType = typeof(Resources.Resource))]
        [DataType(DataType.Currency)]
        [Display(Name = "ProductPrice" ,ResourceType =  typeof(Resources.Resource))]
        [priceValidation]
        public Decimal price { get; set; }
       
        [Display(Name = "OwnerName" , ResourceType = typeof(Resources.Resource))]
        public string ownerName { get; set; }
   
        [Display(Name = "OwnerPhone" , ResourceType = typeof(Resources.Resource))]
        public string ownerPhone { get; set; }
        
        [Display(Name = "OwnerEmail" , ResourceType = typeof(Resources.Resource))]
        public string ownerEmail { get; set; }
    }
}