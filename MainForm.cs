using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace MedicalShopManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void employeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employeeform objemp = new Employeeform();
            objemp.Show();
        }

        private void medicineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            medicineform objmed = new medicineform();
            objmed.Show();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            supplier1form objsup = new supplier1form();
            objsup.Show();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyForm objcmp = new CompanyForm();
            objcmp.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customerform objcust = new customerform();
            objcust.Show();
        }

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaleForm objsal = new SaleForm();
            objsal.Show();
        }

        private void purchseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchaseForm objpur = new PurchaseForm();
            objpur.Show();
        }

        private void salaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalaryForm objsaly = new SalaryForm();
            objsaly.Show();
        }

        private void medicineToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MedicineidForm objmedid = new MedicineidForm();
            objmedid.Show();
        }

        private void spplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SupplieridForm objsupid = new SupplieridForm();
            objsupid.Show();
        }

        private void comapnyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyidForm objcmpid = new CompanyidForm();
            objcmpid.Show();
        }

        private void customerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CustomeridForm objcustid = new CustomeridForm();
            objcustid.Show();
        }

        private void salaryToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SalaryidForm objsalyid = new SalaryidForm();
            objsalyid.Show();
        }

        private void salaryToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            salarydwform objsalydw = new salarydwform();
            objsalydw.Show();
        }

        private void saleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaledwForm objsaldw = new SaledwForm();
            objsaldw.Show();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PurchasedwForm objpurdw = new PurchasedwForm();
            objpurdw.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StockForm objstk = new StockForm();
            objstk.Show();
        }

        private void saleToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SalevoucherForm objsalv = new SalevoucherForm();
            objsalv.Show();
        }

        private void purchaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PurchasevoucherForm objpurv = new PurchasevoucherForm();
            objpurv.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changepasswordform objcp = new changepasswordform();
            objcp.Show();
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            create_userform objcreate = new create_userform();
            objcreate.Show();
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process process1 = new Process();
            process1.StartInfo.FileName = @"calc.exe";
            process1.Start();


        }

        private void calenderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }
}
