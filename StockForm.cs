using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MedicalShopManagement
{
    public partial class StockForm : Form
    {
        public StockForm()
        {
            InitializeComponent();
        }
        SqlConnection objcon;
        SqlDataAdapter objad;
        DataTable objdt;

        private void StockForm_Load(object sender, EventArgs e)
        {
            string constr = @"data source=.; initial catalog=MedicalShopdb; integrated security=SSPI";
            objcon = new SqlConnection(constr);
            objad = new SqlDataAdapter("select * from stock", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
        }

        private void rdbtnViewAll_CheckedChanged(object sender, EventArgs e)
        {
            DTPfrom.Visible = false;
            DTPto.Visible = false;
        }

        private void rdbtnDateWise_CheckedChanged(object sender, EventArgs e)
        {
            DTPfrom.Visible = true;
            DTPto.Visible = true;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (rdbtnDateWise.Checked == true)
            {
                objad = new SqlDataAdapter("select * from stock where dolu>='" + DTPfrom.Text+ "' and dolu<='" + DTPto.Text+ "'", objcon);
                objdt = new DataTable();
                objad.Fill(objdt);
                dataGridView1.DataSource = objdt;
            }
            else
            {
                objad = new SqlDataAdapter("select * from stock", objcon);
                objdt = new DataTable();
                objad.Fill(objdt);
                dataGridView1.DataSource = objdt;
            }
        }
    }
}
