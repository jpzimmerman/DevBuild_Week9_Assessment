using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using DevBuild.Assessment6_WebForm.Models;

namespace DevBuild.Assessment6_WebForm.Controllers
{
    public class GOTCharactersController : Controller
    {
        private string _GoTCharacters_Root = "https://www.anapioficeandfire.com/api/characters";

        // GET: GOTCharacters
        public ActionResult Index()
        {
            return View();
        }
    }
}