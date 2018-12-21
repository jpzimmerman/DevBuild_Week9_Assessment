using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using DevBuild.Assessment6_WebForm.Models;
using System.Net;
using Newtonsoft.Json;

namespace DevBuild.Assessment6_WebForm.Data
{
    public static class GoTCharactersRepository
    {
        private static string _GoTCharacters_Root = "https://www.anapioficeandfire.com/api/characters?page=1&pageSize=1000";

        private static List<GoTCharacter> characters = new List<GoTCharacter>();
        public static List<SelectListItem> GoTCharacters_SelectList = new List<SelectListItem>();


        static GoTCharactersRepository()
        {
            HttpWebRequest request = WebRequest.CreateHttp(_GoTCharacters_Root);
            request.UserAgent = HttpContext.Current.Request.UserAgent;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            InitCharacterList();
        }

        private static void InitCharacterList()
        { 
            HttpWebRequest request = WebRequest.CreateHttp(_GoTCharacters_Root);
            request.UserAgent = HttpContext.Current.Request.UserAgent;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    characters = JsonConvert.DeserializeObject<List<GoTCharacter>>(reader.ReadToEnd());
                    foreach (GoTCharacter c in characters)
                    {
                        if (c.name != "")
                        {
                            GoTCharacters_SelectList.Add(new SelectListItem() { Text = c.name });
                        }
                    }
                }
            }
        }

        public static GoTCharacter GetCharacterByName(string name)
        {
            try
            {
                return characters.FirstOrDefault(x => x.name.Contains(name));
            }
            catch (ArgumentNullException e)
            {
                return null;
            }

        }

    }
}