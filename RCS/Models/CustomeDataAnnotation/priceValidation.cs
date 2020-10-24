using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RCS.viewModels;

namespace RCS.Models.CustomeDataAnnotation
{
    public class priceValidation: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var product = (productViewModel)validationContext.ObjectInstance;
            if(product.price <= 0)
            {
                return new ValidationResult("Please Enter Valid Price !");
            }
            return ValidationResult.Success;
        }
    }
}