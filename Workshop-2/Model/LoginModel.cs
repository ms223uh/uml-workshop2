using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop_2.Model
{
    class LoginModel
    {


        public bool checkLoginCredentials(string username, string password)
       {
           string correctUsername = "Admin";
           string correctPassword = "Password";

           if(username == correctUsername)
           {
               if(password == correctPassword)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }
           else
           {
               return false;
           }
       }
    }
}
