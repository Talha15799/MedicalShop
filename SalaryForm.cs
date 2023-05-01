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
    public partial class SalaryForm : Form
    {
        public SalaryForm()
        {
            InitializeComponent();
        }

        SqlConnection objcon;
        SqlDataAdapter objad;
        DataTable objdt;
        SqlCommand objcomm;

        private void SalaryForm_Load(object sender, EventArgs e)
        {

            string constr = @"data source=.; initial catalog=MedicalShopdb; integrated security=SSPI";
            objcon = new SqlConnection(constr);
            objad = new SqlDataAdapter("select distinct(emp_id) from employee", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            foreach (DataRow dr in objdt.Rows)
            {
                cmbEmployeeID.Items.Add(dr["emp_id"].ToString());

            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbEmployeeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            objad = new SqlDataAdapter("select * from employee where emp_id='"+cmbEmployeeID.Text+"'", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
           
            txtName.Text = objdt.Rows[0]["name"].ToString();
            txtBasicSalary.Text = objdt.Rows[0]["salary"].ToString();
            txtName.Enabled = false;
            txtBasicSalary.Enabled = false;
            
        }

        private void txtBonus_TextChanged(object sender, EventArgs e)
        {
            int deduction;
            deduction = ((Convert.ToInt32(txtBasicSalary.Text) / 30) * Convert.ToInt32(txtLeave.Text)) + Convert.ToInt32(txtDeduction.Text);
            txtGrossSalary.Text = Convert.ToString(Convert.ToInt32(txtBasicSalary.Text) - deduction + Convert.ToInt32(txtBonus.Text));
        }

        private void i(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            objcomm = new SqlCommand("insert into salary(emp_id,leave,deduction,bonus,gross_salary,date_of_salary) values(" + cmbEmployeeID.Text + ",'" + txtLeave.Text + "','" + txtDeduction.Text + "','" + txtBonus.Text + "','" + txtGrossSalary.Text + "','" +dateTimePicker2.Text + "')", objcon);
            objcon.Open();
            objcomm.ExecuteNonQuery();
            objcon.Close();
            MessageBox.Show("one record inserted");
        }
    }
}
