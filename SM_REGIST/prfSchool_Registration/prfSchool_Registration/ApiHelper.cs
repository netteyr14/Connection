using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace prfSchool_Registration
{
    public class ApiHelper
    {
        private readonly string _baseUrl;

        public ApiHelper(string baseUrl)
        {
            _baseUrl = baseUrl; // e.g., "http://192.168.1.7:8080/"
        }

        // GET all users
        public List<User> GetUsers()
        {
            var request = (HttpWebRequest)WebRequest.Create(_baseUrl + "users");
            request.Method = "GET";
            request.ContentType = "application/json";

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                string json = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<User>>(json);
            }
        }

        // POST a user (add or update)
        public bool SaveUser(User user)
        {
            var request = (HttpWebRequest)WebRequest.Create(_baseUrl + "users");
            request.Method = "POST";
            request.ContentType = "application/json";

            string jsonData = JsonConvert.SerializeObject(user);

            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(jsonData);
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                return response.StatusCode == HttpStatusCode.OK;
            }
        }

        public class User
        {
            public int Id { get; set; }
            public string SID { get; set; }
            public string Fname { get; set; }
            public string Lname { get; set; }
            public string UserType { get; set; }
            public string RFID { get; set; }
        }
    }
}
