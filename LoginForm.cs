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
using System.Security.Cryptography;

namespace MedicalShopManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        SqlConnection objcon;
        SqlDataAdapter objad;
        DataTable objdt;
        string hash = "f0xle@rn";

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtuser.Text == "")
            {
                MessageBox.Show("Please Enter Username..");
                txtuser.Focus();
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Please Enter Password..");
                txtPassword.Focus();
            }

            objad = new SqlDataAdapter("select * from login where username ='" + txtuser.Text + "'", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);

            if (objdt.Rows.Count > 0)
            {
                string decpass;
                byte[] data = Convert.FromBase64String(objdt.Rows[0]["password"].ToString());
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                    using (TripleDESCryptoServiceProvider triples = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = triples.CreateDecryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        decpass = UTF8Encoding.UTF8.GetString(results);
                    }
                }
                if (decpass.ToString() == txtPassword.Text)
                {
                    if (objdt.Rows[0]["acc_type"].ToString() == "User")
                    {
                        MessageBox.Show("user");
                    }
                    else
                    {
                        MessageBox.Show("Admin");
                    }
                    MessageBox.Show("valid User");
                    MainForm objmain = new MainForm();

                    objmain.Show();

                }
                else
                {
                    MessageBox.Show("invalid User");
                    txtuser.Text = "";
                    txtPassword.Text = "";
                    txtuser.Focus();
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            string constr = @"data source=.; initial catalog=MedicalShopdb; integrated security=SSPI";
            objcon = new SqlConnection(constr);
        }

        
        private void btnCencel_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

    }
}

         
