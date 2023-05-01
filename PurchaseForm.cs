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
    public partial class PurchaseForm : Form
    {
        public PurchaseForm()
        {
            InitializeComponent();
        }
        SqlConnection objcon;
        SqlDataAdapter objad, objad1;
        DataTable objdt;
        string Mode;
        SqlCommand objcomm;


        string max;
        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            string constr = @"data source=.; initial catalog=MedicalShopdb; integrated security=SSPI";
            objcon = new SqlConnection(constr);
            btnSave.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox4.Enabled = false;
            txtTotalAmount.Text = "0";
            cmbSupplierID.Visible = false;
            txtAmount.Text = "0";
          
            objad = new SqlDataAdapter("select max(voucherno) from purchase", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            max = objdt.Rows[0][0].ToString();
           

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            cmbVoucherNo.Enabled = false;
            cmbVoucherNo.Visible = false;
            groupBox2.Enabled = true;
            groupBox1.Enabled = true;
            groupBox4.Enabled = true;
            btnInsert.Enabled = false;
            btnSave.Enabled = true;
            Mode = "Insert";
            btnSave.Text = "Insert Now";
            txtVoucherNo.Text = Convert.ToString(Convert.ToInt32(max) + 1);
            txtVoucherNo.Enabled = false;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtSupplierID.Enabled = false;
            txtSupplierID.Visible = false;
            cmbVoucherNo.Enabled = true;
            cmbVoucherNo.Visible = true;
            cmbSupplierID.Enabled = true;
            cmbSupplierID.Visible = true;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox4.Enabled = true;
            btnUpdate.Enabled = false;
            btnSave.Enabled = true;
            Mode = "Update";
            btnSave.Text = "Update Now";
            rdbtnNew.Visible = false;
            rdbtnOld.Visible = false;
            txtTotalAmount.Text = "0";
        }

        private void rdbtnNew_CheckedChanged(object sender, EventArgs e)
        {
            txtSupplierID.Text = "";
            txtSupplierID.Enabled = true;
            txtSupplierID.Visible = true;
            cmbSupplierID.Visible = false;
            txtName.Enabled = true;
            txtAddress.Enabled = true;
            txtPhoneNo.Enabled = true;

        }

        private void rdbtnOld_CheckedChanged(object sender, EventArgs e)
        {
            txtSupplierID.Visible = false;
            cmbSupplierID.Enabled = true;
            cmbSupplierID.Visible = true;
            txtName.Enabled = false;
            txtAddress.Enabled = false;
            txtPhoneNo.Enabled = false;
            objad = new SqlDataAdapter("select distinct(Supplier_Id) from Supplier", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            cmbSupplierID.Items.Clear();
            foreach (DataRow dr in objdt.Rows)
            {

                cmbSupplierID.Items.Add(dr["Supplier_Id"].ToString());
            }
        }

        private void cmbSupplierID_SelectedIndexChanged(object sender, EventArgs e)
        {
            objad = new SqlDataAdapter("select * from supplier where supplier_Id='" + cmbSupplierID.Text + "'", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);

            txtName.Text = objdt.Rows[0]["Name"].ToString();
            txtAddress.Text = objdt.Rows[0]["Address"].ToString();
            txtPhoneNo.Text = objdt.Rows[0]["Phone_No"].ToString();
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

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (txtQty.Text == "")
            {
                txtQty.Text = "0";
            }
             txtAmount.Text = Convert.ToString(Convert.ToInt32(txtPrice.Text) * Convert.ToInt32(txtQty.Text));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            LstMedicineCode.Items.Add(cmbMedicineCode.Text);
            LstPrice.Items.Add(txtPrice.Text);
            LstQty.Items.Add(txtQty.Text);
            LstAmount.Items.Add(txtAmount.Text);
            txtTotalAmount.Text = Convert.ToString(Convert.ToInt32(txtTotalAmount.Text) + Convert.ToInt32(txtAmount.Text));
            txtAmount.Text = "0";
            txtQty.Text = "0";
            txtPrice.Text = "0";
        }
        int a;
        private void btnRemove_Click(object sender, EventArgs e)
        {
            int rem;

            objad1 = new SqlDataAdapter("select Quantity from stock where medicinecode='" + LstMedicineCode.Items[LstMedicineCode.SelectedIndex].ToString() + "'", objcon);
            objdt = new DataTable();
            objad1.Fill(objdt);

            rem = Convert.ToInt32(objdt.Rows[0]["Quantity"].ToString()) - Convert.ToInt32(LstQty.Items[LstQty.SelectedIndex].ToString());
            objcomm = new SqlCommand("update stock set quantity='" + rem.ToString() + "' where medicinecode='" + LstMedicineCode.Items[LstMedicineCode.SelectedIndex].ToString() + "'", objcon);
            objcon.Open();
            objcomm.ExecuteNonQuery();
            objcon.Close();

            a = LstMedicineCode.SelectedIndex;
            LstMedicineCode.Items.RemoveAt(a);
            LstPrice.Items.RemoveAt(a);
            LstQty.Items.RemoveAt(a);
            LstAmount.Items.RemoveAt(a);
            txtTotalAmount.Text = Convert.ToString(Convert.ToInt32(txtTotalAmount.Text) - Convert.ToInt32(txtAmount.Text));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmbVoucherNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            objad = new SqlDataAdapter("select * from purchase", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            cmbSupplierID.Visible = false;
            txtSupplierID.Visible = true;
            dateTimePicker1.Text = objdt.Rows[0]["DOS"].ToString();
            txtSupplierID.Text = objdt.Rows[0]["supplier_id"].ToString();
            txtTotalAmount.Text = objdt.Rows[0]["total_amt"].ToString();
            txtDiscount.Text = objdt.Rows[0]["discount"].ToString();
            txtFinalAmount.Text = objdt.Rows[0]["final_amt"].ToString();
            objad = new SqlDataAdapter("select  * from supplier where supplier_id='" + txtSupplierID.Text + "'", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            txtName.Text = objdt.Rows[0]["name"].ToString();
            txtAddress.Text = objdt.Rows[0]["address"].ToString();
            txtPhoneNo.Text = objdt.Rows[0]["Phone_No"].ToString();
            objad = new SqlDataAdapter("select  * from tmppurchase where voucherno='" + cmbVoucherNo.Text + "'", objcon);
            objdt = new DataTable();
           
            objad.Fill(objdt);
            foreach (DataRow dr in objdt.Rows)
            {
                LstMedicineCode.Items.Add(dr["medicinecode"].ToString());
                objad = new SqlDataAdapter("select price from medicine where medicineCode='" + dr["medicinecode"].ToString() + "'", objcon);
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
                LstQty.Items.Clear();
                LstAmount.Items.Clear();

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

        private void cmbVoucherNo_Click(object sender, EventArgs e)
        {
            objad = new SqlDataAdapter("select distinct(voucherno) from purchase", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            foreach (DataRow dr in objdt.Rows)
            {
                cmbVoucherNo.Items.Add(dr["VoucherNo"].ToString());
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string temp;
            if (Mode == "Insert")
            {
                objcon.Open();
                if (rdbtnNew.Checked == true)
                {
                    objcomm = new SqlCommand("insert into supplier(supplier_id,name,address,phone_no) values(" + txtSupplierID.Text + ",'" + txtName.Text + "','" + txtAddress.Text + "','" + txtPhoneNo.Text + "')", objcon);
                    objcomm.ExecuteNonQuery();
                    temp = txtSupplierID.Text;
                }
                else
                {
                    temp = cmbSupplierID.Text;
                }


                objcomm = new SqlCommand("insert into purchase(VoucherNo,DOS,Supplier_Id,Total_amt,discount,final_amt) values(" + txtVoucherNo.Text + ",'" + dateTimePicker1.Text + "','" + cmbSupplierID.Text + "','" + txtTotalAmount.Text + "','" + txtDiscount.Text + "','" + txtFinalAmount.Text + "')", objcon);
                objcomm.ExecuteNonQuery();
                for (a = 0; a < LstMedicineCode.Items.Count; a++)
                {
                    objcomm = new SqlCommand("insert into tmppurchase(VoucherNo,MedicineCode,Quantity,Amount) values(" + txtVoucherNo.Text + ",'" + LstMedicineCode.Items[a].ToString() + "','" + LstQty.Items[a].ToString() + "','" + LstAmount.Items[a].ToString() + "')", objcon);
                    objcomm.ExecuteNonQuery();
                }
                int rem;
                for(int i=0;i<LstMedicineCode.Items.Count;i++)
                {
                    objad1=new SqlDataAdapter("select quantity from stock where medicinecode='"+LstMedicineCode.Items[i].ToString()+"'",objcon);
                    objdt=new DataTable();
                    objad1.Fill(objdt);
                    rem=Convert.ToInt32(objdt.Rows[0]["Quantity"].ToString())+Convert.ToInt32(LstQty.Items[i].ToString());
                    objcomm=new SqlCommand("update stock set quantity='"+rem.ToString()+"' where medicinecode='"+LstMedicineCode.Items[i].ToString()+"'",objcon);
                    objcomm.ExecuteNonQuery();
                }
                objcon.Close();
                MessageBox.Show("one record inserted..");
                btnInsert.Enabled = false;
            }
               else if( Mode=="Update")
            {
                objcomm = new SqlCommand("update purchase set total_amt='" + txtTotalAmount.Text + "',discount='" + txtDiscount.Text + "',final_amt='" + txtFinalAmount.Text + "'", objcon);
                objcon.Open();
                objcomm.ExecuteNonQuery();
                objcomm = new SqlCommand("delete tmppurchase where voucherno='" + cmbVoucherNo.Text + "'", objcon);
                objcomm.ExecuteNonQuery();

                for (a = 0; a < LstMedicineCode.Items.Count; a++)
                {
                    objcomm = new SqlCommand("insert into tmppurchase(VoucherNo,MedicineCode,Quantity,Amount) values('" + cmbVoucherNo.Text + "','" + LstMedicineCode.Items[a].ToString() + "','" + LstQty.Items[a].ToString() + "','" + LstAmount.Items[a].ToString() + "')", objcon);
                    objcomm.ExecuteNonQuery();
                }
                   int rem;
                for (int i = 0; i < LstMedicineCode.Items.Count; i++)
                {
                    objad1 = new SqlDataAdapter("select Quantity from stock where medicinecode='" + LstMedicineCode.Items[i].ToString() + "'", objcon);
                    objdt = new DataTable();
                    objad1.Fill(objdt);

                    rem = Convert.ToInt32(objdt.Rows[0]["Quantity"].ToString()) + Convert.ToInt32(LstQty.Items[i].ToString());
                    objcomm = new SqlCommand("update stock1 set quantity='" + rem.ToString() + "' where medicinecode='" + LstMedicineCode.Items[i].ToString() + "'", objcon);
                    objcomm.ExecuteNonQuery();
                }
                       objcon.Close();
                       MessageBox.Show("one record updated..");
                       btnUpdate.Enabled = false;
           }
        }

        private void LstMedicineCode_SelectedIndexChanged(object sender, EventArgs e)
        {

            LstPrice.SelectedIndex = LstMedicineCode.SelectedIndex;
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
    }
}
 
    
  
        

    
