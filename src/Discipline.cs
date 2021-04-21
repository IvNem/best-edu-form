using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace best_edu_form
{
    class Discipline
    {
        private const string APP_PATH = "https://best-edu.tk/api/v1";
        public int id { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public DateTime createdAt { get; set; }
        public bool isPublic { get; set; }
        public bool isRemoved { get; set; }

        // получаем информацию о дисциплине 
        public static string GetDisciplineInfo(string token, string id)
        {
            using (var client = Token.CreateClient(token))
            {
                var response = client.GetAsync(APP_PATH + "/disciplines/" + id + "/exercises/").Result;
                Console.WriteLine(APP_PATH + "/disciplines/" + id + "/exercises/");
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                return response.Content.ReadAsStringAsync().Result;

            }
        }
    }
}
