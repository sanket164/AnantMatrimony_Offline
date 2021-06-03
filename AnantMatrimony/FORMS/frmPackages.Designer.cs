namespace AnantMatrimony.FORMS
{
    partial class frmPackages
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
            this.txtPackageId = new System.Windows.Forms.TextBox();
            this.txtPackageName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkIsDefault = new System.Windows.Forms.CheckBox();
            this.dgvDetails = new AnantMatrimony.CustomizeGrid();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chkIsDefault);
            this.panel1.Controls.Add(this.txtPackageId);
            this.panel1.Controls.Add(this.txtPackageName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 116);
            this.panel1.TabIndex = 0;
            // 
            // txtPackageId
            // 
            this.txtPackageId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPackageId.Location = new System.Drawing.Point(372, 13);
            this.txtPackageId.Name = "txtPackageId";
            this.txtPackageId.Size = new System.Drawing.Size(13, 22);
            this.txtPackageId.TabIndex = 135;
            this.txtPackageId.Tag = "";
            this.txtPackageId.Visible = false;
            // 
            // txtPackageName
            // 
            this.txtPackageName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPackageName.Location = new System.Drawing.Point(132, 13);
            this.txtPackageName.Name = "txtPackageName";
            this.txtPackageName.Size = new System.Drawing.Size(234, 22);
            this.txtPackageName.TabIndex = 34;
            this.txtPackageName.Tag = "Package_name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 14);
            this.label2.TabIndex = 33;
            this.label2.Text = "Package Name :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvDetails);
            this.panel2.Location = new System.Drawing.Point(12, 134);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(582, 311);
            this.panel2.TabIndex = 2;
            // 
            // chkIsDefault
            // 
            this.chkIsDefault.AutoSize = true;
            this.chkIsDefault.Location = new System.Drawing.Point(428, 15);
            this.chkIsDefault.Name = "chkIsDefault";
            this.chkIsDefault.Size = new System.Drawing.Size(87, 18);
            this.chkIsDefault.TabIndex = 136;
            this.chkIsDefault.Tag = "*IsDefault";
            this.chkIsDefault.Text = "IsDefault";
            this.chkIsDefault.UseVisualStyleBackColor = true;
            // 
            // dgvDetails
            // 
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(582, 311);
            this.dgvDetails.TabIndex = 0;
            this.dgvDetails.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDetails_CellBeginEdit);
            this.dgvDetails.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellEnter);
            this.dgvDetails.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellLeave);
            this.dgvDetails.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDetails_CellValidating);
            this.dgvDetails.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvDetails_EditingControlShowing);
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(132, 41);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(234, 70);
            this.textBox1.TabIndex = 138;
            this.textBox1.Tag = "Remark";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 137;
            this.label1.Text = "Remark :";
            // 
            // frmPackages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 458);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmPackages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Packages";
            this.Activated += new System.EventHandler(this.frmPackages_Activated);
            this.Deactivate += new System.EventHandler(this.frmPackages_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmPackages_FormClosed);
            this.Load += new System.EventHandler(this.frmPackages_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPackageName;
        private System.Windows.Forms.TextBox txtPackageId;
        private System.Windows.Forms.Panel panel2;
        private CustomizeGrid dgvDetails;
        private System.Windows.Forms.CheckBox chkIsDefault;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
    }
}