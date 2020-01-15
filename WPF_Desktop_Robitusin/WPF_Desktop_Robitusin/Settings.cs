using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Wpf_Desktop_Robitusin
{
    public class Settings
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strurltest = string.Format("http://localhost:49497/Help/Api/GET-api-User");
            WebRequest requestObjGet = WebRequest.Create(strurltest);
            requestObjGet.Method = "GET";
            HttpWebResponse responseObjGet = null;
            responseObjGet = (HttpWebResponse)requestObjGet.GetResponse();

            string strresulttest = null;
            using (Stream stream = responseObjGet.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                strresulttest = sr.ReadToEnd();
                sr.Close();
            }

            ///POST
            ///

            string strUrl = string.Format("http://localhost:49497/Help/Api/POST-api-User");
            WebRequest requestObjPost = WebRequest.Create(strUrl);
            requestObjPost.Method = "POST";
            requestObjPost.ContentType = "application/json";

            string postData = "{\"Username\":\"sample string 1\",\"Password\":\"sample string 2\"}";

            using(var StreamWriter = new StreamWriter(requestObjPost.GetRequestStream()))
            {
                StreamWriter.Write(postData);
                StreamWriter.Flush();
                StreamWriter.Close();

                var httpResponse = (HttpWebResponse)requestObjPost.GetResponse();

                using (var StreamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result2 = StreamReader.ReadToEnd();
                }
            }
        }
        
    }
}
