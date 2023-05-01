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
    public partial class SaleForm : Form
    {



        public SaleForm()
        {
            InitializeComponent();
        }


        string Mode;
        SqlConnection objcon;
        SqlDataAdapter objad, objad1;
        DataTable objdt;
        SqlCommand objcomm;


        private void btnSave_Click(object sender, EventArgs e)
        {
            string temp;
            if (Mode == "Insert")
            {
              
                objcon.Open();
                if (rdbtnNew.Checked == true)
                {
                    objcomm = new SqlCommand("insert into customer(C_Id,Name,Address,PhoneNo,Email) values(" + txtCustomerID.Text + ",'" + txtName.Text + "','" + txtAddress.Text + "','" + txtPhoneNo.Text + "','" + txtEmail.Text + "')", objcon);
                    objcomm.ExecuteNonQuery();
                    temp = txtCustomerID.Text;
                }
                else
                {
                    temp = cmbCustomerID.Text;
                }

                objcomm = new SqlCommand("insert into Sale(VoucherNo,DOS,C_Id,Total_Amt,Discount,Final_Amt) values(" + txtVoucherNo.Text + ",'" + dateTimePicker1.Text + "','" + temp.ToString() + "','" + txtTotalAmount.Text + "','" + txtDiscount.Text + "','" + txtFinalAmount.Text + "')", objcon);
                objcomm.ExecuteNonQuery();

                for (j = 0; j < LstMedicineCode.Items.Count; j++)
                {
                    objcomm = new SqlCommand("insert into TmpSale(VoucherNo,MedicineCode,Quantity,Amount) values(" + txtVoucherNo.Text + ",'" + LstMedicineCode.Items[j].ToString() + "','" + LstQty.Items[j].ToString() + "','" + LstAmount.Items[j].ToString() + "')", objcon);
                    objcomm.ExecuteNonQuery();
                }
                int rem;
                for (int i = 0; i < LstMedicineCode.Items.Count; i++)
                {
                    objad1 = new SqlDataAdapter("select Quantity from stock where medicinecode='" + LstMedicineCode.Items[i].ToString() + "'", objcon);
                    objdt = new DataTable();
                    objad1.Fill(objdt);

                    rem = Convert.ToInt32(objdt.Rows[0]["Quantity"].ToString()) - Convert.ToInt32(LstQty.Items[i].ToString());
                    objcomm = new SqlCommand("update stock set quantity='" + rem.ToString() + "' where medicinecode='" + LstMedicineCode.Items[i].ToString() + "'", objcon);
                    objcomm.ExecuteNonQuery();
                }
                    objcon.Close();
                MessageBox.Show("one record inserted..");
                btnInsert.Enabled = false;
            }
            else if (Mode == "Update")
            {
                objcomm =new SqlCommand("update sale set total_amt='"+txtTotalAmount.Text+"',discount='"+txtDiscount.Text+"',final_amt='"+txtFinalAmount.Text+"' where VoucherNo='"+cmbVoucherNo.Text+"'",objcon);
                objcon.Open();
                objcomm.ExecuteNonQuery();
                objcomm = new SqlCommand("delete tmpsale where VoucherNo='" + cmbVoucherNo.Text + "'", objcon);
                objcomm.ExecuteNonQuery();

                for (j = 0; j <LstMedicineCode.Items.Count; j++)
                {
                    objcomm = new SqlCommand("insert into tmpsale(VoucherNo,MedicineCode,Quantity,Amount) values('" +cmbVoucherNo .Text + "','" + LstMedicineCode.Items[j].ToString() + "','" + LstQty.Items[j].ToString() + "','"+LstAmount.Items[j].ToString()+"')", objcon);

                    objcomm.ExecuteNonQuery();
                }
                int rem;
                for (int i = 0; i < LstMedicineCode.Items.Count; i++)
                {
                    objad1 = new SqlDataAdapter("select Quantity from stock where medicinecode='" + LstMedicineCode.Items[i].ToString() + "'", objcon);
                    objdt = new DataTable();
                    objad1.Fill(objdt);

                    rem = Convert.ToInt32(objdt.Rows[0]["Quantity"].ToString()) - Convert.ToInt32(LstQty.Items[i].ToString());
                    objcomm = new SqlCommand("update stock set quantity='" + rem.ToString() + "' where medicinecode='" + LstMedicineCode.Items[i].ToString() + "'", objcon);
                    objcomm.ExecuteNonQuery();
                }
                objcon.Close();
                MessageBox.Show("one record updated");
            }
           
        }
        

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (txtQty.Text == "")
            {
                txtQty.Text = "0";
            }
            txtAmount.Text = Convert.ToString(Convert.ToInt32(txtPrice.Text) * Convert.ToInt32(txtQty.Text));
        }

        

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            cmbVoucherNo.Enabled = false;
            cmbVoucherNo.Visible = false;
            groupBox2.Enabled = true;
            groupBox1.Enabled = true;
            groupBox3.Enabled = true;
            btnInsert.Enabled = false;
            btnSave.Enabled = true;
            Mode = "Insert";
            btnSave.Text = "Insert Now";
            txtVoucherNo.Text =Convert.ToString(  Convert.ToInt32( max) + 1);
            txtVoucherNo.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            txtCustomerID.Enabled = false;
            txtCustomerID.Visible = false;
            cmbVoucherNo.Enabled = true;
            cmbVoucherNo.Visible = true;
            cmbCustomerID.Enabled = true;
            cmbCustomerID.Visible = true;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled=true;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            Mode = "Update";
            btnSave.Text = "Update Now";
            rdbtnNew.Visible = false;
            rdbtnOld.Visible = false;
           
            
        }



        string max;

        private void SaleForm_Load(object sender, EventArgs e)
        {
            string constr = @"data source=.; initial catalog=MedicalShopdb; integrated security=SSPI";
            objcon=new SqlConnection(constr);
            btnSave.Enabled = false;
            groupBox2.Enabled = false;
            groupBox1.Enabled = false;
            groupBox3.Enabled = false;
            txtTotalAmount.Text = "0";
            txtDiscount.Text = "0";
            cmbCustomerID.Visible = false;
            txtAmount.Text = "0";
            
            objad = new SqlDataAdapter("select max(voucherno) from sale ", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            max = objdt.Rows[0][0].ToString();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void cmbMedicineCode_Click(object sender, EventArgs e)
        {
            objad = new SqlDataAdapter("select distinct(medicineCode) from medicine ", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            cmbMedicineCode.Items.Clear();
            foreach (DataRow dr in objdt.Rows)
            {

                cmbMedicineCode.Items.Add(dr["medicineCode"].ToString());
            }
        }

        private void cmbMedicineCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            objad = new SqlDataAdapter("select * from medicine where medicineCode='" + cmbMedicineCode.Text + "'", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
           
            txtPrice.Text = objdt.Rows[0]["price"].ToString();

        }

        private void rdbtnOld_CheckedChanged_1(object sender, EventArgs e)
        {
            txtCustomerID.Visible = false;
            cmbCustomerID.Enabled = true;
            cmbCustomerID.Visible = true;
            txtName.Enabled = false;
            txtAddress.Enabled = false;
            txtPhoneNo.Enabled = false;
            txtEmail.Enabled = false;
            objad = new SqlDataAdapter("select distinct(C_Id) from customer", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            cmbCustomerID.Items.Clear();
            foreach (DataRow dr in objdt.Rows)
            {

                cmbCustomerID.Items.Add(dr["C_Id"].ToString());
            }

        }

        private void rdbtnNew_CheckedChanged_1(object sender, EventArgs e)
        {
            txtCustomerID.Enabled = true;
            txtCustomerID.Visible = true;
            cmbCustomerID.Visible = false;

        }

        private void cmbCustomerID_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            objad = new SqlDataAdapter("select * from customer where C_Id='" + cmbCustomerID.Text + "'", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);

            txtName.Text = objdt.Rows[0]["name"].ToString();
            txtAddress.Text = objdt.Rows[0]["Address"].ToString();
            txtPhoneNo.Text = objdt.Rows[0]["PhoneNo"].ToString();
            txtEmail.Text = objdt.Rows[0]["email"].ToString();
           
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            LstMedicineCode.Items.Add(cmbMedicineCode.Text);
            LstPrice.Items.Add(txtPrice.Text);
            LstQty.Items.Add(txtQty.Text);
            LstAmount.Items.Add(txtAmount.Text);
            
            txtTotalAmount.Text = Convert.ToString( Convert.ToInt32(txtTotalAmount.Text)+Convert.ToInt32(txtAmount.Text)   );
            
        }
        int j;

        private void btnRemove_Click(object sender, EventArgs e)
        {
            

            int rem;
            
                objad1 = new SqlDataAdapter("select Quantity from stock where medicinecode='" + LstMedicineCode.Items[LstMedicineCode.SelectedIndex].ToString() + "'", objcon);
                objdt = new DataTable();
                objad1.Fill(objdt);

                rem = Convert.ToInt32(objdt.Rows[0]["Quantity"].ToString()) + Convert.ToInt32(LstQty.Items[LstQty.SelectedIndex].ToString());
                objcomm = new SqlCommand("update stock set quantity='" + rem.ToString() + "' where medicinecode='" + LstMedicineCode.Items[LstMedicineCode.SelectedIndex].ToString() + "'", objcon);
                objcon.Open();
                objcomm.ExecuteNonQuery();
                objcon.Close();

                j = LstMedicineCode.SelectedIndex;
                LstMedicineCode.Items.RemoveAt(j);
                LstPrice.Items.RemoveAt(j);
                LstQty.Items.RemoveAt(j);
                LstAmount.Items.RemoveAt(j);
                txtTotalAmount.Text = Convert.ToString(Convert.ToInt32(txtTotalAmount.Text) - Convert.ToInt32(txtAmount.Text));
            }
        

       

        private void cmbVoucherNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            objad = new SqlDataAdapter("select * from sale where voucherno='"+cmbVoucherNo.Text+"'", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            cmbCustomerID.Visible = false;
            txtCustomerID.Visible = true; 
            dateTimePicker1.Text = objdt.Rows[0]["dos"].ToString();
            txtCustomerID.Text = objdt.Rows[0]["C_Id"].ToString();
            txtTotalAmount.Text = objdt.Rows[0]["Total_Amt"].ToString();
            txtDiscount.Text = objdt.Rows[0]["discount"].ToString();
            txtFinalAmount.Text = objdt.Rows[0]["final_amt"].ToString();
            objad = new SqlDataAdapter("select  * from customer where C_Id='" + txtCustomerID.Text + "'", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            txtName.Text = objdt.Rows[0]["name"].ToString();
            txtAddress.Text = objdt.Rows[0]["address"].ToString();
            txtPhoneNo.Text = objdt.Rows[0]["PhoneNo"].ToString();
            txtEmail.Text = objdt.Rows[0]["email"].ToString();
            objad = new SqlDataAdapter("select  * from tmpsale where voucherno='" + cmbVoucherNo.Text + "'", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            foreach(DataRow dr in objdt.Rows)

            {
                LstMedicineCode.Items.Add(dr["medicinecode"].ToString());
                objad = new SqlDataAdapter("select price from medicine where medicineCode='"+ dr["medicinecode"].ToString()+"'", objcon);
                objdt = new DataTable();
                objad.Fill(objdt);
                foreach (DataRow drr in objdt.Rows)
                {
                    LstPrice.Items.Add(drr["price"].ToString());
                }
                
                LstQty.Items.Add(dr["quantity"].ToString());
                LstAmount.Items.Add(dr["amount"].ToString());
                LstMedicineCode.Items.Clear();
                LstPrice.Items.Clear();
                LstAmount.Items.Clear();
                LstQty.Items.Clear();
            }



        }

        private void cmbVoucherNo_Click(object sender, EventArgs e)
        {
            
            objad = new SqlDataAdapter("select distinct(VoucherNo) from sale", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            foreach (DataRow dr in objdt.Rows)
            {
                cmbVoucherNo.Items.Add(dr["VoucherNo"].ToString());
            }
        }

       

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscount.Text == "")
            {
                txtDiscount.Text = "0";
            }
            txtFinalAmount.Text = Convert.ToString(Convert.ToInt32(txtTotalAmount.Text) - ((Convert.ToInt32(txtTotalAmount.Text) * Convert.ToInt32(txtDiscount.Text)) / 100));
        }

        private void LstMedicineCode_SelectedIndexChanged(object sender, EventArgs e)
        {
             LstPrice.SelectedIndex=LstMedicineCode.SelectedIndex ;
             LstQty.SelectedIndex = LstMedicineCode.SelectedIndex;
             LstAmount.SelectedIndex = LstMedicineCode.SelectedIndex;


        }

        private void LstPrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            LstMedicineCode.SelectedIndex = LstPrice.SelectedIndex;
            LstQty.SelectedIndex = LstPrice.SelectedIndex;
            LstAmount.SelectedIndex = LstPrice.SelectedIndex;
        }

        private void LstQty_SelectedIndexChanged(object sender, EventArgs e)
        {
            LstPrice.SelectedIndex = LstQty.SelectedIndex;
            LstMedicineCode.SelectedIndex = LstQty.SelectedIndex;
            LstAmount.SelectedIndex = LstQty.SelectedIndex;
        }

        private void LstAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
            LstPrice.SelectedIndex = LstAmount.SelectedIndex;
            LstMedicineCode.SelectedIndex = LstAmount.SelectedIndex;
            LstQty.SelectedIndex = LstAmount.SelectedIndex;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


    }
       

      
    }

