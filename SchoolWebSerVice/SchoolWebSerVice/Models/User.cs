using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebSerVice.Models
{
    public class User
    {
        string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}