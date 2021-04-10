using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace best_edu_form
{
    public partial class LessonsForm : Form
    {
        private const string resxFile = @".\Resources.resx";
        private const string APP_PATH = "https://best-edu.tk";
        string acess_token = "";

        public LessonsForm()
        {
            InitializeComponent();
        }

        private void LessonForm_Load(object sender, EventArgs e)
        {
            using (ResXResourceSet resxSet = new ResXResourceSet(resxFile)) 
            {
                acess_token = resxSet.GetString("acess_token");
                string id_discipline = resxSet.GetString("id_discipline");
                var id_exercize = resxSet.GetString("id_exercize");
                Console.WriteLine(acess_token + "taken");
                //добавить функцию
                var response = File.GetFileInfo(acess_token, id_discipline, id_exercize);
                Root<Data> exercize = JsonConvert.DeserializeObject<Root<Data>>(response);
                string url = exercize.data.exerciseFiles[0].file.url;
                Console.WriteLine(APP_PATH + url);
                WebClient webClient = new WebClient();
                byte[] bytes = Encoding.Default.GetBytes(webClient.DownloadString(APP_PATH + url));
                string myString = Encoding.UTF8.GetString(bytes);
                var html = Markdig.Markdown.ToHtml(myString);
                webBrowser1.DocumentText = html;
            }
        }

    }
}
