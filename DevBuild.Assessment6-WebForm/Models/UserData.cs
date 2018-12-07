using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DevBuild.Assessment6_WebForm.Models
{
    public class UserData
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        //[EmailAddress, Required(AllowEmptyStrings = false, ErrorMessage = "Please enter an email address: ")]
        [Required, EmailAddress, MaxLength(50)]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Please let us know whether or not you will be attending")]
        public bool IsAttending { get; set; } = false;
        public bool HasAPlusOne { get; set; } = false;

        public uint DrunkenIdiotEval { get; set; }
        public uint SelectedPartyDate { get; set; } = 0;
        public string[] PartyDates { get; set; } = { "12/14/2018", "12/15/2018" };
    }
}