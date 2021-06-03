namespace AnantMatrimony.FORMS
{
    partial class frmPhotosUploadInfo
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.ddlCaste = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label106 = new System.Windows.Forms.Label();
            this.ddlPAgeTo = new System.Windows.Forms.ComboBox();
            this.label105 = new System.Windows.Forms.Label();
            this.ddlPAgeFrom = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.rdbtnFemale = new System.Windows.Forms.RadioButton();
            this.rdbtnMale = new System.Windows.Forms.RadioButton();
            this.lblTotalCnt = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LvwDetails = new System.Windows.Forms.ListView();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.btnSendSMS = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnInvert = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProfileId = new System.Windows.Forms.TextBox();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(819, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 31);
            this.btnSearch.TabIndex = 339;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ddlCaste
            // 
            this.ddlCaste.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlCaste.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlCaste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCaste.FormattingEnabled = true;
            this.ddlCaste.Location = new System.Drawing.Point(574, 18);
            this.ddlCaste.Name = "ddlCaste";
            this.ddlCaste.Size = new System.Drawing.Size(239, 22);
            this.ddlCaste.TabIndex = 337;
            this.ddlCaste.Tag = "Height";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(518, 22);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(53, 14);
            this.label31.TabIndex = 338;
            this.label31.Text = "Caste :";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label106);
            this.groupBox7.Controls.Add(this.ddlPAgeTo);
            this.groupBox7.Controls.Add(this.label105);
            this.groupBox7.Controls.Add(this.ddlPAgeFrom);
            this.groupBox7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox7.Location = new System.Drawing.Point(153, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(337, 68);
            this.groupBox7.TabIndex = 336;
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
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.rdbtnFemale);
            this.groupBox6.Controls.Add(this.rdbtnMale);
            this.groupBox6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox6.Location = new System.Drawing.Point(5, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(144, 68);
            this.groupBox6.TabIndex = 335;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Gender";
            // 
            // rdbtnFemale
            // 
            this.rdbtnFemale.AutoSize = true;
            this.rdbtnFemale.Location = new System.Drawing.Point(69, 31);
            this.rdbtnFemale.Name = "rdbtnFemale";
            this.rdbtnFemale.Size = new System.Drawing.Size(73, 18);
            this.rdbtnFemale.TabIndex = 304;
            this.rdbtnFemale.Text = "Female";
            this.rdbtnFemale.UseVisualStyleBackColor = true;
            // 
            // rdbtnMale
            // 
            this.rdbtnMale.AutoSize = true;
            this.rdbtnMale.Checked = true;
            this.rdbtnMale.Location = new System.Drawing.Point(9, 31);
            this.rdbtnMale.Name = "rdbtnMale";
            this.rdbtnMale.Size = new System.Drawing.Size(56, 18);
            this.rdbtnMale.TabIndex = 303;
            this.rdbtnMale.TabStop = true;
            this.rdbtnMale.Text = "Male";
            this.rdbtnMale.UseVisualStyleBackColor = true;
            // 
            // lblTotalCnt
            // 
            this.lblTotalCnt.AutoSize = true;
            this.lblTotalCnt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCnt.Location = new System.Drawing.Point(9, 83);
            this.lblTotalCnt.Name = "lblTotalCnt";
            this.lblTotalCnt.Size = new System.Drawing.Size(14, 13);
            this.lblTotalCnt.TabIndex = 340;
            this.lblTotalCnt.Text = "0";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.LvwDetails);
            this.panel2.Location = new System.Drawing.Point(5, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(932, 383);
            this.panel2.TabIndex = 341;
            // 
            // LvwDetails
            // 
            this.LvwDetails.BackColor = System.Drawing.SystemColors.Info;
            this.LvwDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LvwDetails.CheckBoxes = true;
            this.LvwDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvwDetails.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LvwDetails.FullRowSelect = true;
            this.LvwDetails.GridLines = true;
            this.LvwDetails.Location = new System.Drawing.Point(0, 0);
            this.LvwDetails.Name = "LvwDetails";
            this.LvwDetails.Size = new System.Drawing.Size(930, 381);
            this.LvwDetails.TabIndex = 1;
            this.LvwDetails.UseCompatibleStateImageBehavior = false;
            this.LvwDetails.View = System.Windows.Forms.View.Details;
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSendEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendEmail.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendEmail.Location = new System.Drawing.Point(740, 486);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(94, 31);
            this.btnSendEmail.TabIndex = 342;
            this.btnSendEmail.Text = "Send Mail";
            this.btnSendEmail.UseVisualStyleBackColor = false;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // btnSendSMS
            // 
            this.btnSendSMS.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSendSMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendSMS.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendSMS.Location = new System.Drawing.Point(840, 486);
            this.btnSendSMS.Name = "btnSendSMS";
            this.btnSendSMS.Size = new System.Drawing.Size(94, 31);
            this.btnSendSMS.TabIndex = 343;
            this.btnSendSMS.Text = "Send SMS";
            this.btnSendSMS.UseVisualStyleBackColor = false;
            this.btnSendSMS.Click += new System.EventHandler(this.btnSendSMS_Click);
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.Color.Gainsboro;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.Location = new System.Drawing.Point(8, 486);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(98, 31);
            this.btnAll.TabIndex = 0;
            this.btnAll.Text = "SELECT ALL";
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Gainsboro;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(119, 486);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(63, 31);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnInvert
            // 
            this.btnInvert.BackColor = System.Drawing.Color.Gainsboro;
            this.btnInvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInvert.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvert.Location = new System.Drawing.Point(191, 486);
            this.btnInvert.Name = "btnInvert";
            this.btnInvert.Size = new System.Drawing.Size(75, 31);
            this.btnInvert.TabIndex = 2;
            this.btnInvert.Text = "INVERT";
            this.btnInvert.UseVisualStyleBackColor = false;
            this.btnInvert.Click += new System.EventHandler(this.btnInvert_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(640, 486);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(94, 31);
            this.btnPrint.TabIndex = 344;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(493, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 345;
            this.label1.Text = "Profile Id :";
            // 
            // txtProfileId
            // 
            this.txtProfileId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProfileId.Location = new System.Drawing.Point(574, 46);
            this.txtProfileId.Name = "txtProfileId";
            this.txtProfileId.Size = new System.Drawing.Size(239, 22);
            this.txtProfileId.TabIndex = 346;
            // 
            // frmPhotosUploadInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(949, 531);
            this.Controls.Add(this.txtProfileId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSendSMS);
            this.Controls.Add(this.btnInvert);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblTotalCnt);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.ddlCaste);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPhotosUploadInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Photos Upload Info";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPhotosUploadInfo_FormClosed);
            this.Load += new System.EventHandler(this.frmPhotosUploadInfo_Load);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox ddlCaste;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label106;
        private System.Windows.Forms.ComboBox ddlPAgeTo;
        private System.Windows.Forms.Label label105;
        private System.Windows.Forms.ComboBox ddlPAgeFrom;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton rdbtnFemale;
        private System.Windows.Forms.RadioButton rdbtnMale;
        private System.Windows.Forms.Label lblTotalCnt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Button btnSendSMS;
        private System.Windows.Forms.ListView LvwDetails;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnInvert;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProfileId;
    }
}