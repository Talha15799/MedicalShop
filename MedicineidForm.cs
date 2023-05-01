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
    public partial class MedicineidForm : Form
    {
        public MedicineidForm()
        {
            InitializeComponent();
        }

        SqlConnection objcon;
        SqlDataAdapter objad;
        DataTable objdt;
       
        private void MedicineidForm_Load(object sender, EventArgs e)
        {
            string conStr = @"data source=.; initial catalog=MedicalShopdb; integrated security=SSPI";
            objcon = new SqlConnection(conStr);
            objad = new SqlDataAdapter("select * from medicine", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            cmbMedicineCode.Enabled = false;
            
            

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdbtnViewAll_CheckedChanged(object sender, EventArgs e)
        {
            cmbMedicineCode.Enabled = false;
            cmbMedicineCode.Visible = false;
            cmbMedicineCode.Items.Clear();
           
        }

        private void rdbtnIDwise_CheckedChanged(object sender, EventArgs e)
        {

            cmbMedicineCode.Enabled = true;
            cmbMedicineCode.Visible = true;
            foreach(DataRow dr in objdt.Rows)
            {
                cmbMedicineCode.Items.Add(dr["MedicineCode"].ToString());
                
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (rdbtnIDwise.Checked == true)
            {
                objad = new SqlDataAdapter("select * from Medicine where MedicineCode='" + cmbMedicineCode.Text + "'", objcon);
                objdt = new DataTable();
                objad.Fill(objdt);
                dataGridView1.DataSource = objdt;
            }
            else
            {
                objad = new SqlDataAdapter("select *from Medicine", objcon);
                objdt = new DataTable();
                objad.Fill(objdt);
                dataGridView1.DataSource = objdt;
            }
            
            
            cmbMedicineCode.Focus();

        }

        


  
    }
}
