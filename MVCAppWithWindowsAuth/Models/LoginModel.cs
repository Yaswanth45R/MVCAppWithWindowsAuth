using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCAppWithWindowsAuth.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Cannot Leave this Field Empty")]
        [Display(Name ="User Id")]
        [RegularExpression("[A-Za-z0-9]{6-20}",ErrorMessage ="User Id Value is Invalid")]
        public string UserId { get; set; }
        [Required(ErrorMessage ="Cannot Leave This Feild Empty")]
        [DataType(DataType.Password)]
        [RegularExpression("[A-Z]{1}[a-z0-9@#$%_-]{7,16}",ErrorMessage ="Password is invalid")]
        public string Password { get; set; }    
    }
}