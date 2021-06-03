namespace AnantMatrimony.FORMS
{
    partial class LogInLog
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.LvwDetails_A = new System.Windows.Forms.ListView();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnDateSearch = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnProfileIdWise = new System.Windows.Forms.Button();
            this.txtProfileId = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnDetails = new System.Windows.Forms.RadioButton();
            this.rbtnCount = new System.Windows.Forms.RadioButton();
            this.panel2.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.LvwDetails_A);
            this.panel2.Location = new System.Drawing.Point(12, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(931, 483);
            this.panel2.TabIndex = 343;
            // 
            // LvwDetails_A
            // 
            this.LvwDetails_A.BackColor = System.Drawing.SystemColors.Info;
            this.LvwDetails_A.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LvwDetails_A.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvwDetails_A.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LvwDetails_A.FullRowSelect = true;
            this.LvwDetails_A.GridLines = true;
            this.LvwDetails_A.Location = new System.Drawing.Point(0, 0);
            this.LvwDetails_A.Name = "LvwDetails_A";
            this.LvwDetails_A.Size = new System.Drawing.Size(929, 481);
            this.LvwDetails_A.TabIndex = 1;
            this.LvwDetails_A.UseCompatibleStateImageBehavior = false;
            this.LvwDetails_A.View = System.Windows.Forms.View.Details;
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.dtpToDate);
            this.groupBox24.Controls.Add(this.btnDateSearch);
            this.groupBox24.Controls.Add(this.label9);
            this.groupBox24.Controls.Add(this.dtpFromDate);
            this.groupBox24.Controls.Add(this.label10);
            this.groupBox24.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox24.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox24.Location = new System.Drawing.Point(12, 12);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(351, 55);
            this.groupBox24.TabIndex = 374;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "Date";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpToDate.Location = new System.Drawing.Point(191, 21);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(113, 21);
            this.dtpToDate.TabIndex = 317;
            this.dtpToDate.Tag = "DateofBirth";
            // 
            // btnDateSearch
            // 
            this.btnDateSearch.Location = new System.Drawing.Point(310, 21);
            this.btnDateSearch.Name = "btnDateSearch";
            this.btnDateSearch.Size = new System.Drawing.Size(35, 23);
            this.btnDateSearch.TabIndex = 12;
            this.btnDateSearch.Text = "GO";
            this.btnDateSearch.UseVisualStyleBackColor = true;
            this.btnDateSearch.Click += new System.EventHandler(this.btnDateSearch_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 309;
            this.label9.Text = "From :";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CustomFormat = "dd/MMM/yyyy";
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFromDate.Location = new System.Drawing.Point(58, 21);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(112, 21);
            this.dtpFromDate.TabIndex = 316;
            this.dtpFromDate.Tag = "DateofBirth";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(170, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 310;
            this.label10.Text = "To";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnProfileIdWise);
            this.groupBox6.Controls.Add(this.txtProfileId);
            this.groupBox6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox6.Location = new System.Drawing.Point(369, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(239, 55);
            this.groupBox6.TabIndex = 315;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "ProfileId";
            // 
            // btnProfileIdWise
            // 
            this.btnProfileIdWise.Location = new System.Drawing.Point(194, 19);
            this.btnProfileIdWise.Name = "btnProfileIdWise";
            this.btnProfileIdWise.Size = new System.Drawing.Size(35, 23);
            this.btnProfileIdWise.TabIndex = 13;
            this.btnProfileIdWise.Text = "GO";
            this.btnProfileIdWise.UseVisualStyleBackColor = true;
            this.btnProfileIdWise.Click += new System.EventHandler(this.btnProfileIdWise_Click);
            // 
            // txtProfileId
            // 
            this.txtProfileId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProfileId.Location = new System.Drawing.Point(6, 21);
            this.txtProfileId.Name = "txtProfileId";
            this.txtProfileId.Size = new System.Drawing.Size(182, 21);
            this.txtProfileId.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnDetails);
            this.groupBox1.Controls.Add(this.rbtnCount);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.groupBox1.Location = new System.Drawing.Point(614, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(169, 55);
            this.groupBox1.TabIndex = 375;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SearchType";
            // 
            // rbtnDetails
            // 
            this.rbtnDetails.AutoSize = true;
            this.rbtnDetails.Location = new System.Drawing.Point(95, 24);
            this.rbtnDetails.Name = "rbtnDetails";
            this.rbtnDetails.Size = new System.Drawing.Size(64, 17);
            this.rbtnDetails.TabIndex = 304;
            this.rbtnDetails.Text = "Details";
            this.rbtnDetails.UseVisualStyleBackColor = true;
            // 
            // rbtnCount
            // 
            this.rbtnCount.AutoSize = true;
            this.rbtnCount.Checked = true;
            this.rbtnCount.Location = new System.Drawing.Point(14, 24);
            this.rbtnCount.Name = "rbtnCount";
            this.rbtnCount.Size = new System.Drawing.Size(59, 17);
            this.rbtnCount.TabIndex = 303;
            this.rbtnCount.TabStop = true;
            this.rbtnCount.Text = "Count";
            this.rbtnCount.UseVisualStyleBackColor = true;
            // 
            // LogInLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 568);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox24);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox6);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogInLog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "LogInLog";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LogInLog_FormClosed);
            this.Load += new System.EventHandler(this.LogInLog_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView LvwDetails_A;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtProfileId;
        private System.Windows.Forms.Button btnDateSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnDetails;
        private System.Windows.Forms.RadioButton rbtnCount;
        private System.Windows.Forms.Button btnProfileIdWise;
    }
}