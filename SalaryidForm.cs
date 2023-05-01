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
    public partial class SalaryidForm : Form
    {
        public SalaryidForm()
        {
            InitializeComponent();
        }
        SqlConnection objcon;
        SqlDataAdapter objad;
        DataTable objdt;



        private void SalaryidForm_Load(object sender, EventArgs e)
        {
            string constr = @"data source=.; initial catalog=MedicalShopdb; integrated security=SSPI";
            objcon = new SqlConnection(constr);
            objad = new SqlDataAdapter("select * from salary", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            cmbEmployeeID.Enabled = false;
        }

        private void rdbtnViewAll_CheckedChanged(object sender, EventArgs e)
        {
            cmbEmployeeID.Enabled = false;
            cmbEmployeeID.Visible = false;
            cmbEmployeeID.Items.Clear();
        }

        private void rdbtnIDwise_CheckedChanged(object sender, EventArgs e)
        {
            cmbEmployeeID.Enabled = true;
            cmbEmployeeID.Visible = true;
            foreach (DataRow dr in objdt.Rows)
            {
                cmbEmployeeID.Items.Add(dr["emp_id"].ToString());
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (rdbtnIDwise.Checked == true)
            {
                objad = new SqlDataAdapter("select * from salary where emp_id='" + cmbEmployeeID.Text + "'", objcon);
                objdt = new DataTable();
                objad.Fill(objdt);
                dataGridView1.DataSource = objdt;
            }
            else
            {
                objad = new SqlDataAdapter("select *from salary", objcon);
                objdt = new DataTable();
                objad.Fill(objdt);
                dataGridView1.DataSource = objdt;
            }
            
            
            cmbEmployeeID.Focus();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }
    }

