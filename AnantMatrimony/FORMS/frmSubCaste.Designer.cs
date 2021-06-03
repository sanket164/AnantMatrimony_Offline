namespace AnantMatrimony.FORMS
{
    partial class frmSubCaste
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
            this.txtSubCasteCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCaste = new System.Windows.Forms.ComboBox();
            this.txtSubCaste = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtSubCasteCode);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbCaste);
            this.panel1.Controls.Add(this.txtSubCaste);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(10, 7);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(347, 76);
            this.panel1.TabIndex = 0;
            // 
            // txtSubCasteCode
            // 
            this.txtSubCasteCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubCasteCode.Location = new System.Drawing.Point(3, 5);
            this.txtSubCasteCode.Name = "txtSubCasteCode";
            this.txtSubCasteCode.Size = new System.Drawing.Size(13, 22);
            this.txtSubCasteCode.TabIndex = 134;
            this.txtSubCasteCode.Tag = "";
            this.txtSubCasteCode.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 14);
            this.label2.TabIndex = 38;
            this.label2.Text = "Caste :";
            // 
            // cmbCaste
            // 
            this.cmbCaste.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCaste.FormattingEnabled = true;
            this.cmbCaste.Location = new System.Drawing.Point(94, 10);
            this.cmbCaste.Name = "cmbCaste";
            this.cmbCaste.Size = new System.Drawing.Size(234, 22);
            this.cmbCaste.TabIndex = 0;
            // 
            // txtSubCaste
            // 
            this.txtSubCaste.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubCaste.Location = new System.Drawing.Point(94, 38);
            this.txtSubCaste.Name = "txtSubCaste";
            this.txtSubCaste.Size = new System.Drawing.Size(234, 22);
            this.txtSubCaste.TabIndex = 1;
            this.txtSubCaste.Tag = "comtxtSubCaste";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 35;
            this.label1.Text = "SubCaste :";
            // 
            // frmSubCaste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 94);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmSubCaste";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Sub Caste";
            this.Activated += new System.EventHandler(this.frmSubCaste_Activated);
            this.Deactivate += new System.EventHandler(this.frmSubCaste_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSubCaste_FormClosed);
            this.Load += new System.EventHandler(this.frmSubCaste_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbCaste;
        private System.Windows.Forms.TextBox txtSubCaste;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSubCasteCode;
    }
}