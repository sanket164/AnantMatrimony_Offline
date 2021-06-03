namespace AnantMatrimony.FORMS
{
    partial class frmProfileVisitLog
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
            this.LvwDetails = new System.Windows.Forms.ListView();
            this.lblTotalCnt = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtProfileId_VisitLog = new System.Windows.Forms.TextBox();
            this.btnSearch_VisitLog = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnSummary = new System.Windows.Forms.RadioButton();
            this.rbtnDetails = new System.Windows.Forms.RadioButton();
            this.txtProfileId_ProfileHistory = new System.Windows.Forms.TextBox();
            this.btnSearch_ProfileHistory = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblBirthYear = new System.Windows.Forms.Label();
            this.lblCast = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.LvwDetails);
            this.panel2.Location = new System.Drawing.Point(4, 93);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(962, 383);
            this.panel2.TabIndex = 343;
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
            this.LvwDetails.Size = new System.Drawing.Size(960, 381);
            this.LvwDetails.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.LvwDetails.TabIndex = 1;
            this.LvwDetails.UseCompatibleStateImageBehavior = false;
            this.LvwDetails.View = System.Windows.Forms.View.Details;
            // 
            // lblTotalCnt
            // 
            this.lblTotalCnt.AutoSize = true;
            this.lblTotalCnt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCnt.Location = new System.Drawing.Point(8, 77);
            this.lblTotalCnt.Name = "lblTotalCnt";
            this.lblTotalCnt.Size = new System.Drawing.Size(14, 13);
            this.lblTotalCnt.TabIndex = 342;
            this.lblTotalCnt.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtProfileId_VisitLog);
            this.groupBox1.Controls.Add(this.btnSearch_VisitLog);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(5, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 59);
            this.groupBox1.TabIndex = 351;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Visit Log";
            // 
            // txtProfileId_VisitLog
            // 
            this.txtProfileId_VisitLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProfileId_VisitLog.Location = new System.Drawing.Point(6, 22);
            this.txtProfileId_VisitLog.Name = "txtProfileId_VisitLog";
            this.txtProfileId_VisitLog.Size = new System.Drawing.Size(113, 22);
            this.txtProfileId_VisitLog.TabIndex = 348;
            // 
            // btnSearch_VisitLog
            // 
            this.btnSearch_VisitLog.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch_VisitLog.Location = new System.Drawing.Point(138, 16);
            this.btnSearch_VisitLog.Name = "btnSearch_VisitLog";
            this.btnSearch_VisitLog.Size = new System.Drawing.Size(94, 31);
            this.btnSearch_VisitLog.TabIndex = 349;
            this.btnSearch_VisitLog.Text = "Search";
            this.btnSearch_VisitLog.UseVisualStyleBackColor = true;
            this.btnSearch_VisitLog.Click += new System.EventHandler(this.btnSearch_VisitLog_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnSummary);
            this.groupBox2.Controls.Add(this.rbtnDetails);
            this.groupBox2.Controls.Add(this.txtProfileId_ProfileHistory);
            this.groupBox2.Controls.Add(this.btnSearch_ProfileHistory);
            this.groupBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(256, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 59);
            this.groupBox2.TabIndex = 352;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Profile History";
            // 
            // rbtnSummary
            // 
            this.rbtnSummary.AutoSize = true;
            this.rbtnSummary.Location = new System.Drawing.Point(245, 31);
            this.rbtnSummary.Name = "rbtnSummary";
            this.rbtnSummary.Size = new System.Drawing.Size(63, 18);
            this.rbtnSummary.TabIndex = 357;
            this.rbtnSummary.Text = "Count";
            this.rbtnSummary.UseVisualStyleBackColor = true;
            // 
            // rbtnDetails
            // 
            this.rbtnDetails.AutoSize = true;
            this.rbtnDetails.Checked = true;
            this.rbtnDetails.Location = new System.Drawing.Point(245, 11);
            this.rbtnDetails.Name = "rbtnDetails";
            this.rbtnDetails.Size = new System.Drawing.Size(71, 18);
            this.rbtnDetails.TabIndex = 356;
            this.rbtnDetails.TabStop = true;
            this.rbtnDetails.Text = "Details";
            this.rbtnDetails.UseVisualStyleBackColor = true;
            // 
            // txtProfileId_ProfileHistory
            // 
            this.txtProfileId_ProfileHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProfileId_ProfileHistory.Location = new System.Drawing.Point(6, 22);
            this.txtProfileId_ProfileHistory.Name = "txtProfileId_ProfileHistory";
            this.txtProfileId_ProfileHistory.Size = new System.Drawing.Size(113, 22);
            this.txtProfileId_ProfileHistory.TabIndex = 348;
            // 
            // btnSearch_ProfileHistory
            // 
            this.btnSearch_ProfileHistory.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch_ProfileHistory.Location = new System.Drawing.Point(138, 16);
            this.btnSearch_ProfileHistory.Name = "btnSearch_ProfileHistory";
            this.btnSearch_ProfileHistory.Size = new System.Drawing.Size(94, 31);
            this.btnSearch_ProfileHistory.TabIndex = 349;
            this.btnSearch_ProfileHistory.Text = "Search";
            this.btnSearch_ProfileHistory.UseVisualStyleBackColor = true;
            this.btnSearch_ProfileHistory.Click += new System.EventHandler(this.btnSearch_ProfileHistory_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(619, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(40, 13);
            this.lblName.TabIndex = 353;
            this.lblName.Text = "Name";
            // 
            // lblBirthYear
            // 
            this.lblBirthYear.AutoSize = true;
            this.lblBirthYear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirthYear.Location = new System.Drawing.Point(619, 31);
            this.lblBirthYear.Name = "lblBirthYear";
            this.lblBirthYear.Size = new System.Drawing.Size(60, 13);
            this.lblBirthYear.TabIndex = 354;
            this.lblBirthYear.Text = "BirthYear";
            // 
            // lblCast
            // 
            this.lblCast.AutoSize = true;
            this.lblCast.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCast.Location = new System.Drawing.Point(619, 51);
            this.lblCast.Name = "lblCast";
            this.lblCast.Size = new System.Drawing.Size(39, 13);
            this.lblCast.TabIndex = 355;
            this.lblCast.Text = "Caste";
            // 
            // frmProfileVisitLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 486);
            this.Controls.Add(this.lblCast);
            this.Controls.Add(this.lblBirthYear);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblTotalCnt);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmProfileVisitLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Profile Visit Log";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmProfileVisitLog_FormClosed);
            this.Load += new System.EventHandler(this.frmProfileVisitLog_Load);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView LvwDetails;
        private System.Windows.Forms.Label lblTotalCnt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtProfileId_VisitLog;
        private System.Windows.Forms.Button btnSearch_VisitLog;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtProfileId_ProfileHistory;
        private System.Windows.Forms.Button btnSearch_ProfileHistory;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblBirthYear;
        private System.Windows.Forms.Label lblCast;
        private System.Windows.Forms.RadioButton rbtnDetails;
        private System.Windows.Forms.RadioButton rbtnSummary;
    }
}