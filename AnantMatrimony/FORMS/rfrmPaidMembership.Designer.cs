namespace AnantMatrimony.FORMS
{
    partial class rfrmPaidMembership
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
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label106 = new System.Windows.Forms.Label();
            this.ddlPAgeTo = new System.Windows.Forms.ComboBox();
            this.label105 = new System.Windows.Forms.Label();
            this.ddlPAgeFrom = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LvwCaste = new System.Windows.Forms.ListView();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtnPaid = new System.Windows.Forms.RadioButton();
            this.rbtnFree = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbtnFemale = new System.Windows.Forms.RadioButton();
            this.rbtnMale = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.LvwState = new System.Windows.Forms.ListView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.LvwCountry = new System.Windows.Forms.ListView();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label106);
            this.groupBox7.Controls.Add(this.ddlPAgeTo);
            this.groupBox7.Controls.Add(this.label105);
            this.groupBox7.Controls.Add(this.ddlPAgeFrom);
            this.groupBox7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox7.Location = new System.Drawing.Point(408, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(345, 57);
            this.groupBox7.TabIndex = 312;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Year";
            // 
            // label106
            // 
            this.label106.AutoSize = true;
            this.label106.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label106.Location = new System.Drawing.Point(6, 24);
            this.label106.Name = "label106";
            this.label106.Size = new System.Drawing.Size(83, 14);
            this.label106.TabIndex = 309;
            this.label106.Text = "Born Year :";
            // 
            // ddlPAgeTo
            // 
            this.ddlPAgeTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPAgeTo.FormattingEnabled = true;
            this.ddlPAgeTo.Location = new System.Drawing.Point(227, 21);
            this.ddlPAgeTo.Name = "ddlPAgeTo";
            this.ddlPAgeTo.Size = new System.Drawing.Size(98, 22);
            this.ddlPAgeTo.TabIndex = 308;
            this.ddlPAgeTo.Tag = "nonBorn Year upto";
            // 
            // label105
            // 
            this.label105.AutoSize = true;
            this.label105.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label105.Location = new System.Drawing.Point(198, 25);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(23, 13);
            this.label105.TabIndex = 310;
            this.label105.Text = "To";
            // 
            // ddlPAgeFrom
            // 
            this.ddlPAgeFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPAgeFrom.FormattingEnabled = true;
            this.ddlPAgeFrom.Location = new System.Drawing.Point(94, 21);
            this.ddlPAgeFrom.Name = "ddlPAgeFrom";
            this.ddlPAgeFrom.Size = new System.Drawing.Size(98, 22);
            this.ddlPAgeFrom.TabIndex = 307;
            this.ddlPAgeFrom.Tag = "nonBorn Year Start";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LvwCaste);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox2.Location = new System.Drawing.Point(12, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(207, 320);
            this.groupBox2.TabIndex = 315;
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
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(62, 20);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(148, 22);
            this.dtpFromDate.TabIndex = 316;
            this.dtpFromDate.Tag = "DateofBirth";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 57);
            this.groupBox1.TabIndex = 318;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Date";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(245, 20);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(139, 22);
            this.dtpToDate.TabIndex = 317;
            this.dtpToDate.Tag = "DateofBirth";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 309;
            this.label1.Text = "From :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(216, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 310;
            this.label3.Text = "To";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.SystemColors.Info;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSubmit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSubmit.Location = new System.Drawing.Point(449, 423);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(100, 32);
            this.btnSubmit.TabIndex = 319;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtnPaid);
            this.groupBox3.Controls.Add(this.rbtnFree);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox3.Location = new System.Drawing.Point(15, 398);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(192, 68);
            this.groupBox3.TabIndex = 321;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Membership";
            // 
            // rbtnPaid
            // 
            this.rbtnPaid.AutoSize = true;
            this.rbtnPaid.Location = new System.Drawing.Point(85, 32);
            this.rbtnPaid.Name = "rbtnPaid";
            this.rbtnPaid.Size = new System.Drawing.Size(54, 18);
            this.rbtnPaid.TabIndex = 305;
            this.rbtnPaid.Text = "Paid";
            this.rbtnPaid.UseVisualStyleBackColor = true;
            // 
            // rbtnFree
            // 
            this.rbtnFree.AutoSize = true;
            this.rbtnFree.Checked = true;
            this.rbtnFree.Location = new System.Drawing.Point(9, 32);
            this.rbtnFree.Name = "rbtnFree";
            this.rbtnFree.Size = new System.Drawing.Size(55, 18);
            this.rbtnFree.TabIndex = 304;
            this.rbtnFree.TabStop = true;
            this.rbtnFree.Text = "Free";
            this.rbtnFree.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.rbtnFemale);
            this.groupBox4.Controls.Add(this.rbtnMale);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox4.Location = new System.Drawing.Point(231, 398);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(192, 68);
            this.groupBox4.TabIndex = 322;
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
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.LvwState);
            this.groupBox5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox5.Location = new System.Drawing.Point(402, 72);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(198, 320);
            this.groupBox5.TabIndex = 324;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "State";
            // 
            // LvwState
            // 
            this.LvwState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LvwState.CheckBoxes = true;
            this.LvwState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvwState.GridLines = true;
            this.LvwState.Location = new System.Drawing.Point(3, 18);
            this.LvwState.Name = "LvwState";
            this.LvwState.Size = new System.Drawing.Size(192, 299);
            this.LvwState.TabIndex = 0;
            this.LvwState.UseCompatibleStateImageBehavior = false;
            this.LvwState.View = System.Windows.Forms.View.Details;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.LvwCountry);
            this.groupBox6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox6.Location = new System.Drawing.Point(225, 72);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(171, 320);
            this.groupBox6.TabIndex = 323;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Country";
            // 
            // LvwCountry
            // 
            this.LvwCountry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LvwCountry.CheckBoxes = true;
            this.LvwCountry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvwCountry.GridLines = true;
            this.LvwCountry.Location = new System.Drawing.Point(3, 18);
            this.LvwCountry.Name = "LvwCountry";
            this.LvwCountry.Size = new System.Drawing.Size(165, 299);
            this.LvwCountry.TabIndex = 0;
            this.LvwCountry.UseCompatibleStateImageBehavior = false;
            this.LvwCountry.View = System.Windows.Forms.View.Details;
            this.LvwCountry.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.LvwCountry_ItemChecked);
            this.LvwCountry.SelectedIndexChanged += new System.EventHandler(this.LvwCountry_SelectedIndexChanged);
            // 
            // rfrmPaidMembership
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 474);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox7);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "rfrmPaidMembership";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Paid Membership";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.rfrmPaidMembership_FormClosed);
            this.Load += new System.EventHandler(this.rfrmPaidMembership_Load);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label106;
        private System.Windows.Forms.ComboBox ddlPAgeTo;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.ComboBox ddlPAgeFrom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView LvwCaste;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtnPaid;
        private System.Windows.Forms.RadioButton rbtnFree;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbtnFemale;
        private System.Windows.Forms.RadioButton rbtnMale;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListView LvwState;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListView LvwCountry;
    }
}