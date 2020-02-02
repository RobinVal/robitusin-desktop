using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net;
using Wpf_Robitusin.Models;
using System.IO;

namespace Wpf_Robitusin
{
    public class APIhelper
    {
        public string EmptyResult = "";
        public string Get(string path)
        {
            string url = String.Format(path);
            WebRequest requestObject = WebRequest.Create(url);
            requestObject.Method = "GET";
            HttpWebResponse responseObjGet = null;
            responseObjGet = (HttpWebResponse)requestObject.GetResponse();

            string ResultTest = null;
            using (Stream stream = responseObjGet.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                ResultTest = sr.ReadToEnd();
                sr.Close();
            }

            return ResultTest;
        }

        public void Post(string PostData)
        {
            string url = String.Format("http://localhost:49497/Api/User/Register");
            WebRequest requestObject = WebRequest.Create(url);
            requestObject.Method = "POST";
            requestObject.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(requestObject.GetRequestStream()))
            {
                
                    streamWriter.Write(PostData);
                    streamWriter.Flush();
                    streamWriter.Close();
                    
                    try
                    {
                    var httpResponse = (HttpWebResponse)requestObject.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result2 = streamReader.ReadToEnd();
                    }
                }   
                    catch
                    {
                        
                    }
                    

                    
            }
        }
        public string GetPar(string name)
        {
            try
            {
                string ResultTest = null;
                string url = String.Format("http://localhost:49497/Api/User?username=" + name + "");
                WebRequest requestObject = WebRequest.Create(url);
                requestObject.Method = "GET";
                HttpWebResponse responseObjGet = null;
                responseObjGet = (HttpWebResponse)requestObject.GetResponse();

                using (Stream stream = responseObjGet.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    ResultTest = sr.ReadToEnd();
                    sr.Close();
                    {
                        return ResultTest;
                    }
                }
            }
            catch
            {
                return EmptyResult;
            }
           
        }
    }
}
