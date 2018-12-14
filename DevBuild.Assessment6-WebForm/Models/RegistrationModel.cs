using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace DevBuild.Assessment6_WebForm.Models
{
    public class RegistrationModel : IdentityUser
    {
        [Display(Name = "Please choose a username: ")]
        public override string UserName { get; set; }

        [Display(Name = "Please choose a password: ")]
        public string Password { get; set; }

        [Display(Name = "First name: ")]
        public string FirstName { get; set; }

        [Display(Name = "Last name: ")]
        public string LastName { get; set; }
    }
}