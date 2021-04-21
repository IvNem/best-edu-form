using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                var response_content = File.GetContentInfo(acess_token, id_discipline, id_exercize);
                Root<Data> exercize = JsonConvert.DeserializeObject<Root<Data>>(response_content);
                string url = exercize.data.content.file.url;
                Console.WriteLine(APP_PATH + url);

                WebClient webClient = new WebClient();

                var response_file = File.GetFileInfo(acess_token, id_discipline, id_exercize);
                Root<List<Content>> code = JsonConvert.DeserializeObject<Root<List<Content>>>(response_file);
                Console.WriteLine(code);
                if (code.data.Count == 0)
                {
                    Console.WriteLine(code.data);
                    richTextBox1.Text = "В данном уроке отсутствует код для компиляции";
                }
                else 
                {
                    string url_code = code.data[0].file.url;
                    Console.WriteLine(APP_PATH + url_code);
                    richTextBox1.Text = webClient.DownloadString(APP_PATH + url_code);
                }
                

                byte[] bytes = Encoding.Default.GetBytes(webClient.DownloadString(APP_PATH + url));
                string myString = Encoding.UTF8.GetString(bytes);
                var html = Markdig.Markdown.ToHtml(myString);
                webBrowser1.DocumentText = html;
            }
        }

        private void buttonCompile_Click(object sender, EventArgs e)
        {
            string workingDirectory = @"C:\best-edu";

            MessageBox.Show(workingDirectory);

            DirectoryInfo dirInfo = new DirectoryInfo(workingDirectory);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }


            using (StreamWriter sw = new StreamWriter($"{workingDirectory}\\main.c", false, System.Text.Encoding.Default))
            {
                sw.Write(richTextBox1.Text);
            }
        }
    }
}
