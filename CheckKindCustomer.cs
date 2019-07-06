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
    public partial class CheckKindCustomer : Form
    {
        public CheckKindCustomer()
        {
            InitializeComponent();
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Equals("Client"))
            {
                Form1 child = new Form1(); //create new isntance of form
                child.FormClosed += new FormClosedEventHandler(child_FormClosed); //add handler to catch when child form is closed
                child.Show(); //show child
                this.Hide(); //hide parent
            }
            else
            {
               
                Form2 child = new Form2(); //create new isntance of form
                child.FormClosed += new FormClosedEventHandler(child_FormClosed); //add handler to catch when child form is closed
                child.Show(); //show child
                this.Hide(); //hide parent
            }
        }
        private void child_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void CheckKindCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
