using RuilwinkelVerhuur.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Models.Classes
{
    public class AccountComm
    {
        //retrieves user information form accountbeheer
        public static User retrieveUser() 
        {            
            //TODO vraag account id op van de gebruiker van de huidige sessie
            User currentUser = new User(1, "Billy", "nathangroenveld3@gmail.com", 1);
            return currentUser;     
        }
    }
}