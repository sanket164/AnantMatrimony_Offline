namespace AnantMatrimony.FORMS
{
    partial class frmWorkReport
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
            this.dtpEntryDate = new System.Windows.Forms.DateTimePicker();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.txtWorkReportId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtProfileId = new System.Windows.Forms.TextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.ddlWorkType = new System.Windows.Forms.ComboBox();
            this.ddlEmployee = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dtpEntryDate);
            this.panel1.Controls.Add(this.txtDate);
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Controls.Add(this.txtWorkReportId);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.txtProfileId);
            this.panel1.Controls.Add(this.label68);
            this.panel1.Controls.Add(this.ddlWorkType);
            this.panel1.Controls.Add(this.ddlEmployee);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(563, 236);
            this.panel1.TabIndex = 0;
            // 
            // dtpEntryDate
            // 
            this.dtpEntryDate.CustomFormat = "dd/MMM/yyyy HH:mm";
            this.dtpEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEntryDate.Location = new System.Drawing.Point(388, 38);
            this.dtpEntryDate.Name = "dtpEntryDate";
            this.dtpEntryDate.Size = new System.Drawing.Size(153, 22);
            this.dtpEntryDate.TabIndex = 360;
            this.dtpEntryDate.Tag = "EntryDate";
            // 
            // txtDate
            // 
            this.txtDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDate.Location = new System.Drawing.Point(388, 11);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(123, 22);
            this.txtDate.TabIndex = 359;
            this.txtDate.TabStop = false;
            this.txtDate.Tag = "";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(426, 203);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 358;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // txtWorkReportId
            // 
            this.txtWorkReportId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWorkReportId.Location = new System.Drawing.Point(397, 67);
            this.txtWorkReportId.Name = "txtWorkReportId";
            this.txtWorkReportId.Size = new System.Drawing.Size(67, 22);
            this.txtWorkReportId.TabIndex = 357;
            this.txtWorkReportId.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 14);
            this.label3.TabIndex = 356;
            this.label3.Text = "Description :";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(143, 95);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(358, 102);
            this.txtDescription.TabIndex = 355;
            this.txtDescription.Tag = "Description";
            // 
            // txtProfileId
            // 
            this.txtProfileId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProfileId.Location = new System.Drawing.Point(143, 67);
            this.txtProfileId.Name = "txtProfileId";
            this.txtProfileId.Size = new System.Drawing.Size(239, 22);
            this.txtProfileId.TabIndex = 354;
            this.txtProfileId.Tag = "ProfileId";
            this.txtProfileId.Validating += new System.ComponentModel.CancelEventHandler(this.txtProfileId_Validating);
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label68.Location = new System.Drawing.Point(59, 69);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(78, 14);
            this.label68.TabIndex = 353;
            this.label68.Text = "Profile Id :";
            // 
            // ddlWorkType
            // 
            this.ddlWorkType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlWorkType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlWorkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlWorkType.FormattingEnabled = true;
            this.ddlWorkType.Location = new System.Drawing.Point(143, 38);
            this.ddlWorkType.Name = "ddlWorkType";
            this.ddlWorkType.Size = new System.Drawing.Size(239, 22);
            this.ddlWorkType.TabIndex = 352;
            this.ddlWorkType.Tag = "WorkTypeCode";
            // 
            // ddlEmployee
            // 
            this.ddlEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlEmployee.FormattingEnabled = true;
            this.ddlEmployee.Location = new System.Drawing.Point(143, 11);
            this.ddlEmployee.Name = "ddlEmployee";
            this.ddlEmployee.Size = new System.Drawing.Size(239, 22);
            this.ddlEmployee.TabIndex = 351;
            this.ddlEmployee.Tag = "EmployeeCode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 14);
            this.label2.TabIndex = 350;
            this.label2.Text = "Work Type :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 14);
            this.label1.TabIndex = 349;
            this.label1.Text = "Employee Name :";
            // 
            // frmWorkReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 260);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmWorkReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Work Report";
            this.Activated += new System.EventHandler(this.frmWorkReport_Activated);
            this.Deactivate += new System.EventHandler(this.frmWorkReport_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWorkReport_FormClosing);
            this.Load += new System.EventHandler(this.frmWorkReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlWorkType;
        private System.Windows.Forms.ComboBox ddlEmployee;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.TextBox txtProfileId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtWorkReportId;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.DateTimePicker dtpEntryDate;
    }
}