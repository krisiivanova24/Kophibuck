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
    public partial class Cafeteria : Form
    {
        string variant = "";
        string firstname = null;
        string lastname = null;
        string address = null;
        string phone_number = null;
        public Cafeteria(string type, string fN, string lN, string address, string pn)
        {
            this.firstname = fN;
            this.lastname = lN;
            this.address = address;
            this.phone_number = pn;
            InitializeComponent();
            switch (type)
            {
                case "cafeteria":
                    {
                        pictureBox3.Visible = true;
                        pictureBox4.Visible = true;
                        variant = "cafeteria";
                        break;
                    }
                case "bakery":
                    {
                        pictureBox6.Visible = true;
                        pictureBox5.Visible = true;
                        variant = "bakery";
                        break;
                    }
                case "bistro":
                    {
                        pictureBox9.Visible = true;
                        pictureBox10.Visible = true;
                        variant = "bistro";
                        break;
                    }
                case "restaurant":
                    {
                        pictureBox11.Visible = true;
                        pictureBox12.Visible = true;
                        variant = "restaurant";
                        break;
                    }
                case "bar":
                    {
                        pictureBox7.Visible = true;
                        pictureBox8.Visible = true;
                        variant = "bar";
                        break;
                    }
                case "pizzeria":
                    {
                        pictureBox13.Visible = true;
                        pictureBox14.Visible = true;
                        variant = "pizzeria";
                        break;
                    }
            }
            Database database = new Database();
            List<string> names = database.SelectPlace(variant);
            for (int i = 0; i < names.Count; i++)
            {
                comboBox1.Items.Add(names[i]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            button2.Enabled = false;
            comboBox1.Enabled = false;
            textBox15.Text = null;
            textBox17.Text = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Database database = new Database();
                database.UpdatePlace(variant, label12.Text, label14.Text, int.Parse(label10.Text), int.Parse(label11.Text), int.Parse(textBox15.Text), int.Parse(textBox17.Text));
                MessageBox.Show("Congratulations! You booked successfully!","Successfully booked",MessageBoxButtons.OK,MessageBoxIcon.Information);
                
            }
            catch (Exception)
            {
                MessageBox.Show("Please take a look at the input", "Sorry, something went wrong",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
        }
        private void child_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                Database database = new Database();
                string[] selectedCafe = comboBox1.Text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                List<string> valuesFromCafe = database.SelectThisPlace(variant, selectedCafe);
                label12.Text = valuesFromCafe[0];
                label13.Text = valuesFromCafe[1];
                label14.Text = valuesFromCafe[2];
                label10.Text = valuesFromCafe[3];
                label11.Text = valuesFromCafe[4];
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AllVariants child = new AllVariants(this.firstname, this.lastname, this.address, this.phone_number);
            child.FormClosed += new FormClosedEventHandler(child_FormClosed); //add handler to catch when child form is closed
            child.Show(); //show child
            this.Hide(); //hide parent
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            button2.Enabled = true;
            comboBox1.Enabled = true;
        }
    }
}
