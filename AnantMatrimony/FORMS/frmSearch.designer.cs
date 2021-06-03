namespace AnantMatrimony.FORMS
{
    partial class frmSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtFilterText = new System.Windows.Forms.TextBox();
            this.lblSearchType = new System.Windows.Forms.Label();
            this.grdSearch = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilterText
            // 
            this.txtFilterText.BackColor = System.Drawing.Color.White;
            this.txtFilterText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilterText.Enabled = false;
            this.txtFilterText.Location = new System.Drawing.Point(187, 4);
            this.txtFilterText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFilterText.Name = "txtFilterText";
            this.txtFilterText.ReadOnly = true;
            this.txtFilterText.Size = new System.Drawing.Size(313, 22);
            this.txtFilterText.TabIndex = 1;
            // 
            // lblSearchType
            // 
            this.lblSearchType.AutoSize = true;
            this.lblSearchType.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchType.ForeColor = System.Drawing.Color.Blue;
            this.lblSearchType.Location = new System.Drawing.Point(24, 5);
            this.lblSearchType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchType.Name = "lblSearchType";
            this.lblSearchType.Size = new System.Drawing.Size(89, 14);
            this.lblSearchType.TabIndex = 3;
            this.lblSearchType.Text = "Search Type";
            this.lblSearchType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grdSearch
            // 
            this.grdSearch.AllowUserToAddRows = false;
            this.grdSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdSearch.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdSearch.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.grdSearch.Location = new System.Drawing.Point(5, 31);
            this.grdSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.grdSearch.MultiSelect = false;
            this.grdSearch.Name = "grdSearch";
            this.grdSearch.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.grdSearch.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grdSearch.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.grdSearch.RowTemplate.Height = 20;
            this.grdSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdSearch.Size = new System.Drawing.Size(650, 410);
            this.grdSearch.TabIndex = 2;
            this.grdSearch.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSearch_CellContentClick);
            this.grdSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdSearch_KeyDown);
            this.grdSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.grdSearch_KeyPress);
            this.grdSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.grdSearch_KeyUp);
            this.grdSearch.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grdSearch_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(184, 454);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "PRESS ESCAPE TO EXIT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Blue;
            this.lblTotal.Location = new System.Drawing.Point(591, 8);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(59, 13);
            this.lblTotal.TabIndex = 6;
            this.lblTotal.Text = "Total Cnt";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 476);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSearchType);
            this.Controls.Add(this.grdSearch);
            this.Controls.Add(this.txtFilterText);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmSearch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Search";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSearch_FormClosed);
            this.Load += new System.EventHandler(this.frmSearch_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmSearch_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilterText;
        private System.Windows.Forms.DataGridView grdSearch;
        private System.Windows.Forms.Label lblSearchType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotal;
    }
}