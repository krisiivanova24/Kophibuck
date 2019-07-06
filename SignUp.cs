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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            database.SignUpNewClient(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            AllVariants child = new AllVariants(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            child.FormClosed += new FormClosedEventHandler(child_FormClosed); //add handler to catch when child form is closed
            child.Show(); //show child
            this.Hide(); //hide parent
        }

        private void child_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
