﻿using RuilwinkelVerhuur.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Models.Classes
{
    public class AccountComm
    {
        public string email { get; set; }

        static HttpClient client = new HttpClient();
        //retrieves user information form accountbeheer
        public static async Task<User> retrieveUser() 
        {
            AccountComm obj = new() { email = "1711784delnoy@zuyd.nl" };
            JsonSerializer.Serialize(obj);
            HttpResponseMessage response = await client.GetAsync("https://testeppie20210607124001.azurewebsites.net/AspNetUser/[email]");
            if (response.IsSuccessStatusCode)
            {
                
            }
                //TODO vraag account id op van de gebruiker van de huidige sessie
                User currentUser = new User(1, "Billy", "nathangroenveld3@gmail.com");
             
            return currentUser;     
        }

    }
}
