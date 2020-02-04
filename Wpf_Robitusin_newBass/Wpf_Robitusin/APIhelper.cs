using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net;
using System.Net.WebSockets;
using Wpf_Robitusin.Models;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Wpf_Robitusin
{
    public class APIhelper
    {
        public string EmptyResult = "";
        public string Get()
        {
            string url = String.Format("http://localhost:49497/Api/User");
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
        public void Put(string PutData, int id)
        {
            string url = String.Format("http://localhost:49497/Api/Friendship?id=" + id + "");
            WebRequest requestObject = WebRequest.Create(url);
            requestObject.Method = "PUT";
            requestObject.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(requestObject.GetRequestStream()))
            {

                streamWriter.Write(PutData);
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
        public string GetPar(int id)
        {
            try
            {
                string ResultTest = null;
                string url = String.Format("http://localhost:49497/Api/User?Id=" + id + "");
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
        public void PostFriendship(string PostData)
        {
            string url = String.Format("http://localhost:49497/Api/Friendship");
            WebRequest requestObject = WebRequest.Create(url);
            requestObject.Method = "POST";
            requestObject.ContentType = "application/json";

            using (var streamWriter = new StreamWriter(requestObject.GetRequestStream()))
            {

                streamWriter.Write(PostData);
                streamWriter.Flush();
                streamWriter.Close();


                var httpResponse = (HttpWebResponse)requestObject.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result2 = streamReader.ReadToEnd();
                }

            }
        }
        public string GetFriendships()
        {
            string url = String.Format("http://localhost:49497/Api/Friendship/");
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
        public List<User> GetAllUsers()
        {
            return JsonConvert.DeserializeObject<List<User>>(Get());
        }
        public User GetUserFromJson(string path)
        {
            return JsonConvert.DeserializeObject<User>(path);
        }
        public List<Friendship> GetAllFriendships(string path)
        {
            return JsonConvert.DeserializeObject<List<Friendship>>(path);
        }       
        public List<string> LoggedUsersFriends()
        {
            List<Friendship> myFriendlist = GetAllFriendships(GetFriendships());
            List<string> myFriendNameList = new List<string>();
            
            foreach(Friendship fr in myFriendlist)
            {
                User u = new User();
                if(fr.RecieverId == LoggedUser.Id && fr.Status == true)
                {
                     u = GetUserFromJson(GetPar(fr.SenderId));
                    myFriendNameList.Add(u.Username);
                }else 
                if(fr.SenderId == LoggedUser.Id && fr.Status == true)
                {
                     u = GetUserFromJson(GetPar(fr.RecieverId));
                    myFriendNameList.Add(u.Username);
                }
            }

            return myFriendNameList;
        }
        public List<string> LoggedUsersPendings()
        {
            List<Friendship> myFriendlist = GetAllFriendships(GetFriendships());
            List<string> myPandingFriendNameList = new List<string>();

            foreach (Friendship fr in myFriendlist)
            {
                User u = new User();
                if (fr.RecieverId == LoggedUser.Id && fr.Status == false)
                {
                    u = GetUserFromJson(GetPar(fr.SenderId));
                    myPandingFriendNameList.Add(u.Username);
                }
                else
                if (fr.SenderId == LoggedUser.Id && fr.Status == false)
                {
                    u = GetUserFromJson(GetPar(fr.RecieverId));
                    myPandingFriendNameList.Add(u.Username);
                }
            }

            return myPandingFriendNameList;
        }

        public void FriendshipConfirmed(string SenderName)
        {
            /*
            List<Friendship> friendships = GetAllFriendships(GetFriendships());
            User sender = new User();
            sender = GetUserFromJson(GetPar(SenderName));
            foreach (Friendship item in friendships)
            {
                if(item.RecieverId == LoggedUser.Id && item.SenderId == sender.Id)
                {
                    item.Status = true;
                    Put("{\"SenderId\":\"" + item.RecieverId + "\",\"RecieverId\":\"" + LoggedUser.Id + "\",\"Status\":\"" + item.Status + "\",}", item.Id);
                }

            }*/
            List<Friendship> friendships = GetAllFriendships(GetFriendships());
            User sender = new User();
            sender = GetUserFromJson(GetPar(SenderName));
            foreach (Friendship item in friendships)
            {
                if (item.RecieverId == LoggedUser.Id && item.SenderId == sender.Id)
                {
                    
                    int RecieverId = LoggedUser.Id;
                    int SenderId = sender.Id;
                    bool Status = true;
                    PutFriendship("{\"SenderId\":\"" + SenderId + "\",\"RecieverId\":\"" + RecieverId + "\",\"Status\":\"" + Status + "\",}",item.Id);
                }

            }

        }
        public void PutFriendship(string path,int Id)
        {
            string url = String.Format("http://localhost:49497/Api/Friendship?Id="+ Id+"");
            WebRequest requestObject = WebRequest.Create(url);
            requestObject.Method = "PUT";
            requestObject.ContentType = "text/json";
            using(var streamWriter = new StreamWriter(requestObject.GetRequestStream()))
            {
                streamWriter.Write(path);
            }
            var httpResponse = (HttpWebResponse)requestObject.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var responseText = streamReader.ReadToEnd();
            }


        }
        
    }
}
