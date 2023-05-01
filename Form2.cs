using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalShopManagement
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Btnsave.Enabled = false;
        }
        string mode;
        private void Btninsert_Click(object sender, EventArgs e)
        {
            Btnsave.Enabled = true;
            mode = "Insert";
        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            if (mode == "Insert")
            {

            }

        }

        private void Btnupdate_Click(object sender, EventArgs e)
        {
            Txtemployeeid.Visible = false;
            comboBox1.Visible = true;
            mode = "Update";
            Btnsave.Text = "Update Now";
            Btnupdate.Enabled = false;
        }
    }
}
