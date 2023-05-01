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
    public partial class changepasswordform : Form
    {
        public changepasswordform()
        {
            InitializeComponent();
        }
        SqlConnection objcon;
        SqlCommand objcomm;
        DataTable objdt;
        SqlDataAdapter objadapter;

        private void changepasswordform_Load(object sender, EventArgs e)
        {
            string constr = @"data source=.; initial catalog=MedicalShopdb; integrated security=SSPI";
            objcon = new SqlConnection(constr);
        }

        private void btnchangepassword_Click(object sender, EventArgs e)
        {
            objcomm = new SqlCommand("update login set password='" + txtNewPassword.Text + "' where username='" + txtUsername.Text + "'", objcon);
            objcon.Open();
            objcomm.ExecuteNonQuery();
            objcon.Close();
            MessageBox.Show("password updated");
        }

    }
}
