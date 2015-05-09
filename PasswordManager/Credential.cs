using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordManager
{
    public class Credential
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public Credential()
        {
            
        }
    }
}
