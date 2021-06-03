namespace AnantMatrimony.FROMS
{
    partial class frmCommonHelp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtFilterText = new System.Windows.Forms.TextBox();
            this.lblSearchType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdHelp = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilterText
            // 
            this.txtFilterText.BackColor = System.Drawing.Color.White;
            this.txtFilterText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterText.Enabled = false;
            this.txtFilterText.Location = new System.Drawing.Point(10, 23);
            this.txtFilterText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFilterText.Name = "txtFilterText";
            this.txtFilterText.ReadOnly = true;
            this.txtFilterText.Size = new System.Drawing.Size(329, 22);
            this.txtFilterText.TabIndex = 1;
            this.txtFilterText.TextChanged += new System.EventHandler(this.txtFilterText_TextChanged);
            // 
            // lblSearchType
            // 
            this.lblSearchType.AutoSize = true;
            this.lblSearchType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSearchType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchType.ForeColor = System.Drawing.Color.Tomato;
            this.lblSearchType.Location = new System.Drawing.Point(1, 1);
            this.lblSearchType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchType.Name = "lblSearchType";
            this.lblSearchType.Size = new System.Drawing.Size(91, 16);
            this.lblSearchType.TabIndex = 3;
            this.lblSearchType.Text = "Search Type";
            this.lblSearchType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSearchType.Click += new System.EventHandler(this.lblSearchType_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(321, 426);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "PRESS ESCAPE TO EXIT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grdHelp
            // 
            this.grdHelp.AllowUserToAddRows = false;
            this.grdHelp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdHelp.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdHelp.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdHelp.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.grdHelp.Location = new System.Drawing.Point(10, 49);
            this.grdHelp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grdHelp.MultiSelect = false;
            this.grdHelp.Name = "grdHelp";
            this.grdHelp.RowHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.grdHelp.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdHelp.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.grdHelp.RowTemplate.Height = 18;
            this.grdHelp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdHelp.Size = new System.Drawing.Size(457, 364);
            this.grdHelp.TabIndex = 2;
            this.grdHelp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdHelp_KeyDown);
            this.grdHelp.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdHelp_MouseClick);
            this.grdHelp.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdHelp_KeyUp);
            this.grdHelp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdHelp_KeyPress);
            this.grdHelp.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdHelp_MouseDoubleClick);
            this.grdHelp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdHelp_CellContentClick);
            // 
            // frmCommonHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(495, 486);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSearchType);
            this.Controls.Add(this.grdHelp);
            this.Controls.Add(this.txtFilterText);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCommonHelp";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Search Help";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCommonHelp_FormClosed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmCommonHelp_KeyPress);
            this.Load += new System.EventHandler(this.frmCommonHelp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdHelp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilterText;
        private System.Windows.Forms.DataGridView grdHelp;
        private System.Windows.Forms.Label lblSearchType;
        private System.Windows.Forms.Label label1;
    }
}