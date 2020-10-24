using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RCS.viewModels;

namespace RCS.Models.CustomeDataAnnotation
{
    public class AllowFileAttribute: ValidationAttribute
    {
        public string Extensions { get; set; } = "png,jpg,jpeg";
      
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = (productViewModel)validationContext.ObjectInstance;
            List<string> allowedExtensions = this.Extensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (file.ImageFile[0] != null)
            {
                for (int i = 0; i < file.ImageFile.Length; i++)
                {
                   
                        if (!allowedExtensions.Any(y => file.ImageFile[i].FileName.EndsWith(y)))
                        {
                            return new ValidationResult("There is one of Images Extensionss Not Supporting. We Support (png,jpg,jpeg) !!");
                        }
                        if(file.ImageFile[i].ContentLength > 3145728)
                        {
                            return new ValidationResult("Size one Of Images Greater Than (3) MB. Please Upload Images Less Than (3) MB !!");
                        }
                    

                }
                
            }
            return ValidationResult.Success;
            
        }
    }
}