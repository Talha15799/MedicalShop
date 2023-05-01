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
    public partial class supplier1form : Form
    {
        public supplier1form()
        {
            InitializeComponent();
        }
        SqlConnection objcon;
        SqlDataAdapter objad;
        DataTable objdt;
        SqlCommand objcomm;
        string Mode;



        private void btnInsert_Click(object sender, EventArgs e)
        {

            groupBox1.Enabled = true;
            btnInsert.Enabled = false;
            btnsave.Enabled= true;
            Mode = "Insert";
            btnsave.Text = "Insert Now";

           
        }

        private void cmbCompanyID_Click(object sender, EventArgs e)
        {
            cmbCompanyID.Items.Clear();
            objad = new SqlDataAdapter("select distinct(Cmp_Id) from company", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            foreach (DataRow dr in objdt.Rows)
            {
                cmbCompanyID.Items.Add(dr["Cmp_Id"].ToString());
            }

        }

        private void supplier1form_Load(object sender, EventArgs e)
        {

            string constr = @"data source=.; initial catalog=MedicalShopdb; integrated security=SSPI";
            objcon = new SqlConnection(constr);
            btnExit.Enabled = false;
            cmbSupplierID.Visible = false;
            groupBox1.Enabled = false;
        }

        private void cmbCompanyID_SelectedIndexChanged(object sender, EventArgs e)
        {
            objad = new SqlDataAdapter("select distinct(MedicineCode) from medicine where companyid='" + cmbCompanyID.Text + "'", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            foreach (DataRow dr in objdt.Rows)
            {
                cmbMedicineID.Items.Add(dr["MedicineCode"].ToString());
            }
        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            LstCompanyID.Items.Add(cmbCompanyID.Text);
            LstMedicineID.Items.Add(cmbMedicineID.Text);
        }

        private void LstCompanyID_SelectedIndexChanged(object sender, EventArgs e)
        {

            LstMedicineID.SelectedIndex = LstCompanyID.SelectedIndex;

        }
        int i;

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            i = LstCompanyID.SelectedIndex;
            LstCompanyID.Items.RemoveAt(i);
            LstMedicineID.Items.RemoveAt(i);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void cmbSupplierID_SelectedIndexChanged(object sender, EventArgs e)
        {
            objad = new SqlDataAdapter("select * from supplier where supplier_id='" + cmbSupplierID.Text + "'", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            txtName.Text = objdt.Rows[0]["Name"].ToString();
            txtAddress.Text = objdt.Rows[0]["Address"].ToString();
            txtPhoneNo.Text = objdt.Rows[0]["Phone_No"].ToString();
            objad = new SqlDataAdapter("select * from tmpsupplier where supplier_id='" + cmbSupplierID.Text + "'", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            foreach (DataRow dr in objdt.Rows)
            {
                LstCompanyID.Items.Add(dr["company_id"].ToString());
                LstMedicineID.Items.Add(dr["medicine_id"].ToString());
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnInsert.Enabled = false;
            btnsave.Enabled = true;
            Mode = "Update";
            btnsave.Text = "Update Now";
            txtSupplierID.Enabled = false;
            cmbSupplierID.Enabled = true;
            txtSupplierID.Visible = false;
            cmbSupplierID.Visible = true;
        }

        private void cmbSupplierID_Click(object sender, EventArgs e)
        {
            cmbSupplierID.Enabled = true;
            txtSupplierID.Enabled = false;
            objad = new SqlDataAdapter("select distinct(supplier_id) from supplier", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            cmbSupplierID.Items.Clear();
            foreach (DataRow dr in objdt.Rows)
            {
                cmbSupplierID.Items.Add(dr["supplier_id"].ToString());
            }
        }

        private void btnsave_Click_1(object sender, EventArgs e)
        {
            if (Mode == "Insert")
            {
                if (txtSupplierID.Text == "")
                {
                    MessageBox.Show("Please Enter Supplier ID..");
                    txtSupplierID.Focus();
                }
                else if (txtName.Text == "")
                {
                    MessageBox.Show("Please Enter Name..");
                    txtName.Focus();
                }

                else if (txtAddress.Text == "")
                {
                    MessageBox.Show("Please Enter Address..");
                    txtAddress.Focus();
                }
                else if (txtPhoneNo.Text == "")
                {
                    MessageBox.Show("Please Enter PhoneNo..");
                    txtPhoneNo.Focus();
                }
                else
                {

                    objad = new SqlDataAdapter("select * from supplier where supplier_ID='" + txtSupplierID.Text + "'", objcon);
                    objdt = new DataTable();
                    objad.Fill(objdt);
                    if (objdt.Rows.Count > 0)
                    {
                        MessageBox.Show("Duplicate Entry..");
                        txtSupplierID.Text = "";
                        txtSupplierID.Focus();
                    }
                }
                objcomm = new SqlCommand("insert into supplier(Supplier_Id, Name,Address,Phone_No) values('" + txtSupplierID.Text + "','" + txtName.Text + "','" + txtAddress.Text + "','" + txtPhoneNo.Text + "')", objcon);
                objcon.Open();
                objcomm.ExecuteNonQuery();

                for (i = 0; i < LstCompanyID.Items.Count; i++)
                {
                    objcomm = new SqlCommand("insert into tmpsupplier(Supplier_Id, company_id,medicine_id) values('" + txtSupplierID.Text + "','" + LstCompanyID.Items[i].ToString() + "','" + LstMedicineID.Items[i].ToString() + "')", objcon);

                    objcomm.ExecuteNonQuery();
                }
                
      
                objcon.Close();
                MessageBox.Show("One Record Inserted....");
               
            }
                
            else if (Mode == "Update")
            {
                objcomm = new SqlCommand("update supplier set phone_No='"+txtPhoneNo.Text+"', address='" + txtAddress.Text +"' where supplier_id='"+cmbSupplierID.Text +"'",objcon);
                objcon.Open(); 
               objcomm.ExecuteNonQuery();

                objcomm = new SqlCommand("delete tmpsupplier where supplier_id='"+cmbSupplierID.Text +"'", objcon);
                objcomm.ExecuteNonQuery();

                for (i = 0; i < LstCompanyID.Items.Count; i++)
                {
                    objcomm = new SqlCommand("insert into tmpsupplier(Supplier_Id, company_id,medicine_id) values('" + cmbSupplierID.Text + "','" + LstCompanyID.Items[i].ToString() + "','" + LstMedicineID.Items[i].ToString() + "')", objcon);

                    objcomm.ExecuteNonQuery();
                }
                objcon.Close();
            }
        }

        private void LstMedicineID_SelectedIndexChanged(object sender, EventArgs e)
        {
            LstCompanyID.SelectedIndex = LstMedicineID.SelectedIndex;
        }

    }
    


  
}

