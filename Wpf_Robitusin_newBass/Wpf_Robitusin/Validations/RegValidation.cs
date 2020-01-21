using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Robitusin.Validations
{
    public class RegValidation
    {
        public bool PassSimlr(string pass1, string pass2)
        {
            if (pass1 != pass2) return false;
                            else
                                return true;
        }
    }
}
