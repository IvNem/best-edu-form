using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace best_edu_form
{

    class Person
    {
        private const string APP_PATH = "https://best-edu.tk/api/v1";
        public Token token { get; set; }
        public Account account { get; set; }


        // получаем информацию о клиенте 
        public static string GetUserInfo(string token, string secondName)
        {
            using (var client = Token.CreateClient(token))
            {
                var response = client.GetAsync(APP_PATH + "/disciplines/?teacherFullName=" + secondName).Result;
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                return response.Content.ReadAsStringAsync().Result;

            }
        }
    }
}
