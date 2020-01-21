using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace Wpf_Robitusin
{
    public class ApiSettings
    {
        public class User
        {
            public int Id { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
        public class personController : ApiController
        {
            [HttpPost]
             public void Post([FromBody] User u)
            {

            }
        }
    }
}
