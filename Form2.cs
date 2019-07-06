using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kophibuck
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            List<string> name = database.CheckIn(textBox1.Text, textBox2.Text);
            if (name.Count != 0)
            {
                List<string> infoAboutPlace = database.SelectPlaceAdmin(name[1], int.Parse(name[2]));
                AllVariantsAdmin child = new AllVariantsAdmin(name[0], name[1], name[2], infoAboutPlace); //create new isntance of form
                child.FormClosed += new FormClosedEventHandler(child_FormClosed); //add handler to catch when child form is closed
                child.Show(); //show child
                this.Hide(); //hide parent
            }
        }
        private void child_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

    }
}
