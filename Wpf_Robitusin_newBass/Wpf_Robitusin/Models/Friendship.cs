using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Robitusin.Models
{
    public class Friendship
    {
        public int Id { get; set; }
        public bool Status { get; set; }
        public int SenderId { get; set; }
        public int RecieverId { get; set; }
    }
}
