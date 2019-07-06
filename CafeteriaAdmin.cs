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
    public partial class CafeteriaAdmin : Form
    {
        string adminName = null;
        public CafeteriaAdmin(string AN)
        {
            this.adminName = AN;
            InitializeComponent();

        }

        private void CafeteriaAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
