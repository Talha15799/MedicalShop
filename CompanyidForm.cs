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
    public partial class CompanyidForm : Form
    {
        public CompanyidForm()
        {
            InitializeComponent();
        }
        SqlConnection objcon;
        SqlDataAdapter objad;
        DataTable objdt;

        private void CompanyidForm_Load(object sender, EventArgs e)
        {
            string constr = @"data source=.; initial catalog=MedicalShopdb; integrated security=SSPI";
            objcon = new SqlConnection(constr);
            objad = new SqlDataAdapter("select * from company", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            cmbCompanyID.Enabled = false;

        }

        private void rdbtnViewAll_CheckedChanged(object sender, EventArgs e)
        {
            cmbCompanyID.Enabled = false;
            cmbCompanyID.Visible = false;
            cmbCompanyID.Items.Clear();
        }

        private void rdbtnIDwise_CheckedChanged(object sender, EventArgs e)
        {
            cmbCompanyID.Enabled = true;
            cmbCompanyID.Visible = true;
            foreach (DataRow dr in objdt.Rows)
            {
                cmbCompanyID.Items.Add(dr["Cmp_Id"].ToString());
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (rdbtnIDwise.Checked == true)
            {
                objad = new SqlDataAdapter("select * from company where cmp_id='" + cmbCompanyID.Text + "'", objcon);
                objdt = new DataTable();
                objad.Fill(objdt);
                dataGridView1.DataSource = objdt;
            }
            else
            {
                objad = new SqlDataAdapter("select * from company", objcon);
                objdt = new DataTable();
                objad.Fill(objdt);
                dataGridView1.DataSource = objdt;
            }
            cmbCompanyID.Focus();
        }
        }
    }

