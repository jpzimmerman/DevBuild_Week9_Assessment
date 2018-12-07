﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevBuild.Assessment6_WebForm.Models
{
    public class DishInfo
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string DishName { get; set; }
        public string DishDescription { get; set; }
        public List<string> DishOptions { get; set; } = new List<string>() { "Gluten-free" };
        
    }
}