using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RuilwinkelVerhuur.Models.Classes
{
    public class User
    {
        public User(int id, string name, string email, int walletID)
        {
            ID = id;
            Name = name;
            Email = email;
            WalletID = walletID;
        }

        public int ID;

        public string Name;

        public string Email;

        public int WalletID;
    }
}
