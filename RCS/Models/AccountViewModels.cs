using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RCS.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessageResourceName = "errorEmail", ErrorMessageResourceType = typeof(Resources.Resource))]
        [Display(Name = "EmailText", ResourceType = typeof(Resources.Resource))]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "errorPass", ErrorMessageResourceType = typeof(Resources.Resource))]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resource))]
        public string Password { get; set; }

        [Display(Name = "Rememberme" , ResourceType = typeof(Resources.Resource))]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceName = "errorUserName", ErrorMessageResourceType = typeof(Resources.Resource))]
        [DataType(DataType.Text)]
        [Display(Name = "UserName" , ResourceType = typeof(Resources.Resource))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceName = "errorPhon", ErrorMessageResourceType = typeof(Resources.Resource))]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone", ResourceType = typeof(Resources.Resource))]
        public string Phone { get; set; }

        [Required(ErrorMessageResourceName = "errorAddress", ErrorMessageResourceType = typeof(Resources.Resource))]
        [DataType(DataType.Text)]
        [Display(Name = "addressText", ResourceType = typeof(Resources.Resource))]
        public string address { get; set; }

        [Required(ErrorMessageResourceName = "errorEmail", ErrorMessageResourceType = typeof(Resources.Resource))]
        [EmailAddress]
        [Display(Name = "EmailText", ResourceType = typeof(Resources.Resource))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "errorGender", ErrorMessageResourceType = typeof(Resources.Resource))]
        [DataType(DataType.Text)]
        [Display(Name = "Gender", ResourceType = typeof(Resources.Resource))]
        public string Gender { get; set; }

        [Required(ErrorMessageResourceName = "errorPass", ErrorMessageResourceType = typeof(Resources.Resource))]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.Resource))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmpassword", ResourceType = typeof(Resources.Resource))]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [Required(ErrorMessageResourceName = "errorConPass", ErrorMessageResourceType = typeof(Resources.Resource))]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
