using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace best_edu_form
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
    }
}
