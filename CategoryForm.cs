using Newtonsoft.Json;
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
    public partial class CategoryForm : Form
    {

        private const string resxFile = @".\Resources.resx";
        private const string APP_PATH = "https://best-edu.tk/disciplines/";
        string acess_token = "";

        public CategoryForm()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ResXResourceWriter resx = new ResXResourceWriter(resxFile))
            {
                string s = listBoxCategory.SelectedValue.ToString();
                resx.AddResource("acess_token", acess_token);
                resx.AddResource("id_discipline", s);
                Console.WriteLine(s + acess_token+ "1111");
            }
            Form form = new ListLessonsForm();
            form.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form form = new ListLessonsForm();
            form.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form form = new ListLessonsForm();
            form.Show();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            
            using (ResXResourceSet resxSet = new ResXResourceSet(resxFile))
            {
                acess_token = resxSet.GetString("acess_token");
                var second_name = resxSet.GetString("second_name");
                

                var response = Person.GetUserInfo(acess_token, second_name);
                Root<List<Discipline>> discipline = JsonConvert.DeserializeObject<Root<List<Discipline>>>
                        (response);
                bindingSource1.DataSource = discipline.data;
                listBoxCategory.DataSource = discipline.data;
                listBoxCategory.DisplayMember = "name";
                listBoxCategory.ValueMember = "id";
                listBoxCategory.DataBindings.Add("Text", bindingSource1, "name");
                richTextBox1.DataBindings.Add("Text", bindingSource1, "description");

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

        private void listBoxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //элемент списка отображает полную запись
            bindingSource1.Position = listBoxCategory.SelectedIndex;
        }
    }
}
