using AnantMatrimony.MatrimonyDAL;
using AnantMatrimony.UD_CLASS;
using CrystalDecisions.CrystalReports.Engine;
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
    public partial class frmMemberMasterList : Form, ICommonFunctions
    {
        public frmMemberMasterList()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
        }

        public enum CI
        {
            MemberCode = 0,
            ProfileId,
            MemberName,
            Caste,
            DOB,
            ContactNo,
            Membership,
            Status,
            Edit,
            Print,
            Ex,
            Exa1
        }

        EventLogging objEventLoging = new EventLogging();
        Global objGlobal = new Global();
        ToolbarPositions TpLast;
        dbInteraction objDb = new dbInteraction();

        public string sSearchType = "", sSearchVal = "";

        private void frmMemberMasterList_Load(object sender, EventArgs e)
        {
            GridDesign(dgvDetails);
            txtCurPage.Text = "1";
            FillData("");
            ddlSearchBy.SelectedIndex = 0;
            txtSearchValue.Text = "";
        }

        public DataSet FillData(string strSearch)
        {
            DataSet dsData = new DataSet();
            try
            {
                int PageCount = 0;
                tbl_MemberMasterProp Objtbl_MemberMasterProp = new tbl_MemberMasterProp();
                Objtbl_MemberMasterProp.MemberCode = 0;
                Objtbl_MemberMasterProp.PageNo = Convert.ToInt32(txtCurPage.Text);
                Objtbl_MemberMasterProp.RecordCount = Convert.ToInt32(20);
                tbl_MemberMasterBAL Objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                if (sSearchVal != "" && sSearchType != "")
                {
                    Objtbl_MemberMasterProp.SearchBy = sSearchType;
                    Objtbl_MemberMasterProp.SearchVal = sSearchVal;
                    dsData = Objtbl_MemberMasterBAL.Search_Data(Objtbl_MemberMasterProp, ref PageCount);
                }
                else
                {
                    dsData = Objtbl_MemberMasterBAL.Select_Data(Objtbl_MemberMasterProp, ref PageCount);
                    lblTotalPageCount.Text = Convert.ToString(PageCount);
                }


                FillGrid(dsData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.FillData() " + ex.ToString());
            }
            return dsData;
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
                    dgvDetails[(int)CI.Caste, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["Caste"]);
                    dgvDetails[(int)CI.ContactNo, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["ContactNo"]);
                    dgvDetails[(int)CI.DOB, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["DateOfBirth"]);
                    dgvDetails[(int)CI.MemberCode, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["MemberCode"]);
                    dgvDetails[(int)CI.MemberName, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["MemberName"]);
                    dgvDetails[(int)CI.Membership, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["Membership"]);
                    dgvDetails[(int)CI.ProfileId, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["ProfileID"]);
                    dgvDetails[(int)CI.Status, cnt].Value = Convert.ToString(dsData.Tables[0].Rows[cnt]["Status"]);
                    dgvDetails[(int)CI.Print, cnt].Value = "Print";
                    dgvDetails[(int)CI.Edit, cnt].Value = "Edit";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.FillData() " + ex.ToString());
            }
        }

        private void frmMemberMasterList_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuMemberMaster.Enabled = true;
            ((frmMain)base.MdiParent).pnlMain.Visible = true;
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
                    "MemberCode", "Profile Id", "Member Name", "Caste", "Date Of Birth", "Contact No", "Membership", "Status","Edit","Print", "Ex", "Ex1" 
                };
                int[] numArray = new int[] 
                { 
                    0, 150, 180, 100, 100, 100, 100, 100, 80, 80, 0, 0 
                };
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i] == "Print" || strArray[i] == "Edit")
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
                dgv.Columns[(int)CI.MemberCode].Visible = false;
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
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
                dgv.DefaultCellStyle.ForeColor = Color.Blue;
                dgv.DefaultCellStyle.BackColor = Color.LightYellow;
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMasterList.GridDesign() " + exception.ToString());
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int CurrPage = Convert.ToInt32(txtCurPage.Text);
            txtCurPage.Text = Convert.ToString(CurrPage + 1);
            FillData("");
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            int CurrPage = Convert.ToInt32(txtCurPage.Text);
            txtCurPage.Text = Convert.ToString(CurrPage - 1);
            FillData("");
        }

        private void txtCurPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            objGlobal.onlyNumber(sender, e, false);
        }

        private void dgvDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int intRowNo = e.RowIndex;
                string strCode = Convert.ToString(dgvDetails[(int)CI.MemberCode, e.RowIndex].Value);
                string ProfileId = Convert.ToString(dgvDetails[(int)CI.ProfileId, e.RowIndex].Value);
                
                if (e.ColumnIndex == (int)CI.Edit)
                {
                    this.objEventLoging.AppClickLog("Search", "Edit", ProfileId, strCode, "");
                    //Global.strMemberCode = strCode;
                    frmMemberMaster objMember = new frmMemberMaster();
                    if (Convert.ToString(dgvDetails[(int)CI.Status, e.RowIndex].Value) == "Active")
                    {
                        frmMemberMaster.isActiveStatus = 1;
                    }
                    else if (Convert.ToString(dgvDetails[(int)CI.Status, e.RowIndex].Value) == "Updated")
                    {
                        frmMemberMaster.isActiveStatus = 2;
                    }
                    frmMemberMaster.strMemberCode = strCode;
                    objMember.ShowDialog();
                    txtCurPage.Text = "1";
                    FillData("");
                    ddlSearchBy.SelectedIndex = 0;
                    txtSearchValue.Text = "";
                }
                else if (e.ColumnIndex == (int)CI.Print)
                {
                    this.objEventLoging.AppClickLog("Search", "Print", ProfileId, strCode, "");
                    //DataTable dsData = new DataTable();
                    //int PageCount = 0;
                    //string strSql = "select MemberCode,ProfileID,ProfileCreatedBy,MemberName,Gender,DateofBirth,TimeofBirth,BirthPlace,MaritalStatus ";
                    //strSql += " from tbl_membermaster where MemberCode=" + strCode;
                    //dsData = objDb.GetDataTable(strSql);

                    tbl_MemberMasterProp Objtbl_MemberMasterProp = new tbl_MemberMasterProp();
                    Objtbl_MemberMasterProp.MemberCode = 0;
                    Objtbl_MemberMasterProp.ProfileID = ProfileId; // ProfileID;
                    Objtbl_MemberMasterProp.isLogedin = true;
                    Objtbl_MemberMasterProp.LoginCode = 0;

                    tbl_MemberMasterBAL Objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                    DataSet dsMemberMaster = Objtbl_MemberMasterBAL.Load_MemberDetails(Objtbl_MemberMasterProp);                    

                    dsMemberMaster.Tables[0].TableName = "dsMemberMaster";

                    tbl_SibblingDetailsProp Objtbl_SibblingDetailsProp = new tbl_SibblingDetailsProp();
                    Objtbl_SibblingDetailsProp.MemberCode = Convert.ToInt32(dsMemberMaster.Tables[0].Rows[0]["MemberCode"]);

                    tbl_SibblingDetailsBAL Objtbl_SibblingDetailsBAL = new tbl_SibblingDetailsBAL();
                    DataSet dsSibbling = Objtbl_SibblingDetailsBAL.Select_Data(Objtbl_SibblingDetailsProp);
                    dsSibbling.Tables[0].TableName = "dsSibblingDtl";
                    

                    tbl_MemberPhotosBAL objtbl_MemberPhotosBAL = new tbl_MemberPhotosBAL();
                    tbl_MemberPhotosProp objtbl_MemberPhotosProp = new tbl_MemberPhotosProp();
                    objtbl_MemberPhotosProp.MemberCode = Convert.ToInt32(strCode);
                    DataSet dsMemberPhotos = objtbl_MemberPhotosBAL.Select_Data(objtbl_MemberPhotosProp);
                    dsMemberPhotos.Tables[0].TableName = "dsMemberPhotos";
                    
                   // dsMemberMaster.Tables.Add(dsSibbling.Tables[0]);
                    //dsMemberMaster.Tables.Add(dsMemberPhotos.Tables[0]);
                    frmReportViewer objReportViewer = new frmReportViewer();
                    ReportDocument cryRpt = new ReportDocument();
                    string strPath = Application.StartupPath + @"\REPORTS\MemberMaster.rpt";
                    cryRpt.Load(strPath);
                    DataSet dstest = new DataSet();

                    dstest.Tables.Add(dsMemberMaster.Tables[0].Copy());
                    //dstest.Tables.Add(dsMemberPhotos.Tables[0].Copy());
                    cryRpt.Subreports["Sibbling"].SetDataSource(dsSibbling.Tables[0]);
                    //cryRpt.Subreports["MemberPhotos"].SetDataSource(dsMemberPhotos.Tables[0]);

                    cryRpt.SetDataSource(dstest);

                    objReportViewer.RptViewer.ReportSource = cryRpt;
                    objReportViewer.RptViewer.Refresh();
                    objReportViewer.ShowDialog();
                    objReportViewer.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                tbl_MemberMasterBAL Objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                Objtbl_MemberMasterBAL.InsertSearchLog(txtSearchValue.Text, ddlSearchBy.Text, DateTime.Now, Global.intUserId);
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

        public DataSet SeaarchData(string sSearchBy, string sSearchVal)
        {
            DataSet ds = new DataSet();
            try
            {
                tbl_MemberMasterProp Objtbl_MemberMasterProp = new tbl_MemberMasterProp();
                Objtbl_MemberMasterProp.SearchBy = sSearchBy;
                Objtbl_MemberMasterProp.SearchVal = sSearchVal;

                Objtbl_MemberMasterProp.PageNo = 1;
                Objtbl_MemberMasterProp.RecordCount = 10000;

                tbl_MemberMasterBAL Objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                int PageCount = 0;
                ds = Objtbl_MemberMasterBAL.Search_Data(Objtbl_MemberMasterProp, ref PageCount);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.SeaarchData() " + ex.ToString());
            }
            return ds;
        }
        public void funAdd()
        {
        }

        public void funClear()
        {
        }

        public void funDelete()
        {
        }

        public void funEdit()
        {
        }

        public void funExit()
        {
            try
            {
                this.TpLast = ToolbarPositions.eTPNoAction;
                ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                base.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMaster.funExit() " + exception.ToString());
            }
        }

        public void funReport()
        {
        }

        public void funSave()
        {
        }

        public void funSearch()
        {
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {   
            Global.strMasterName = "";
            frmMemberMaster objMember = new frmMemberMaster();
            frmMemberMaster.strMemberCode = "";
            objMember.Show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                pnlSearch.Enabled = true;
                FillData("");
                ddlSearchBy.SelectedIndex = 0;
                txtSearchValue.Text = "";
                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            FillData("");
        }








    }
}
