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
    public partial class customerform : Form
    {
        public customerform()
        {
            InitializeComponent();
        }
        SqlConnection objcon;
        SqlDataAdapter objad;
        DataTable objdt;
        SqlCommand objcomm;
        string Mode;

        private void customerform_Load(object sender, EventArgs e)
        {
            string constr = @"data source=.; initial catalog=MedicalShopdb; integrated security=SSPI";
            objcon = new SqlConnection(constr);
            btnSave.Enabled = false;
            groupBox1.Enabled = false;
            cmbCustomerID.Visible = false;
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
            TxtCustomerID.Visible = false;
            cmbCustomerID.Visible = true;
            objad = new SqlDataAdapter("select distinct(C_Id) from customer", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            cmbCustomerID.Items.Clear();
            foreach (DataRow dr in objdt.Rows)
            {
                cmbCustomerID.Items.Add(dr["C_Id"].ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        groupBox1.Enabled = true;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            Mode = "Delete";
            btnSave.Text = "Delete Now";
            TxtCustomerID.Visible = false;
            cmbCustomerID.Visible = true;
            objad = new SqlDataAdapter("select distinct(C_Id) from customer", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            cmbCustomerID.Items.Clear();
            foreach (DataRow dr in objdt.Rows)
            {
                cmbCustomerID.Items.Add(dr["C_Id"].ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Mode == "Insert")
            {
                if (TxtCustomerID.Text == "")
                {
                    MessageBox.Show("Please Enter Company ID..");
                   TxtCustomerID.Focus();
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
                else if (TxtPhoneNo.Text == "")
                {
                    MessageBox.Show("Please Enter Phone..");
                    TxtPhoneNo.Focus();
                }
                else if (Txtemail.Text == "")
                {
                    MessageBox.Show("Please Enter Email..");
                    Txtemail.Focus();
                }
                else
                {

                    objad = new SqlDataAdapter("select * from customer where C_Id='"+TxtCustomerID.Text + "'", objcon);
                    objdt = new DataTable();
                    objad.Fill(objdt);
                    if (objdt.Rows.Count > 0)
                    {
                        MessageBox.Show("Duplicate Entry..");
                        TxtCustomerID.Text = "";
                        TxtCustomerID.Focus();
                    }
                    else
                    {
                         objcomm = new SqlCommand("insert into customer(C_Id,Name,Address,PhoneNo,Email) values(" +TxtCustomerID.Text+ ",'" + Txtname.Text + "','" + Txtaddress.Text + "','"+TxtPhoneNo.Text+ "','" + Txtemail.Text + "')", objcon);
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
                    objcomm = new SqlCommand("update customer set PhoneNo='" +TxtPhoneNo.Text + "' where C_Id ='" +cmbCustomerID.Text + "'", objcon);
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
                        objcomm = new SqlCommand("delete customer where C_Id=" +cmbCustomerID.Text + "", objcon);
                        objcon.Open();
                        objcomm.ExecuteNonQuery();
                        objcon.Close();
                        MessageBox.Show("one record Deleted..");
                        btnDelete.Enabled = false;
                        cmbCustomerID.Items.Clear();
                        cmbCustomerID.Focus();
                    }
                }

                Txtname.Text = "";
                Txtaddress.Text = "";
                TxtPhoneNo.Text = "";
                Txtemail.Text = "";
                cmbCustomerID.Items.Clear();
                Mode = "";
                btnSave.Text = "Save";
            }
        }

        private void cmbCustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {
               objad = new SqlDataAdapter("select * from customer where C_Id='" +cmbCustomerID.Text+ "'", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);

            Txtname.Text = objdt.Rows[0]["Name"].ToString();
            Txtaddress.Text = objdt.Rows[0]["Address"].ToString();
            TxtPhoneNo.Text = objdt.Rows[0]["PhoneNo"].ToString();
            Txtemail.Text = objdt.Rows[0]["Email"].ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

       

        }
        }

       
    
