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
    public partial class AllVariantsAdmin : Form
    {
        string name = null;
        string variant = null;
        string id = null;
        string namePlace = null;
        int seats = 0;
        int tables = 0;

        public AllVariantsAdmin(string name, string variant, string id, List<string> info)
        {
            this.name = name;
            this.variant = variant;
            this.id = id;
            this.namePlace = info[0];
            this.seats = int.Parse(info[1]);
            this.tables = int.Parse(info[2]);
            
            InitializeComponent();

            label1.Text = this.namePlace;
            label10.Text = this.seats.ToString();
            label11.Text = this.tables.ToString();
            label12.Text = this.seats.ToString();
            label13.Text = this.tables.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            List<int> results  = database.UpdatePlaceBook(this.variant, int.Parse(this.id), this.seats, this.tables, int.Parse(textBox1.Text), int.Parse(textBox2.Text));
            label10.Text = results[0].ToString();
            label11.Text = results[1].ToString();
            label12.Text = results[0].ToString();
            label13.Text = results[1].ToString();
            this.seats = results[0];
            this.tables = results[1];
            textBox1.Text = null;
            textBox2.Text = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            List<int> results = database.UpdatePlaceFree(this.variant, int.Parse(this.id), this.seats, this.tables, int.Parse(textBox3.Text), int.Parse(textBox4.Text));
            label10.Text = results[0].ToString();
            label11.Text = results[1].ToString();
            label12.Text = results[0].ToString();
            label13.Text = results[1].ToString();
            this.seats = results[0];
            this.tables = results[1];
            textBox3.Text = null;
            textBox4.Text = null;
        }
    }
}
