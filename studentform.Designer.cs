namespace MedicalShopManagement
{
    partial class studentform
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.entries = new System.Windows.Forms.GroupBox();
            this.action = new System.Windows.Forms.GroupBox();
            this.StudentID = new System.Windows.Forms.Label();
            this.PhoneNo = new System.Windows.Forms.Label();
            this.Address = new System.Windows.Forms.Label();
   //         this.Name = new System.Windows.Forms.Label();
            this.EmailID = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.txtEmailID = new System.Windows.Forms.TextBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.entries.SuspendLayout();
            this.action.SuspendLayout();
            this.SuspendLayout();
            // 
            // entries
            // 
            this.entries.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.entries.Controls.Add(this.txtEmailID);
            this.entries.Controls.Add(this.txtPhoneNo);
            this.entries.Controls.Add(this.txtName);
            this.entries.Controls.Add(this.txtAddress);
            this.entries.Controls.Add(this.txtStudentID);
            this.entries.Controls.Add(this.EmailID);
        //    this.entries.Controls.Add(this.Name);
            this.entries.Controls.Add(this.Address);
            this.entries.Controls.Add(this.PhoneNo);
            this.entries.Controls.Add(this.StudentID);
            this.entries.Location = new System.Drawing.Point(17, 15);
            this.entries.Name = "entries";
            this.entries.Size = new System.Drawing.Size(494, 221);
            this.entries.TabIndex = 0;
            this.entries.TabStop = false;
            this.entries.Text = "Entries";
            // 
            // action
            // 
            this.action.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.action.Controls.Add(this.btnExit);
            this.action.Controls.Add(this.btnRefresh);
            this.action.Controls.Add(this.btnInsert);
            this.action.Location = new System.Drawing.Point(17, 242);
            this.action.Name = "action";
            this.action.Size = new System.Drawing.Size(494, 92);
            this.action.TabIndex = 1;
            this.action.TabStop = false;
            this.action.Text = "action";
            // 
            // StudentID
            // 
            this.StudentID.AutoSize = true;
            this.StudentID.Location = new System.Drawing.Point(40, 43);
            this.StudentID.Name = "StudentID";
            this.StudentID.Size = new System.Drawing.Size(87, 20);
            this.StudentID.TabIndex = 0;
            this.StudentID.Text = "Student ID";
            // 
            // PhoneNo
            // 
            this.PhoneNo.AutoSize = true;
            this.PhoneNo.Location = new System.Drawing.Point(40, 142);
            this.PhoneNo.Name = "PhoneNo";
            this.PhoneNo.Size = new System.Drawing.Size(83, 20);
            this.PhoneNo.TabIndex = 1;
            this.PhoneNo.Text = "Phone No.";
            // 
            // Address
            // 
            this.Address.AutoSize = true;
            this.Address.Location = new System.Drawing.Point(40, 111);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(68, 20);
            this.Address.TabIndex = 2;
            this.Address.Text = "Address";
            this.Address.Click += new System.EventHandler(this.label3_Click);
            // 
            // Name
            // 
       //     this.Name.AutoSize = true;
      //      this.Name.Location = new System.Drawing.Point(40, 76);
    //        this.Name.Name = "Name";
        //    this.Name.Size = new System.Drawing.Size(51, 20);
     //       this.Name.TabIndex = 3;
      //      this.Name.Text = "Name";
            // 
            // EmailID
            // 
            this.EmailID.AutoSize = true;
            this.EmailID.Location = new System.Drawing.Point(40, 174);
            this.EmailID.Name = "EmailID";
            this.EmailID.Size = new System.Drawing.Size(69, 20);
            this.EmailID.TabIndex = 4;
            this.EmailID.Text = "Email ID";
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(188, 37);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(194, 26);
            this.txtStudentID.TabIndex = 5;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(188, 104);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(194, 26);
            this.txtAddress.TabIndex = 6;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(188, 70);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(194, 26);
            this.txtName.TabIndex = 7;
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Location = new System.Drawing.Point(188, 136);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(194, 26);
            this.txtPhoneNo.TabIndex = 8;
            // 
            // txtEmailID
            // 
            this.txtEmailID.Location = new System.Drawing.Point(188, 168);
            this.txtEmailID.Name = "txtEmailID";
            this.txtEmailID.Size = new System.Drawing.Size(194, 26);
            this.txtEmailID.TabIndex = 9;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(16, 35);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 33);
            this.btnInsert.TabIndex = 0;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(199, 35);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 33);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(366, 35);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 33);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // studentform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 350);
            this.Controls.Add(this.action);
            this.Controls.Add(this.entries);
            //this.Name = "studentform";
            this.Text = "studentform";
            this.entries.ResumeLayout(false);
            this.entries.PerformLayout();
            this.action.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox entries;
    //    private System.Windows.Forms.Label Name;
        private System.Windows.Forms.Label Address;
        private System.Windows.Forms.Label PhoneNo;
        private System.Windows.Forms.Label StudentID;
        private System.Windows.Forms.GroupBox action;
        private System.Windows.Forms.TextBox txtEmailID;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label EmailID;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnInsert;
    }
}