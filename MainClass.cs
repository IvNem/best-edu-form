using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace best_edu_form
{
    class MainClass
    {
        
        private const string APP_PATH = "https://best-edu.tk/api/v1";
        //public class Token
        //{
        //    public string access_token { get; set; }
        //    public string token_type { get; set; }
        //    public string refresh_token { get; set; }
        //    public int expires_in { get; set; }
        //    public string scope { get; set; }

        //    // создаем http-клиента с токеном 
        //    public static HttpClient CreateClient(string accessToken = "")
        //    {
        //        var client = new HttpClient();
        //        if (!string.IsNullOrWhiteSpace(accessToken))
        //        {
        //            client.DefaultRequestHeaders.Authorization =
        //                new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", accessToken);
        //        }
        //        return client;
        //    }
        //}

        //public class Account
        //{
        //    public int id { get; set; }
        //    public string secondName { get; set; }
        //    public string firstName { get; set; }
        //    public string patronymic { get; set; }
        //    public string role { get; set; }
        //    public DateTime createdAt { get; set; }
        //    public string login { get; set; }


        //}

        //public class File
        //{
        //    public string uuid { get; set; }
        //    public DateTime createdAt { get; set; }
        //    public string name { get; set; }
        //    public int size { get; set; }
        //    public string url { get; set; }

        //    // получаем информацию о дисциплине 
        //    public static string GetFileInfo(string token, string id_dis, string id_exe)
        //    {
        //        using (var client = MainClass.Token.CreateClient(token))
        //        {
        //            var response = client.GetAsync(APP_PATH + "/disciplines/" + id_dis + "/exercises/" + id_exe + "/").Result;
        //            Console.WriteLine(APP_PATH + "/disciplines/" + id_dis + "/exercises/" + id_exe + "/");
        //            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        //            return response.Content.ReadAsStringAsync().Result;
        //        }
        //    }
        //}

        //public class ExerciseFile
        //{
        //    public string exerciseFileType { get; set; }
        //    public File file { get; set; }
        //}

        //public class Data
        //{
        //    public int orderNumber { get; set; }
        //    public List<ExerciseFile> exerciseFiles { get; set; }
        //    public DateTime createdAt { get; set; }
        //    public string name { get; set; }
        //    public int id { get; set; }
        //}

        //public class ListDiscipline
        //{
        //    public int id { get; set; }
        //    public string description { get; set; }
        //    public string name { get; set; }
        //    public DateTime createdAt { get; set; }
        //    public bool isPublic { get; set; }
        //    public bool isRemoved { get; set; }

        //    // получаем информацию о дисциплине 
        //    public static string GetDisciplineInfo(string token, string id)
        //    {
        //        using (var client = MainClass.Token.CreateClient(token))
        //        {
        //            var response = client.GetAsync(APP_PATH + "/disciplines/" + id + "/exercises/").Result;
        //            Console.WriteLine(APP_PATH + "/disciplines/" + id + "/exercises/");
        //            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        //            return response.Content.ReadAsStringAsync().Result;

        //        }
        //    }
        //}


        //public class Person
        //{
        //    public Token token { get; set; }
        //    public Account account { get; set; }

            
        //    // получаем информацию о клиенте 
        //    public static string GetUserInfo(string token, string secondName)
        //    {
        //        using (var client = MainClass.Token.CreateClient(token))
        //        {
        //            var response = client.GetAsync(APP_PATH + "/disciplines/?teacherFullName=" + secondName).Result;
        //            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        //            return response.Content.ReadAsStringAsync().Result;
                    
        //        }
        //    }
        //}

        //public class Root<T>
        //{
        //    public string type { get; set; }
        //    public T data { get; set; }
        //    public bool isSuccess { get; set; }
        //}
    }
}
