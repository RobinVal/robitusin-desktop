using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Wpf_Robitusin.Validation
{
    public class RegValidation
    {
        APIhelper Ah = new APIhelper();
        public bool PassSame(string passO, string passR)
        {
            return passO == passR;
        }
        public bool UserExists(string Username)
        {
            string input = "";
            input = Ah.GetPar(Username);
            if(input == "")
            {
                return false;
            }
            else
            {
                string pattern = @"" + Username + "";
                Match m = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
                if (m.Success == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }
    }
}
