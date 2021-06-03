namespace AnantMatrimony.FORMS
{
    partial class rfrmExpiredMembership
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbtnFemale = new System.Windows.Forms.RadioButton();
            this.rbtnMale = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LvwCaste = new System.Windows.Forms.ListView();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label106 = new System.Windows.Forms.Label();
            this.ddlPAgeTo = new System.Windows.Forms.ComboBox();
            this.label105 = new System.Windows.Forms.Label();
            this.ddlPAgeFrom = new System.Windows.Forms.ComboBox();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbtnFemale);
            this.groupBox4.Controls.Add(this.rbtnMale);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox4.Location = new System.Drawing.Point(239, 178);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(192, 68);
            this.groupBox4.TabIndex = 328;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gender";
            // 
            // rbtnFemale
            // 
            this.rbtnFemale.AutoSize = true;
            this.rbtnFemale.Location = new System.Drawing.Point(85, 32);
            this.rbtnFemale.Name = "rbtnFemale";
            this.rbtnFemale.Size = new System.Drawing.Size(73, 18);
            this.rbtnFemale.TabIndex = 305;
            this.rbtnFemale.Text = "Female";
            this.rbtnFemale.UseVisualStyleBackColor = true;
            // 
            // rbtnMale
            // 
            this.rbtnMale.AutoSize = true;
            this.rbtnMale.Checked = true;
            this.rbtnMale.Location = new System.Drawing.Point(9, 32);
            this.rbtnMale.Name = "rbtnMale";
            this.rbtnMale.Size = new System.Drawing.Size(56, 18);
            this.rbtnMale.TabIndex = 304;
            this.rbtnMale.TabStop = true;
            this.rbtnMale.Text = "Male";
            this.rbtnMale.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.SystemColors.Info;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSubmit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSubmit.Location = new System.Drawing.Point(523, 300);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 32);
            this.btnSubmit.TabIndex = 326;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox1.Location = new System.Drawing.Point(239, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 68);
            this.groupBox1.TabIndex = 325;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(234, 28);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(137, 22);
            this.dtpToDate.TabIndex = 317;
            this.dtpToDate.Tag = "DateofBirth";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 309;
            this.label1.Text = "From :";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(62, 28);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(136, 22);
            this.dtpFromDate.TabIndex = 316;
            this.dtpFromDate.Tag = "DateofBirth";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(205, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 310;
            this.label3.Text = "To";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LvwCaste);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(207, 320);
            this.groupBox2.TabIndex = 324;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Caste";
            // 
            // LvwCaste
            // 
            this.LvwCaste.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LvwCaste.CheckBoxes = true;
            this.LvwCaste.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvwCaste.GridLines = true;
            this.LvwCaste.Location = new System.Drawing.Point(3, 18);
            this.LvwCaste.Name = "LvwCaste";
            this.LvwCaste.Size = new System.Drawing.Size(201, 299);
            this.LvwCaste.TabIndex = 0;
            this.LvwCaste.UseCompatibleStateImageBehavior = false;
            this.LvwCaste.View = System.Windows.Forms.View.Details;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label106);
            this.groupBox7.Controls.Add(this.ddlPAgeTo);
            this.groupBox7.Controls.Add(this.label105);
            this.groupBox7.Controls.Add(this.ddlPAgeFrom);
            this.groupBox7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox7.Location = new System.Drawing.Point(239, 104);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(390, 68);
            this.groupBox7.TabIndex = 323;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Year";
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label106.Location = new System.Drawing.Point(6, 31);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(83, 14);
            this.label106.TabIndex = 309;
            this.label106.Text = "Born Year :";
            // 
            // ddlPAgeTo
            // 
            this.ddlPAgeTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPAgeTo.FormattingEnabled = true;
            this.ddlPAgeTo.Location = new System.Drawing.Point(227, 28);
            this.ddlPAgeTo.Name = "ddlPAgeTo";
            this.ddlPAgeTo.Size = new System.Drawing.Size(98, 22);
            this.ddlPAgeTo.TabIndex = 308;
            this.ddlPAgeTo.Tag = "nonBorn Year upto";
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label105.Location = new System.Drawing.Point(198, 32);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(23, 13);
            this.label105.TabIndex = 310;
            this.label105.Text = "To";
            // 
            // ddlPAgeFrom
            // 
            this.ddlPAgeFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPAgeFrom.FormattingEnabled = true;
            this.ddlPAgeFrom.Location = new System.Drawing.Point(94, 28);
            this.ddlPAgeFrom.Name = "ddlPAgeFrom";
            this.ddlPAgeFrom.Size = new System.Drawing.Size(98, 22);
            this.ddlPAgeFrom.TabIndex = 307;
            this.ddlPAgeFrom.Tag = "nonBorn Year Start";
            // 
            // rfrmExpiredMembership
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 337);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox7);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "rfrmExpiredMembership";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Expired Membership";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.rfrmExpiredMembership_FormClosed);
            this.Load += new System.EventHandler(this.rfrmExpiredMembership_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbtnFemale;
        private System.Windows.Forms.RadioButton rbtnMale;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView LvwCaste;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label106;
        private System.Windows.Forms.ComboBox ddlPAgeTo;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.ComboBox ddlPAgeFrom;
    }
}