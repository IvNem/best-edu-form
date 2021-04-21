using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace best_edu_form
{
    class File
    {
        private const string APP_PATH = "https://best-edu.tk/api/v1";
        public string uuid { get; set; }
        public DateTime createdAt { get; set; }
        public string name { get; set; }
        public int size { get; set; }
        public string url { get; set; }

        // получаем информацию о дисциплине 
        public static string GetFileInfo(string token, string id_dis, string id_exe)
        {
            using (var client = Token.CreateClient(token))
            {
                var response = client.GetAsync(APP_PATH + "/disciplines/" + id_dis + "/exercises/" + id_exe + "/exercise-files/").Result;
                Console.WriteLine(APP_PATH + "/disciplines/" + id_dis + "/exercises/" + id_exe + "/exercise-files/");
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                return response.Content.ReadAsStringAsync().Result;
            }
        }
        public static string GetContentInfo(string token, string id_dis, string id_exe)
        {
            using (var client = Token.CreateClient(token))
            {
                var response = client.GetAsync(APP_PATH + "/disciplines/" + id_dis + "/exercises/" + id_exe + "/").Result;
                Console.WriteLine(APP_PATH + "/disciplines/" + id_dis + "/exercises/" + id_exe + "/");
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                return response.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
