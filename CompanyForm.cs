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
    public partial class CompanyForm : Form
    {
        public CompanyForm()
        {
            InitializeComponent();
        }
        SqlConnection objcon;
        SqlDataAdapter objad;
        DataTable objdt;
        SqlCommand objcomm;
        string Mode;

        private void CompanyForm_Load(object sender, EventArgs e)
        {
            string constr = @"data source=.; initial catalog=MedicalShopdb; integrated security=SSPI";
            objcon = new SqlConnection(constr);
            btnSave.Enabled = false;
            groupBox1.Enabled = false;
            cmbCompanyID.Visible = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            
                groupBox1.Enabled = true;
                btnInsert.Enabled = false;
                btnSave.Enabled = true;
                Mode = "Insert";
                btnSave.Text = "Insert Now";
            }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            Mode = "Update";
            btnSave.Text = "Update Now";
            TxtcompanyID.Visible = false;
            cmbCompanyID.Visible = true;
            cfill();
        }

  
    
    
   
 

        private void cmbCompanyID_SelectedIndexChanged(object sender, EventArgs e)
        {
            objad = new SqlDataAdapter("select * from company where Cmp_id='" + cmbCompanyID.Text + "'", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);

            Txtname.Text = objdt.Rows[0]["Name"].ToString();
            Txtaddress.Text = objdt.Rows[0]["Address"].ToString();
            Txtphone.Text = objdt.Rows[0]["Phone"].ToString();
            Txtemail.Text = objdt.Rows[0]["Email"].ToString();
            TxtWebsite.Text = objdt.Rows[0]["Website"].ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            Mode = "Delete";
            btnSave.Text = "Delete Now";
            TxtcompanyID.Visible = false;
            cmbCompanyID.Visible = true;
            cfill();
        }

        private void cfill()
        {
            objad = new SqlDataAdapter("select distinct(Cmp_id) from medicine", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            cmbCompanyID.Items.Clear();
            foreach (DataRow dr in objdt.Rows)
            {
                cmbCompanyID.Items.Add(dr["Cmp_id"].ToString());
}
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Mode == "Insert")
            {
                if (TxtcompanyID.Text == "")
                {
                    MessageBox.Show("Please Enter Company ID..");
                    TxtcompanyID.Focus();
                }
                else if (Txtname.Text == "")
                {
                    MessageBox.Show("Please Enter Name..");
                    Txtname.Focus();
                }
                else if (Txtaddress.Text == "")
                {
                    MessageBox.Show("Please Enter Address..");
                    Txtaddress.Focus();
                }
                else if (Txtphone.Text == "")
                {
                    MessageBox.Show("Please Enter Phone..");
                    Txtphone.Focus();
                }
                else if (Txtemail.Text == "")
                {
                    MessageBox.Show("Please Enter Email..");
                    Txtemail.Focus();
                }

                else if (TxtWebsite.Text == "")
                {
                    MessageBox.Show("Please Enter Website..");
                    TxtWebsite.Focus();
                }

                else
                {

                    objad = new SqlDataAdapter("select * from company where Cmp_id='" + TxtcompanyID.Text + "'", objcon);
                    objdt = new DataTable();
                    objad.Fill(objdt);
                    if (objdt.Rows.Count > 0)
                    {
                        MessageBox.Show("Duplicate Entry..");
                        TxtcompanyID.Text = "";
                        TxtcompanyID.Focus();
                    }



                    else
                    {

                        objcomm = new SqlCommand("insert into company(Cmp_id,Name,Address,Phone,Email,Website) values(" + TxtcompanyID.Text + ",'" + Txtname.Text + "','" + Txtaddress.Text + "','" + Txtphone.Text + "','" + Txtemail.Text + "','" + TxtWebsite.Text + "')", objcon);
                        objcon.Open();
                        objcomm.ExecuteNonQuery();
                        objcon.Close();
                        MessageBox.Show("one record inserted..");
                        btnInsert.Enabled = false;
                    }
                }
            }

            else
            {
                if (Mode == "Update")
                {
                    objcomm = new SqlCommand("update company set Phone='" + Txtphone.Text + "' where Cmp_id='" + cmbCompanyID.Text + "'", objcon);
                    objcon.Open();
                    objcomm.ExecuteNonQuery();
                    objcon.Close();
                    MessageBox.Show("one record updated..");
                    btnUpdate.Enabled = false;
                }

                else
                {
                    if (Mode == "Delete")
                    {
                        objcomm = new SqlCommand("delete medicine where Cmp_id=" + cmbCompanyID.Text + "", objcon);
                        objcon.Open();
                        objcomm.ExecuteNonQuery();
                        objcon.Close();
                        MessageBox.Show("one record Deleted..");
                        btnDelete.Enabled = false;
                    }
                }

                Txtname.Text = "";
                Txtaddress.Text = "";
                Txtphone.Text = "";
                Txtemail.Text = "";
                TxtWebsite.Text = "";
                cmbCompanyID.Items.Clear();
                Mode = "";
                btnSave.Text = "Save";
            }
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       


     
      
    }
}

    


