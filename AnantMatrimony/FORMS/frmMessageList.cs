using AnantMatrimony.MatrimonyDAL;
using AnantMatrimony.UD_CLASS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnantMatrimony.FORMS
{
    public partial class frmMessageList : Form
    {
        public frmMessageList()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
        }

        public enum CI
        {
            MessageCode = 0,
            SenderName,
            ContactNo,
            Email,
            Message,
            Edit,
            Ex,
            Exa1
        }

        EventLogging objEventLoging = new EventLogging();
        Global objGlobal = new Global();
        ToolbarPositions TpLast;
        dbInteraction objDb = new dbInteraction();
        public string sSearchType = "", sSearchVal = "";

        private void frmMessageList_Load(object sender, EventArgs e)
        {
            GridDesign(dgvDetails);
            txtCurPage.Text = "1";
            FillData("");
            ddlSearchBy.SelectedIndex = 0;
            txtSearchValue.Text = "";
        }

        private void frmMessageList_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuQueryMessage.Enabled = true;
            ((frmMain)base.MdiParent).pnlMain.Visible = true;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmQueryMessage objFrm = new frmQueryMessage();
            objFrm.ShowDialog();
            txtCurPage.Text = "1";
            FillData("");
            ddlSearchBy.SelectedIndex = 0;
            txtSearchValue.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlSearchBy.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select Search Type", "Search Type Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ddlSearchBy.Focus();
                    return;
                }
                if (txtSearchValue.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter Search Value", "Search Value Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSearchValue.Focus();
                    return;
                }
                Cursor = Cursors.WaitCursor;
                pnlSearch.Enabled = false;
                DataSet ds = new DataSet();
                ds = SeaarchData(ddlSearchBy.Text, txtSearchValue.Text);
                FillGrid(ds);
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.btnSearch_Click() " + ex.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCurPage.Text = "1";
            FillData("");
            ddlSearchBy.SelectedIndex = 0;
            txtSearchValue.Text = "";
        }

        public void GridDesign(DataGridView dgv)
        {
            try
            {
                int index = 0;
                //dgv.TopLeftHeaderCell.Value = "SrNo.";
                //dgv.RowHeadersWidth = 80;
                int btnCounter = 0;
                dgv.RowHeadersVisible = false;
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.EditMode = DataGridViewEditMode.EditOnEnter;
                DataGridViewTextBoxColumn[] columnArray = new DataGridViewTextBoxColumn[20];
                DataGridViewButtonColumn grdButton;
                string[] strArray = new string[] 
                { 
                    "MessageCode", "Sender Name", "Contact No", "Email", "Message", "Edit", "Ex", "Ex1" 
                };
                int[] numArray = new int[] 
                { 
                    0, 150, 100, 200, 400, 80, 80, 0, 0 
                };
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i] == "Edit")
                    {
                        grdButton = new DataGridViewButtonColumn();
                        grdButton.HeaderText = strArray[i];
                        grdButton.Width = numArray[i];
                        grdButton.FlatStyle = FlatStyle.Popup;
                        dgv.Columns.Add(grdButton);
                        btnCounter = btnCounter + 1;
                    }
                    else
                    {
                        columnArray[index] = new DataGridViewTextBoxColumn();
                        columnArray[index].HeaderText = strArray[i];
                        columnArray[index].Width = numArray[i];
                        dgv.Columns.Add(columnArray[index]);
                        dgv.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
                        index++;
                    }
                }
                dgv.Columns[(int)CI.MessageCode].Visible = false;
                dgv.Columns[(int)CI.Ex].Visible = false;
                dgv.Columns[(int)CI.Exa1].Visible = false;

                dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;

                dgv.BackgroundColor = Color.LightYellow;
                dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.EditMode = DataGridViewEditMode.EditOnEnter;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
                dgv.DefaultCellStyle.ForeColor = Color.Black;
                dgv.DefaultCellStyle.BackColor = Color.LightYellow;
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMessageList.GridDesign() " + exception.ToString());
            }
        }

        public DataSet FillData(string strSearch)
        {
            DataSet dsData = new DataSet();
            try
            {
                int PageCount = 0;
                tbl_QueryProp objtbl_QueryProp = new tbl_QueryProp();

                objtbl_QueryProp.PageNo = Convert.ToInt32(txtCurPage.Text);
                objtbl_QueryProp.RecordCount = Convert.ToInt32(20);

                tbl_QueryBAL Objtbl_QueryBAL = new tbl_QueryBAL();
                dsData = Objtbl_QueryBAL.Select_Data(objtbl_QueryProp, ref PageCount);
                lblTotalPageCount.Text = Convert.ToString(PageCount);



                FillGrid(dsData);
                return dsData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.FillData() " + ex.ToString());
            }
            return dsData;
        }

        public DataSet SeaarchData(string sSearchBy, string sSearchVal)
        {
            DataSet ds = new DataSet();
            try
            {
                tbl_QueryProp objtbl_QueryProp = new tbl_QueryProp();
                objtbl_QueryProp.SearchBy = sSearchBy;
                objtbl_QueryProp.SearchVal = sSearchVal;

                objtbl_QueryProp.PageNo = 1;
                objtbl_QueryProp.RecordCount = 10000;

                tbl_QueryBAL Objtbl_QueryBAL = new tbl_QueryBAL();
                int PageCount = 0;
                ds = Objtbl_QueryBAL.Search_Data(objtbl_QueryProp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.SeaarchData() " + ex.ToString());
            }
            return ds;
        }

        private void FillGrid(DataSet dsData)
        {
            try
            {
                dgvDetails.Rows.Clear();
                if (dsData.Tables.Count == 0)
                {
                    MessageBox.Show("Data not Found", "Data Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dgvDetails.RowCount = dsData.Tables[0].Rows.Count;
                for (int cnt = 0; cnt < dsData.Tables[0].Rows.Count; cnt++)
                {
                    dgvDetails[(int)CI.MessageCode, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["MessageCode"]);
                    dgvDetails[(int)CI.ContactNo, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["ContactNo"]);
                    dgvDetails[(int)CI.Email, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["Email"]);
                    dgvDetails[(int)CI.Message, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["SenderMessage"]);
                    dgvDetails[(int)CI.SenderName, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["SenderName"]);
                    dgvDetails[(int)CI.Edit, cnt].Value = "Edit";
                    if (Convert.ToString(dsData.Tables[0].Rows[cnt]["Status"]) == "False")
                    {
                        dgvDetails.Rows[cnt].DefaultCellStyle.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
                    }
                }
                dgvDetails.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.FillData() " + ex.ToString());
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int CurrPage = Convert.ToInt32(txtCurPage.Text);
            txtCurPage.Text = Convert.ToString(CurrPage - 1);
            FillData("");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int CurrPage = Convert.ToInt32(txtCurPage.Text);
            txtCurPage.Text = Convert.ToString(CurrPage + 1);
            FillData("");
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            FillData("");
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int intRowNo = e.RowIndex;
                string strCode = Convert.ToString(dgvDetails[(int)CI.MessageCode, e.RowIndex].Value);
                //string ProfileId = Convert.ToString(dgvDetails[(int)CI.ProfileId, e.RowIndex].Value);
                if (e.ColumnIndex == (int)CI.Edit)
                {
                    frmQueryMessage objMSG = new frmQueryMessage(Convert.ToInt32(strCode));
                    objMSG.ShowDialog();
                    txtCurPage.Text = "1";
                    FillData("");
                    ddlSearchBy.SelectedIndex = 0;
                    txtSearchValue.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
            }
        }




    }
}
