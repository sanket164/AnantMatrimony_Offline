namespace AnantMatrimony.FORMS
{
    partial class frmBookmarkLog
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
            this.lblTotalCnt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LvwDetails = new System.Windows.Forms.ListView();
            this.lblCast = new System.Windows.Forms.Label();
            this.lblBirthYear = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnPrint);
            this.panel1.Controls.Add(this.lblCast);
            this.panel1.Controls.Add(this.lblBirthYear);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.lblTotalCnt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.txtSearchValue);
            this.panel1.Location = new System.Drawing.Point(12, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(882, 74);
            this.panel1.TabIndex = 0;
            // 
            // lblTotalCnt
            // 
            this.lblTotalCnt.AutoSize = true;
            this.lblTotalCnt.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCnt.Location = new System.Drawing.Point(5, 55);
            this.lblTotalCnt.Name = "lblTotalCnt";
            this.lblTotalCnt.Size = new System.Drawing.Size(14, 13);
            this.lblTotalCnt.TabIndex = 343;
            this.lblTotalCnt.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 13;
            this.label1.Text = "Profile Id :";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(285, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 12;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchValue.Location = new System.Drawing.Point(97, 26);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(182, 22);
            this.txtSearchValue.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.LvwDetails);
            this.panel2.Location = new System.Drawing.Point(12, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(883, 414);
            this.panel2.TabIndex = 1;
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
            this.LvwDetails.Size = new System.Drawing.Size(881, 412);
            this.LvwDetails.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.LvwDetails.TabIndex = 2;
            this.LvwDetails.UseCompatibleStateImageBehavior = false;
            this.LvwDetails.View = System.Windows.Forms.View.Details;
            // 
            // lblCast
            // 
            this.lblCast.AutoSize = true;
            this.lblCast.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCast.Location = new System.Drawing.Point(410, 49);
            this.lblCast.Name = "lblCast";
            this.lblCast.Size = new System.Drawing.Size(39, 13);
            this.lblCast.TabIndex = 358;
            this.lblCast.Text = "Caste";
            // 
            // lblBirthYear
            // 
            this.lblBirthYear.AutoSize = true;
            this.lblBirthYear.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirthYear.Location = new System.Drawing.Point(410, 29);
            this.lblBirthYear.Name = "lblBirthYear";
            this.lblBirthYear.Size = new System.Drawing.Size(60, 13);
            this.lblBirthYear.TabIndex = 357;
            this.lblBirthYear.Text = "BirthYear";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(410, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(40, 13);
            this.lblName.TabIndex = 356;
            this.lblName.Text = "Name";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(799, 44);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 359;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // frmBookmarkLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 516);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmBookmarkLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Bookmark Log";
            this.Activated += new System.EventHandler(this.frmBookmarkLog_Activated);
            this.Deactivate += new System.EventHandler(this.frmBookmarkLog_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmBookmarkLog_FormClosed);
            this.Load += new System.EventHandler(this.frmBookmarkLog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView LvwDetails;
        private System.Windows.Forms.Label lblTotalCnt;
        private System.Windows.Forms.Label lblCast;
        private System.Windows.Forms.Label lblBirthYear;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnPrint;
    }
}