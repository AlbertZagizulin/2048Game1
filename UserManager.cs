using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeniusIdiotConsoleApp;
using Newtonsoft.Json;

namespace _2048WinFormsApp
{
    public class UserManager
    {
        public static string path = "2048results.json";
        public static List<User> GetAll()
        {
            if(!DataWorkspace.Exists(path))
            {
                return new List<User>();
            }
            var jsonData = DataWorkspace.GetValue(path);
            return JsonConvert.DeserializeObject<List<User>>(jsonData);
        }
        public static void Add(User newUser)
        {
            var users = GetAll();
            users.Add(newUser);
            var jsonData = JsonConvert.SerializeObject(users);
            DataWorkspace.Replace(path, jsonData);
        }
    }
}
