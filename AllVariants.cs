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
    public partial class AllVariants : Form
    {
        string firstname = null;
        string lastname = null;
        string address = null;
        string phone_number = null;

        public AllVariants(string fN, string lN, string address, string pn)
        {
            InitializeComponent();
            this.firstname = fN;
            this.lastname = lN;
            this.address = address;
            this.phone_number = pn;
        }

        private void AllVariants_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cafeteria child = new Cafeteria("cafeteria", this.firstname, this.lastname, this.address, this.phone_number);
            child.FormClosed += new FormClosedEventHandler(child_FormClosed); //add handler to catch when child form is closed
            child.Show(); //show child
            this.Hide(); //hide parent
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cafeteria child = new Cafeteria("bakery",this.firstname,this.lastname,this.address,this.phone_number);
            child.FormClosed += new FormClosedEventHandler(child_FormClosed); //add handler to catch when child form is closed
            child.Show(); //show child
            this.Hide(); //hide parent
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cafeteria child = new Cafeteria("bar", this.firstname, this.lastname, this.address, this.phone_number);
            child.FormClosed += new FormClosedEventHandler(child_FormClosed); //add handler to catch when child form is closed
            child.Show(); //show child
            this.Hide(); //hide parent
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cafeteria child = new Cafeteria("restaurant", this.firstname, this.lastname, this.address, this.phone_number);
            child.FormClosed += new FormClosedEventHandler(child_FormClosed); //add handler to catch when child form is closed
            child.Show(); //show child
            this.Hide(); //hide parent
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cafeteria child = new Cafeteria("pizzeria", this.firstname, this.lastname, this.address, this.phone_number);
            child.FormClosed += new FormClosedEventHandler(child_FormClosed); //add handler to catch when child form is closed
            child.Show(); //show child
            this.Hide(); //hide parent
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Cafeteria child = new Cafeteria("bistro", this.firstname, this.lastname, this.address, this.phone_number);
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
