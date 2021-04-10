using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace best_edu_form
{
    public partial class ListLessonsForm : Form
    {

        private const string resxFile = @".\Resources.resx";
        private const string APP_PATH = "https://best-edu.tk/disciplines/";
        string acess_token = "";
        string id_discipline = "";

        public ListLessonsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new CategoryForm();
            form.Show();
        }

        private void ListLessonsForm_Load(object sender, EventArgs e)
        {
            using (ResXResourceSet resxSet = new ResXResourceSet(resxFile))
            {
                acess_token = resxSet.GetString("acess_token");
                id_discipline = resxSet.GetString("id_discipline");
                Console.WriteLine(acess_token + "taken");
                //MessageBox.Show(s, b);

                var response = Discipline.GetDisciplineInfo(acess_token, id_discipline);
                Root<List<Discipline>> discipline = JsonConvert.DeserializeObject<Root<List<Discipline>>>
                        (response);
                //bindingSource1.DataSource = discipline.data;
                //ListViewItem item = null;
                //item = new ListViewItem(new string[] {Convert.ToString() })
                //List<MainClass.ListDiscipline>.Enumerator;
                
                listBoxLesson.DataSource = discipline.data;
                listBoxLesson.DisplayMember = "name";
                listBoxLesson.ValueMember = "id";
                //listBoxCategory.DataBindings.Add("Text", bindingSource1, "name");
                //richTextBox1.DataBindings.Add("Text", bindingSource1, "description");

                //foreach (var x in discipline.data)
                //{
                //    listBoxCategory.Items.Add(x.name);
                //    var name = x.name;
                //    Console.WriteLine(name);
                //}
                //var response = MainClass.Person.GetUserInfo();
                //Console.WriteLine("Статус запроса: {0}", response.StatusCode.ToString());
                //Console.WriteLine("Ответ: {0}", response.Content.ReadAsStringAsync().Result);
                //richTextBox1.Text = response.Headers.ToString();
                ////return response.StatusCode.ToString();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (ResXResourceWriter resx = new ResXResourceWriter(resxFile))
            {
                string s = listBoxLesson.SelectedValue.ToString();
                resx.AddResource("acess_token", acess_token);
                resx.AddResource("id_discipline", id_discipline);
                resx.AddResource("id_exercize", s);
                Console.WriteLine(s + acess_token + " 5555");
            }
            Form main = new LessonsForm();
            main.Show();
        }
    }
}
