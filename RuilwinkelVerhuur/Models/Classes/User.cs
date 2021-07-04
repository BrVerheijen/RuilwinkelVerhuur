using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Models.Classes
{
    //class to store user
    public class User
    {
        public User(int id, string name, string email)
        {
            ID = id;
            Name = name;
            Email = email;            
        }

        public int ID;

        public string Name;

        public string Email;
        
    }
}
