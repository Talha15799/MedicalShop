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
    public partial class Employeeform : Form
    {
        public Employeeform()
        {
            InitializeComponent();
        }
        SqlConnection objcon;
        SqlDataAdapter objad;
        DataTable objdt;
        SqlCommand objcomm;
        string Mode;

        private void Employeeform_Load(object sender, EventArgs e)
        {
            string constr = @"data source=.;initial catalog=MedicalShopdb;integrated security=SSPI";
            objcon = new SqlConnection(constr);
            btnSave.Enabled = false;
            groupBox1.Enabled = false;
            cmbEmployeeID.Visible = false;
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
            Txtemployeeid.Visible = false;
            cmbEmployeeID.Visible = true;
            objad = new SqlDataAdapter("select distinct(emp_id) from employee", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            cmbEmployeeID.Items.Clear();
            foreach (DataRow dr in objdt.Rows)
            {
                cmbEmployeeID.Items.Add(dr["emp_id"].ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
         
            groupBox1.Enabled = true;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            Mode = "Update";
            btnSave.Text = "Update Now";
            Txtemployeeid.Visible = false;
            cmbEmployeeID.Visible = true;
            objad = new SqlDataAdapter("select distinct(emp_id) from employee", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            cmbEmployeeID.Items.Clear();
            foreach (DataRow dr in objdt.Rows)
            {
                cmbEmployeeID.Items.Add(dr["emp_id"].ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(Mode=="Insert")
            {
                if(Txtemployeeid.Text=="")
                {
                    MessageBox.Show("Please enter employeeid..");
                    Txtemployeeid.Focus();
                }
                else if(Txtname.Text=="")
                {
                    MessageBox.Show("Please enter name..");
                    Txtname.Focus();
                }
                 else if(Txtaddress.Text=="")
                {
                    MessageBox.Show("Please enter address..");
                    Txtaddress.Focus();
                }
                 else if(Txtphoneno.Text=="")
                {
                    MessageBox.Show("Please enter phoneno..");
                    Txtphoneno.Focus();
                }
                 else if(Txtemail.Text=="")
                {
                    MessageBox.Show("Please enter email..");
                    Txtemail.Focus();
                }
                 else if(txtDesignation.Text=="")
                {
                    MessageBox.Show("Please enter designation..");
                    txtDesignation.Focus();
                }
                 else if(TxtSalary.Text=="")
                {
                    MessageBox.Show("Please enter salary..");
                    TxtSalary.Focus();
                }
                else
                {
                    objad = new SqlDataAdapter("select * from employee where emp_id='" + Txtemployeeid.Text + "'", objcon);
                    objdt = new DataTable();
                    objad.Fill(objdt);
                    if (objdt.Rows.Count > 0)
                    {
                        MessageBox.Show("Duplicate Entry..");
                        Txtemployeeid.Text = "";
                        Txtemployeeid.Focus();
                    }
                    else
                    {
                        objcomm = new SqlCommand("insert into employee(emp_id,name,address,phoneno,email,designation,salary) values(" + Txtemployeeid.Text + ",'" + Txtname.Text + "','" + Txtaddress.Text + "','" + Txtphoneno.Text + "','" + Txtemail.Text + "','" + txtDesignation.Text + "','" + TxtSalary.Text + "')", objcon);
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
                if(Mode=="Update")
                {
                    objcomm = new SqlCommand("update employee set salary='" + TxtSalary.Text + "' where emp_id='" + cmbEmployeeID.Text + "'", objcon);
                    objcon.Open();
                    objcomm.ExecuteNonQuery();
                    objcon.Close();
                    MessageBox.Show("one record updated..");
                    btnUpdate.Enabled = false;
                    cmbEmployeeID.Items.Clear();
                    cmbEmployeeID.Text = "";
                    cmbEmployeeID.Focus();
                }
                else
                {
                    if (Mode == "Delete")
                    {
                        objcomm = new SqlCommand("delete employee where emp_id='" + cmbEmployeeID.Text + "'", objcon);
                        objcon.Open();
                        objcomm.ExecuteNonQuery();
                        objcon.Close();
                        MessageBox.Show("one record deleted..");
                        btnDelete.Enabled = false;
                        cmbEmployeeID.Items.Clear();
                        cmbEmployeeID.Focus();
                    }
                }
                 Txtname.Text = "";
                Txtaddress.Text = "";
                Txtphoneno.Text = "";
                Txtemail.Text = "";
                txtDesignation.Text="";
                TxtSalary.Text="";
                cmbEmployeeID.Items.Clear();
                Mode="";
                btnSave.Text="save";
            }
        }

        private void cmbEmployeeID_SelectedIndexChanged(object sender, EventArgs e)
        {
            
               objad = new SqlDataAdapter("select * from employee where emp_id='" +cmbEmployeeID.Text+ "'", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);

            Txtname.Text = objdt.Rows[0]["Name"].ToString();
            Txtaddress.Text = objdt.Rows[0]["Address"].ToString();
            Txtphoneno.Text = objdt.Rows[0]["PhoneNo"].ToString();
            Txtemail.Text = objdt.Rows[0]["Email"].ToString();
            txtDesignation.Text = objdt.Rows[0]["Designation"].ToString();
            TxtSalary.Text = objdt.Rows[0]["Salary"].ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        }
        }

    
