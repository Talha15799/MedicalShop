using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MedicalShopManagement
{
    public partial class medicineform : Form
    {
        public medicineform()
        {
            InitializeComponent();
        }

        SqlConnection objcon;
        SqlDataAdapter objad;
        DataTable objdt;
        string Mode;
        private void medicineform_Load(object sender, EventArgs e)
        {
            string constr = @"data source=.; initial catalog=MedicalShopdb; integrated security=SSPI";
            objcon = new SqlConnection(constr);
            btnSave.Enabled = false;
            groupBox1.Enabled = false;
            cmbcompanyid.Visible = false;
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
            txtCompanyID.Visible = false;
            cmbcompanyid.Visible = true;
            combofill();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Mode == "Insert")
            {
                if (txtCompanyID.Text == "")
                {
                    MessageBox.Show("Please Enter Company ID..");
                    txtCompanyID.Focus();
                }
                     else if (txtBatchNo.Text == "")
                {
                    MessageBox.Show("Please Enter BatchNo..");
                    txtBatchNo.Focus();
                }

                else if (txtMedicineCode.Text == "")
                {
                    MessageBox.Show("Please Enter MedicineCode..");
                    txtMedicineCode.Focus();
                }
                else if (txtName.Text == "")
                {
                    MessageBox.Show("Please Enter Name..");
                    txtName.Focus();
                }
                else if (dateTimePicker1.Text == "")
                {
                    MessageBox.Show("Please Enter DOM ..");
                    dateTimePicker1.Focus();
                }
                else if (dateTimePicker2.Text == "")
                {
                    MessageBox.Show("Please Enter DOE..");
                    dateTimePicker2.Focus();
                }

                else if (txtPrice.Text == "")
                {
                    MessageBox.Show("Please Enter price..");
                    txtPrice.Focus();
                }
                     else if (txtCapacity.Text == "")
                {
                    MessageBox.Show("Please Enter Capacity..");
                    txtCapacity.Focus();
                }
                else if (txtComposition.Text == "")
                {
                    MessageBox.Show("Please Enter Composition..");
                    txtComposition.Focus();
                }

                else
                {

                    objad = new SqlDataAdapter("select * from medicine where companyID='" + txtCompanyID.Text + "'", objcon);
                    objdt = new DataTable();
                    objad.Fill(objdt);
                    if (objdt.Rows.Count > 0)
                    {
                        MessageBox.Show("Duplicate Entry..");
                        txtCompanyID.Text = "";
                        txtCompanyID.Focus();
                    }
                }

                SqlCommand objcomm = new SqlCommand("insert into medicine(companyID,BatchNo,MedicineCode,Name,DOM,DOE,Price,Capacity,Composition) values(" + txtCompanyID.Text + ",'" + txtBatchNo.Text + "','" + txtMedicineCode.Text + "','" + txtName.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + txtPrice.Text + "','" + txtCapacity.Text + "','" + txtComposition.Text + "' )", objcon);
                objcon.Open();
                objcomm.ExecuteNonQuery();
                objcon.Close();
                MessageBox.Show("one record inserted..");
                btnInsert.Enabled = false;
            }
            else
            {
                if (Mode == "Update")
                {
                    SqlCommand objcomm = new SqlCommand("update medicine set Price='" + txtPrice.Text + "',Capacity='" + txtCapacity.Text + "' where companyID='" + cmbcompanyid.Text + "'", objcon);
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
                        SqlCommand objcomm = new SqlCommand("delete medicine where companyID=" + cmbcompanyid.Text + "", objcon);
                        objcon.Open();
                        objcomm.ExecuteNonQuery();
                        objcon.Close();
                        MessageBox.Show("one record Deleted..");
                        btnDelete.Enabled = false;
                    }
                }

            }
            txtBatchNo.Text = "";
            txtCapacity.Text = "";
            txtComposition.Text = "";
            txtName.Text = "";
            txtPrice.Text = "";
            txtCompanyID.Text = "";
            cmbcompanyid.Items.Clear();
            Mode = "";
            btnSave.Text = "Save";
        }

      

        private void cmbcompanyid_SelectedIndexChanged(object sender, EventArgs e)
        {
            objad = new SqlDataAdapter("select * from medicine where companyID='" +cmbcompanyid.Text+"'", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);

            txtBatchNo.Text = objdt.Rows[0]["BatchNo"].ToString();
            txtMedicineCode.Text = objdt.Rows[0]["MedicineCode"].ToString();
            txtName.Text = objdt.Rows[0]["Name"].ToString();
            dateTimePicker1.Text = objdt.Rows[0]["DOM"].ToString();
            dateTimePicker2.Text = objdt.Rows[0]["DOE"].ToString();
            txtPrice.Text = objdt.Rows[0]["Price"].ToString();
            txtCapacity.Text = objdt.Rows[0]["Capacity"].ToString();
            txtComposition.Text = objdt.Rows[0]["Composition"].ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            Mode = "Delete";
            btnSave.Text = "Delete Now";
            txtCompanyID.Visible = false;
            cmbcompanyid.Visible = true;
            combofill();
        }
        private void combofill()
        {
            objad = new SqlDataAdapter("select distinct(companyID) from medicine", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            cmbcompanyid.Items.Clear();
            foreach (DataRow dr in objdt.Rows)
            {
                cmbcompanyid.Items.Add(dr["companyID"].ToString());
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

      
        }
    }


       