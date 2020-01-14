using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Desktop_Robitusin
{
    public class Validations
    {
        public bool IsEmpy(string Value)
        {
            if(Value == "")
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
