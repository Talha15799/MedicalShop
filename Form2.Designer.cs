namespace MedicalShopManagement
{
    partial class Form2
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Btnexit = new System.Windows.Forms.Button();
            this.Btnupdate = new System.Windows.Forms.Button();
            this.Btninsert = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Txtemail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Txtphone = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Txtaddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Txtname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txtemployeeid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Btndelete = new System.Windows.Forms.Button();
            this.Btnsave = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox2.Controls.Add(this.Btnsave);
            this.groupBox2.Controls.Add(this.Btndelete);
            this.groupBox2.Controls.Add(this.Btnexit);
            this.groupBox2.Controls.Add(this.Btnupdate);
            this.groupBox2.Controls.Add(this.Btninsert);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 326);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(748, 101);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Actions";
            // 
            // Btnexit
            // 
            this.Btnexit.Location = new System.Drawing.Point(620, 40);
            this.Btnexit.Name = "Btnexit";
            this.Btnexit.Size = new System.Drawing.Size(99, 33);
            this.Btnexit.TabIndex = 2;
            this.Btnexit.Text = "Exit";
            this.Btnexit.UseVisualStyleBackColor = true;
            // 
            // Btnupdate
            // 
            this.Btnupdate.Location = new System.Drawing.Point(148, 40);
            this.Btnupdate.Name = "Btnupdate";
            this.Btnupdate.Size = new System.Drawing.Size(99, 33);
            this.Btnupdate.TabIndex = 1;
            this.Btnupdate.Text = "Update";
            this.Btnupdate.UseVisualStyleBackColor = true;
            this.Btnupdate.Click += new System.EventHandler(this.Btnupdate_Click);
            // 
            // Btninsert
            // 
            this.Btninsert.Location = new System.Drawing.Point(25, 40);
            this.Btninsert.Name = "Btninsert";
            this.Btninsert.Size = new System.Drawing.Size(99, 33);
            this.Btninsert.TabIndex = 0;
            this.Btninsert.Text = "Insert";
            this.Btninsert.UseVisualStyleBackColor = true;
            this.Btninsert.Click += new System.EventHandler(this.Btninsert_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupBox1.Controls.Add(this.Txtemail);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.Txtphone);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Txtaddress);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.Txtname);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Txtemployeeid);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 308);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entries";
            // 
            // Txtemail
            // 
            this.Txtemail.Location = new System.Drawing.Point(226, 236);
            this.Txtemail.Name = "Txtemail";
            this.Txtemail.Size = new System.Drawing.Size(174, 28);
            this.Txtemail.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 22);
            this.label5.TabIndex = 8;
            this.label5.Text = "Email";
            // 
            // Txtphone
            // 
            this.Txtphone.Location = new System.Drawing.Point(226, 185);
            this.Txtphone.Name = "Txtphone";
            this.Txtphone.Size = new System.Drawing.Size(174, 28);
            this.Txtphone.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Phone";
            // 
            // Txtaddress
            // 
            this.Txtaddress.Location = new System.Drawing.Point(226, 139);
            this.Txtaddress.Name = "Txtaddress";
            this.Txtaddress.Size = new System.Drawing.Size(174, 28);
            this.Txtaddress.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 22);
            this.label3.TabIndex = 4;
            this.label3.Text = "Address";
            // 
            // Txtname
            // 
            this.Txtname.Location = new System.Drawing.Point(226, 92);
            this.Txtname.Name = "Txtname";
            this.Txtname.Size = new System.Drawing.Size(174, 28);
            this.Txtname.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // Txtemployeeid
            // 
            this.Txtemployeeid.Location = new System.Drawing.Point(226, 46);
            this.Txtemployeeid.Name = "Txtemployeeid";
            this.Txtemployeeid.Size = new System.Drawing.Size(174, 28);
            this.Txtemployeeid.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Employee ID";
            // 
            // Btndelete
            // 
            this.Btndelete.Location = new System.Drawing.Point(264, 40);
            this.Btndelete.Name = "Btndelete";
            this.Btndelete.Size = new System.Drawing.Size(99, 33);
            this.Btndelete.TabIndex = 3;
            this.Btndelete.Text = "Delete";
            this.Btndelete.UseVisualStyleBackColor = true;
            // 
            // Btnsave
            // 
            this.Btnsave.Location = new System.Drawing.Point(383, 40);
            this.Btnsave.Name = "Btnsave";
            this.Btnsave.Size = new System.Drawing.Size(183, 33);
            this.Btnsave.TabIndex = 4;
            this.Btnsave.Text = "Save";
            this.Btnsave.UseVisualStyleBackColor = true;
            this.Btnsave.Click += new System.EventHandler(this.Btnsave_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(226, 46);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(174, 30);
            this.comboBox1.TabIndex = 10;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 435);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Btnsave;
        private System.Windows.Forms.Button Btndelete;
        private System.Windows.Forms.Button Btnexit;
        private System.Windows.Forms.Button Btnupdate;
        private System.Windows.Forms.Button Btninsert;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Txtemail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Txtphone;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txtaddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txtname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txtemployeeid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}