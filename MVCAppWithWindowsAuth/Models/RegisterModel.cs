using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVCAppWithWindowsAuth.Models
{
    public class RegisterModel
    {
        [Required (ErrorMessage ="Can't Leave Field Empty")]
        [RegularExpression ("[A-Za-z0-9]{6-20}",ErrorMessage ="User ID Value is invalid")]
        public string UserId { get; set; }
        [Required(ErrorMessage = "Can't Leave Field Empty")]
        [RegularExpression("[A-Za-z\\s]{3,50}",ErrorMessage ="Name value is invalid")]
        public string Name{ get; set; }
        [Required(ErrorMessage = "Can't Leave Field Empty")]
        [DataType(DataType.Password)]
        [RegularExpression("[A-Z]{1}[a-z0-9@#$%_-]{7,15}",ErrorMessage="Password is Invalid")]
        public string Password{ get; set; }
        [Display(Name="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword{ get; set; }
        [Required(ErrorMessage = "Can't Leave Field Empty")]
        [DataType(DataType.EmailAddress)]
        public string Email{ get; set; }
        [Required(ErrorMessage = "Can't Leave Field Empty")]
        [RegularExpression("[6-9]\\d{9}",ErrorMessage ="Phone is Invalid")]
        public string Mobile{ get; set; }
    }
}