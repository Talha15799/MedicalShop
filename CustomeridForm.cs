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
    public partial class CustomeridForm : Form
    {
        public CustomeridForm()
        {
            InitializeComponent();
        }
        SqlConnection objcon;
        SqlDataAdapter objad;
        DataTable objdt;
        

        private void CustomeridForm_Load(object sender, EventArgs e)
        {
            string constr = @"data source=.;initial catalog=MedicalShopdb;integrated security=SSPI";
            objcon = new SqlConnection(constr);
            objad = new SqlDataAdapter("select * from customer", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            cmbCustomerID.Enabled = false;
        }

        private void rdbtnViewAll_CheckedChanged(object sender, EventArgs e)
        {
            cmbCustomerID.Enabled = false;
            cmbCustomerID.Visible = false;
            cmbCustomerID.Items.Clear();
        }

        private void rdbtnIDwise_CheckedChanged(object sender, EventArgs e)
        {
            cmbCustomerID.Enabled = true;
            cmbCustomerID.Visible = true;
            foreach (DataRow dr in objdt.Rows)
            {
                cmbCustomerID.Items.Add(dr["C_Id"].ToString());
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if(rdbtnIDwise.Checked==true)
            {
                objad = new SqlDataAdapter("select * from customer where C_Id='" + cmbCustomerID.Text + "'", objcon);
                objdt = new DataTable();
                objad.Fill(objdt);
                dataGridView1.DataSource = objdt;
            }
            else
            {
                objad = new SqlDataAdapter("select * from customer", objcon);
                objdt =new DataTable();
                objad.Fill(objdt);
                dataGridView1.DataSource= objdt;
            }
            cmbCustomerID.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        }
    }

