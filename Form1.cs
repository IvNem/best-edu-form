﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace best_edu_form
{

    public partial class AuthorizationForm : Form
    {

        private const string APP_PATH = "https://best-edu.tk/api/v1";

        public AuthorizationForm()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var login = "ivan.nemilostiv@mail.ru";
            var password = "1234567";
            var loginResult = Login(login, password);
            var secondName = Token.CreateClient(loginResult);
            label4.Text = loginResult;
            
                
            //if (loginResult == "OK")
            //{
            Form form = new CategoryForm();
            form.Show();
            //}
            //else 
            //{
            //MessageBox.Show(token);
            //}

        }

        // регистрация
        public static string Login(string login, string password)
        {
            var loginModel = new
            {
                login = login,
                plainPassword = password,
            };
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(APP_PATH + "/accounts/login/", loginModel).Result;
                Console.WriteLine("Статус запроса: {0}", response.StatusCode.ToString());
                Console.WriteLine("Ответ: {0}", response.Content.ReadAsStringAsync().Result);
                Root<Person> root = JsonConvert.DeserializeObject<Root<Person>>
                    (response.Content.ReadAsStringAsync().Result);
                 
                Console.WriteLine(root.data.token.access_token);
                Console.WriteLine(root.data.account.secondName);
                var acs_token = root.data.token.access_token;
                var second_name = root.data.account.secondName;
                using (ResXResourceWriter resx = new ResXResourceWriter(@".\Resources.resx"))
                {
                    resx.AddResource("acess_token", acs_token);
                    resx.AddResource("second_name", second_name);
                }
                
                return root.data.token.access_token.ToString();
            }
        }

    }
}
