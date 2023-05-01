﻿using System;
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
    public partial class PurchasevoucherForm : Form
    {
        public PurchasevoucherForm()
        {
            InitializeComponent();
        }
        SqlConnection objcon;
        SqlDataAdapter objad;
        DataTable objdt;

        private void PurchasevoucherForm_Load(object sender, EventArgs e)
        {
            string constr = @"data source=.; initial catalog=MedicalShopdb; integrated security=SSPI";
            objcon = new SqlConnection(constr);
            objad = new SqlDataAdapter("select * from purchase", objcon);
            objdt = new DataTable();
            objad.Fill(objdt);
            cmbvoucherno.Enabled = false;
        }

        private void rdbtnViewAll_CheckedChanged(object sender, EventArgs e)
        {
            cmbvoucherno.Visible = false;
            //cmbvoucherno.Items.Clear();
        }

        private void rdbtnvoucherno_CheckedChanged(object sender, EventArgs e)
        {
            cmbvoucherno.Visible = true;
            foreach(DataRow dr in objdt.Rows)
            {
                cmbvoucherno.Items.Add(dr["voucherno"].ToString());
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (rdbtnvoucherno.Checked == true)
            {
                objad = new SqlDataAdapter("select * from purchase where voucherno='" + cmbvoucherno.Text + "'", objcon);
                objdt = new DataTable();
                objad.Fill(objdt);
                dataGridView1.DataSource = objdt;
            }
            else
            {
                objad = new SqlDataAdapter("select * from purchase", objcon);
                objdt = new DataTable();
                objad.Fill(objdt);
                dataGridView1.DataSource = objdt;
            }
            cmbvoucherno.Focus();


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     
    }
}
