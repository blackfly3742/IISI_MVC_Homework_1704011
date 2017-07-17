using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using EmailValidate.ValidateAttribute;
using EmailValidation.ValidateAttribute;

namespace EmailValidation.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [NoIs("skilltree,demo,twMVC", ErrorMessage = "請使用別的名稱")]
        //[DataType(DataType.EmailAddress)]
        [Display(Name = "Account")]
        [Email]
        //[RegularExpression(@"\w.+\@\w.+")]
        //http://demo.tc/Post/688
        //Session3講義
        public string Account { get; set; }
        [StringLength(20, MinimumLength = 4)]
        public string Password { get; set; }
        public string Message { get; set; }

    }
}