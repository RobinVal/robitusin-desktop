using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wpf_Robitusin.Validation
{
    public class LogValidation
    {
        
        APIhelper ah = new APIhelper();
        public bool UserExists(string Username, string Password)
        {
            string UsernamePattern = @"" + "\"" + Username + "\"";
            string PasswordPattern = @"" + "\"" + Password + "\"";
            string input = ah.GetPar(Username);
            Match mU = Regex.Match(input, UsernamePattern, RegexOptions.IgnoreCase);
            Match mP = Regex.Match(input, PasswordPattern, RegexOptions.IgnoreCase);
            if (mU.Success && mP.Success)
                return true;
            else
                return false;
        }
    }
}
