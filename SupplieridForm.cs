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
    public partial class SupplieridForm : Form
    {
        public SupplieridForm()
        {
            InitializeComponent();
        }
        SqlConnection objcon;
        SqlDataAdapter objad;
        DataTable objdt;


        private void rdbtnViewAll_CheckedChanged(object sender, EventArgs e)
        {
            cmbSupplierID.Visible = false;
            cmbSupplierID.Enabled = false;
            cmbSupplierID.Items.Clear();
           
        }

        private void rdbtnIDwise_CheckedChanged(object sender, EventArgs e)
        {
            cmbSupplierID.Enabled = true;
            cmbSupplierID.Visible = true;
            foreach (DataRow dr in objdt.Rows)
            {
                cmbSupplierID.Items.Add(dr["Supplier_Id"].ToString());
            }
        }

        private void SupplieridForm_Load(object sender, EventArgs e)
        {
            string constr = @"data source=.; initial catalog=MedicalShopdb; integrated security=SSPI";
            objcon = new SqlConnection(constr);
            objad = new SqlDataAdapter("select * from supplier", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            cmbSupplierID.Enabled = false;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {

            if (rdbtnIDwise.Checked == true)
            {
                objad = new SqlDataAdapter("select * from supplier where supplier_id='" + cmbSupplierID.Text + "'", objcon);
                objdt = new DataTable();
                objad.Fill(objdt);
                dataGridView1.DataSource = objdt;
            }
            else
            {
                objad = new SqlDataAdapter("select *from supplier", objcon);
                objdt = new DataTable();
                objad.Fill(objdt);
                dataGridView1.DataSource = objdt;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

    }
}
