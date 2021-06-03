namespace AnantMatrimony.FORMS
{
    partial class frmMessageList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMessageList));
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.lblTotalCnt = new System.Windows.Forms.Label();
            this.txtCurPage = new System.Windows.Forms.TextBox();
            this.lblTotalPageCount = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearchValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlSearchBy = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDetails = new AnantMatrimony.CustomizeGrid();
            this.pnlSearch.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.lblTotalCnt);
            this.pnlSearch.Controls.Add(this.txtCurPage);
            this.pnlSearch.Controls.Add(this.lblTotalPageCount);
            this.pnlSearch.Controls.Add(this.btnGo);
            this.pnlSearch.Controls.Add(this.btnPrevious);
            this.pnlSearch.Controls.Add(this.btnNext);
            this.pnlSearch.Location = new System.Drawing.Point(755, 3);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(253, 55);
            this.pnlSearch.TabIndex = 12;
            // 
            // lblTotalCnt
            // 
            this.lblTotalCnt.AutoSize = true;
            this.lblTotalCnt.Location = new System.Drawing.Point(4, 4);
            this.lblTotalCnt.Name = "lblTotalCnt";
            this.lblTotalCnt.Size = new System.Drawing.Size(45, 14);
            this.lblTotalCnt.TabIndex = 9;
            this.lblTotalCnt.Text = "label1";
            this.lblTotalCnt.Visible = false;
            // 
            // txtCurPage
            // 
            this.txtCurPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurPage.Location = new System.Drawing.Point(42, 26);
            this.txtCurPage.Name = "txtCurPage";
            this.txtCurPage.Size = new System.Drawing.Size(57, 22);
            this.txtCurPage.TabIndex = 2;
            // 
            // lblTotalPageCount
            // 
            this.lblTotalPageCount.AutoSize = true;
            this.lblTotalPageCount.Location = new System.Drawing.Point(187, 30);
            this.lblTotalPageCount.Name = "lblTotalPageCount";
            this.lblTotalPageCount.Size = new System.Drawing.Size(45, 14);
            this.lblTotalPageCount.TabIndex = 3;
            this.lblTotalPageCount.Text = "label1";
            // 
            // btnGo
            // 
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Location = new System.Drawing.Point(136, 26);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(37, 23);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "GO";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
            this.btnPrevious.Location = new System.Drawing.Point(7, 26);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(33, 23);
            this.btnPrevious.TabIndex = 4;
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(101, 26);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(33, 23);
            this.btnNext.TabIndex = 5;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnAddNew);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.txtSearchValue);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.ddlSearchBy);
            this.panel2.Location = new System.Drawing.Point(4, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(745, 55);
            this.panel2.TabIndex = 11;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(642, 11);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(16, 11);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(75, 23);
            this.btnAddNew.TabIndex = 11;
            this.btnAddNew.Text = "Add New";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(561, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchValue
            // 
            this.txtSearchValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchValue.Location = new System.Drawing.Point(364, 11);
            this.txtSearchValue.Name = "txtSearchValue";
            this.txtSearchValue.Size = new System.Drawing.Size(182, 22);
            this.txtSearchValue.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 14);
            this.label1.TabIndex = 8;
            this.label1.Text = "Search By :";
            // 
            // ddlSearchBy
            // 
            this.ddlSearchBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSearchBy.FormattingEnabled = true;
            this.ddlSearchBy.Items.AddRange(new object[] {
            "--SELECT--"});
            this.ddlSearchBy.Location = new System.Drawing.Point(184, 10);
            this.ddlSearchBy.Name = "ddlSearchBy";
            this.ddlSearchBy.Size = new System.Drawing.Size(174, 22);
            this.ddlSearchBy.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDetails);
            this.panel1.Location = new System.Drawing.Point(4, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1004, 314);
            this.panel1.TabIndex = 13;
            // 
            // dgvDetails
            // 
            this.dgvDetails.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(1004, 314);
            this.dgvDetails.TabIndex = 0;
            this.dgvDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetails_CellClick);
            // 
            // frmMessageList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 383);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMessageList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Message List";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMessageList_FormClosed);
            this.Load += new System.EventHandler(this.frmMessageList_Load);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Label lblTotalCnt;
        private System.Windows.Forms.TextBox txtCurPage;
        private System.Windows.Forms.Label lblTotalPageCount;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearchValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlSearchBy;
        private System.Windows.Forms.Panel panel1;
        private CustomizeGrid dgvDetails;
    }
}