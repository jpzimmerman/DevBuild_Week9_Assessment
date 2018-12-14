using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace DevBuild.Assessment6_WebForm.Models
{
    public class LoginModel
    {
        [Key]
        [Required(AllowEmptyStrings =false, ErrorMessage = "Please enter a username ")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage = "Please enter a password ")]
        public string Password { get; set; }

    }
}