namespace AnantMatrimony.FORMS
{
    partial class frmMembershipMaster
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.updwnMembershipMonth = new System.Windows.Forms.NumericUpDown();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpJoinDate = new System.Windows.Forms.DateTimePicker();
            this.txtProfileCreatedByCode = new System.Windows.Forms.TextBox();
            this.txtProfileCreatedBy = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtBankBranch = new System.Windows.Forms.TextBox();
            this.dtpChaqueDate = new System.Windows.Forms.DateTimePicker();
            this.txtChaqueNo = new System.Windows.Forms.TextBox();
            this.cmbPayBy = new System.Windows.Forms.ComboBox();
            this.txtMemberName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updwnMembershipMonth)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dtpEndDate);
            this.panel1.Controls.Add(this.updwnMembershipMonth);
            this.panel1.Controls.Add(this.dtpStartDate);
            this.panel1.Controls.Add(this.dtpJoinDate);
            this.panel1.Controls.Add(this.txtProfileCreatedByCode);
            this.panel1.Controls.Add(this.txtProfileCreatedBy);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 150);
            this.panel1.TabIndex = 0;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd/MM/yyyy";
            this.dtpEndDate.Enabled = false;
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(190, 111);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(135, 22);
            this.dtpEndDate.TabIndex = 330;
            // 
            // updwnMembershipMonth
            // 
            this.updwnMembershipMonth.Location = new System.Drawing.Point(190, 86);
            this.updwnMembershipMonth.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.updwnMembershipMonth.Name = "updwnMembershipMonth";
            this.updwnMembershipMonth.Size = new System.Drawing.Size(71, 22);
            this.updwnMembershipMonth.TabIndex = 123;
            this.updwnMembershipMonth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd/MM/yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(190, 37);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(135, 22);
            this.dtpStartDate.TabIndex = 148;
            // 
            // dtpJoinDate
            // 
            this.dtpJoinDate.CustomFormat = "dd/MM/yyyy";
            this.dtpJoinDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpJoinDate.Location = new System.Drawing.Point(190, 62);
            this.dtpJoinDate.Name = "dtpJoinDate";
            this.dtpJoinDate.Size = new System.Drawing.Size(135, 22);
            this.dtpJoinDate.TabIndex = 149;
            // 
            // txtProfileCreatedByCode
            // 
            this.txtProfileCreatedByCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProfileCreatedByCode.Location = new System.Drawing.Point(429, 15);
            this.txtProfileCreatedByCode.Name = "txtProfileCreatedByCode";
            this.txtProfileCreatedByCode.Size = new System.Drawing.Size(13, 22);
            this.txtProfileCreatedByCode.TabIndex = 329;
            this.txtProfileCreatedByCode.Tag = "*ProfileCreatedByCode";
            this.txtProfileCreatedByCode.Visible = false;
            // 
            // txtProfileCreatedBy
            // 
            this.txtProfileCreatedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProfileCreatedBy.Location = new System.Drawing.Point(190, 15);
            this.txtProfileCreatedBy.Name = "txtProfileCreatedBy";
            this.txtProfileCreatedBy.Size = new System.Drawing.Size(237, 22);
            this.txtProfileCreatedBy.TabIndex = 328;
            this.txtProfileCreatedBy.Tag = "%ProfileCreatedBy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 14);
            this.label5.TabIndex = 127;
            this.label5.Text = "Membership Expired On :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 14);
            this.label4.TabIndex = 126;
            this.label4.Text = "MemberShip Period :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 14);
            this.label3.TabIndex = 125;
            this.label3.Text = "Membership Start :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 14);
            this.label2.TabIndex = 124;
            this.label2.Text = "Join Date :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 14);
            this.label1.TabIndex = 123;
            this.label1.Text = "MemberShip Type :";
            // 
            // label88
            // 
            this.label88.AutoSize = true;
            this.label88.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label88.Location = new System.Drawing.Point(23, 6);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(132, 14);
            this.label88.TabIndex = 122;
            this.label88.Text = "MemberShip Detail";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtBankBranch);
            this.panel2.Controls.Add(this.dtpChaqueDate);
            this.panel2.Controls.Add(this.txtChaqueNo);
            this.panel2.Controls.Add(this.cmbPayBy);
            this.panel2.Controls.Add(this.txtMemberName);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(12, 168);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(557, 131);
            this.panel2.TabIndex = 331;
            // 
            // txtBankBranch
            // 
            this.txtBankBranch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBankBranch.Location = new System.Drawing.Point(190, 95);
            this.txtBankBranch.Name = "txtBankBranch";
            this.txtBankBranch.Size = new System.Drawing.Size(260, 22);
            this.txtBankBranch.TabIndex = 135;
            this.txtBankBranch.Tag = "";
            // 
            // dtpChaqueDate
            // 
            this.dtpChaqueDate.CustomFormat = "dd/MM/yyyy";
            this.dtpChaqueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpChaqueDate.Location = new System.Drawing.Point(339, 69);
            this.dtpChaqueDate.Name = "dtpChaqueDate";
            this.dtpChaqueDate.Size = new System.Drawing.Size(111, 22);
            this.dtpChaqueDate.TabIndex = 134;
            // 
            // txtChaqueNo
            // 
            this.txtChaqueNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChaqueNo.Location = new System.Drawing.Point(190, 69);
            this.txtChaqueNo.Name = "txtChaqueNo";
            this.txtChaqueNo.Size = new System.Drawing.Size(143, 22);
            this.txtChaqueNo.TabIndex = 133;
            this.txtChaqueNo.Tag = "nonnumChequeNo";
            // 
            // cmbPayBy
            // 
            this.cmbPayBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayBy.FormattingEnabled = true;
            this.cmbPayBy.Items.AddRange(new object[] {
            "Cash",
            "Cheque / DD"});
            this.cmbPayBy.Location = new System.Drawing.Point(190, 45);
            this.cmbPayBy.Name = "cmbPayBy";
            this.cmbPayBy.Size = new System.Drawing.Size(260, 22);
            this.cmbPayBy.TabIndex = 132;
            // 
            // txtMemberName
            // 
            this.txtMemberName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMemberName.Location = new System.Drawing.Point(190, 20);
            this.txtMemberName.Name = "txtMemberName";
            this.txtMemberName.Size = new System.Drawing.Size(135, 22);
            this.txtMemberName.TabIndex = 131;
            this.txtMemberName.Tag = "MemberName";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(73, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 14);
            this.label7.TabIndex = 130;
            this.label7.Text = "Bank && Branch :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 69);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(138, 14);
            this.label8.TabIndex = 129;
            this.label8.Text = "Cheque No. / Date :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(124, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 14);
            this.label9.TabIndex = 128;
            this.label9.Text = "Pay By :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(120, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 14);
            this.label10.TabIndex = 127;
            this.label10.Text = "Amount :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 14);
            this.label6.TabIndex = 123;
            this.label6.Text = "Payment Detail";
            // 
            // frmMembershipMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 311);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label88);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmMembershipMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Membership Master";
            this.Load += new System.EventHandler(this.frmMembershipMaster_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updwnMembershipMonth)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label88;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProfileCreatedByCode;
        private System.Windows.Forms.TextBox txtProfileCreatedBy;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.NumericUpDown updwnMembershipMonth;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpJoinDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMemberName;
        private System.Windows.Forms.ComboBox cmbPayBy;
        private System.Windows.Forms.TextBox txtBankBranch;
        private System.Windows.Forms.DateTimePicker dtpChaqueDate;
        private System.Windows.Forms.TextBox txtChaqueNo;
    }
}