using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Wpf_Robitusin.Models;

namespace Wpf_Robitusin.Validation
{
    public class LogValidation
    {
        User u = new User();
        APIhelper ah = new APIhelper();
        public bool UserExists(string Username, string Password)
        {
            User u = JsonConvert.DeserializeObject<User>(ah.GetPar(Username));

            if (Same(Username,u.Username) && Same(Password,u.Password))
            {
                LoggedUser.Username = u.Username;
                LoggedUser.Id = u.Id;
                return true;
            }
            else
                return false;
        }
        private bool Same(string text1, string text2)
        {
            return text1 == text2;
        }
    }
}
