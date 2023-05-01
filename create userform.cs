using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace MedicalShopManagement
{
    public partial class create_userform : Form
    {
        public create_userform()
        {
            InitializeComponent();
        }
        SqlConnection objcon;
        SqlCommand objcomm;
        string hash = "f0xle@rn";
        string encyptedUserName;
        string encyptedPassword;
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "")
            {
                MessageBox.Show("Please Enter Username..");
                txtUsername.Focus();
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show("Please Enter Password..");
                txtPassword.Focus();
            }
            else if (txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Please Enter Confirm Password..");
                txtConfirmPassword.Focus();
            }
            else if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("incorrect password");
                
                
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                txtPassword.Focus();

            }
            else
            {
                byte[] data = UTF8Encoding.UTF8.GetBytes(txtPassword.Text);
                using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                {
                    byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                    using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                    {
                        ICryptoTransform transform = tripDes.CreateEncryptor();
                        byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                        encyptedPassword= Convert.ToBase64String(results, 0, results.Length);

                    }
                }
                string usertype = "User";
                objcomm = new SqlCommand("insert into login ( username,password,acc_type) values('" + txtUsername.Text + "','" + encyptedPassword + "', '" + usertype.ToString() + "')", objcon);
                objcon.Open();

                objcomm.ExecuteNonQuery();
                objcon.Close();
                MessageBox.Show("user inserted");
            }
          
           
        }

        private void create_userform_Load(object sender, EventArgs e)
        {
            string constr = @"data source=.; initial catalog=MedicalShopdb; integrated security=SSPI";
            objcon = new SqlConnection(constr);
        }
    }
}
