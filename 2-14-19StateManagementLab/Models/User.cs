using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2_14_19StateManagementLab.Models
{
    public class User
    {
        /*
        * User Name 
          Email
          Password 
          Age 
        */

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }

        public User(string userName, string email, string password, int age)
        {
            UserName = userName;
            Email = email;
            Password = password;
            Age = age;
        }

        public User()
        {
            
        }

    }
}