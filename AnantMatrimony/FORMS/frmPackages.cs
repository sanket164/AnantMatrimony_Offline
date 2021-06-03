using AnantMatrimony.MatrimonyDAL;
using AnantMatrimony.UD_CLASS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnantMatrimony.FORMS
{
    public partial class frmPackages : Form, ICommonFunctions
    {
        EventLogging objEventLoging = new EventLogging();
        Global objGlobal = new Global();
        ToolbarPositions TpLast;
        SqlTransaction objtransaction;
        dbInteraction objDb = new dbInteraction();

        string strMaxId = "";
        string strMasterTable = "tbl_Package";
        string strSQL = "";
        int Intcout = 0;

        int Record_Exist = 0;
        bool isValid = false;
        bool IsEdit = false;
        string strCode = "";

        int row = 0, col = 0;
        ContextMenu cnxMenu = new ContextMenu();

        public frmPackages()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
        }

        public enum CI
        {
            MembershipName = 0,
            Amount,
            Description,
            Ex
        }

        private void frmPackages_Load(object sender, EventArgs e)
        {
            try
            {
                this.TpLast = ToolbarPositions.eTPOk;
                ((frmMain)base.MdiParent).setControlState(false, true, this);
                GridDesign(dgvDetails);
                this.cnxMenu.MenuItems.Add("Delete selected Rows", new EventHandler(this.Delete_Selected_Rows));
                this.cnxMenu.MenuItems.Add("Insert Row Above", new EventHandler(this.Insert_Rows_Abvoe));
                this.cnxMenu.MenuItems.Add("Insert Row Below", new EventHandler(this.Insert_Rows_Below));
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony." + this.Name + ".frmPackages_Load() " + ex.ToString());
            }
        }

        private void frmPackages_FormClosed(object sender, FormClosedEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuManagePackage.Enabled = true;
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
                    "Name", "Amount","Remark", "Ex"
                };
                int[] numArray = new int[] 
                { 
                    200, 100,150, 0 
                };
                for (int i = 0; i < strArray.Length; i++)
                {
                    columnArray[index] = new DataGridViewTextBoxColumn();
                    columnArray[index].HeaderText = strArray[i];
                    columnArray[index].Width = numArray[i];
                    dgv.Columns.Add(columnArray[index]);
                    dgv.Columns[index].SortMode = DataGridViewColumnSortMode.NotSortable;
                    index++;
                }
                dgv.Columns[(int)CI.Ex].Visible = false;

                dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;

                dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft;
                dgv.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                dgv.EditMode = DataGridViewEditMode.EditOnEnter;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.Sunken;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSeaGreen;
                dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
                dgv.DefaultCellStyle.ForeColor = Color.Blue;
                dgv.DefaultCellStyle.BackColor = SystemColors.Control;
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmMemberMasterList.GridDesign() " + exception.ToString());
            }
        }

        public void funAdd()
        {
            try
            {
                ((frmMain)base.MdiParent).setControlState(true, true, this);
                this.AutoValidate = AutoValidate.EnableAllowFocusChange;
                this.TpLast = ToolbarPositions.eTPAdd;
                ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                this.dgvDetails.Rows.Clear();
                this.dgvDetails.Rows.Add();
                this.txtPackageName.Focus();
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.funAdd() " + exception.ToString());
            }
        }

        public void funEdit()
        {
            try
            {
                ((frmMain)base.MdiParent).setControlState(true, false, this);
                this.TpLast = ToolbarPositions.eTPEdit;
                ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                IsEdit = true;
                this.dgvDetails.HorizontalScrollingOffset = 0;
                this.dgvDetails.RowCount++;
                txtPackageName.Focus();
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.funEdit() " + exception.ToString());
            }
        }

        public void funSave()
        {
            try
            {
                if (checkValidation())
                {
                    this.objGlobal.strvalues = "";
                    this.objGlobal.strfields = "";
                    this.objGlobal.strUpdate = "";
                    if (IsEdit)
                    {
                        this.objGlobal.UpdateFields(this);
                    }
                    else
                    {
                        this.objGlobal.SaveFields(this);
                    }
                    this.Intcout = this.objGlobal.SaveMasterRecords(this.strMasterTable, "Package_Id", this.txtPackageId.Text, "", this.IsEdit);
                    if (this.Intcout > 0)
                    {
                        if (!SaveDetails(this.Intcout))
                        {

                        }
                        this.objGlobal.showMessage("Package", "success", this.IsEdit, this.txtPackageName);
                        ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPOk);
                        ((frmMain)base.MdiParent).setControlState(false, true, this);
                        this.TpLast = ToolbarPositions.eTPOk;
                        ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                        this.IsEdit = false;
                    }
                    else
                    {
                        objGlobal.showMessage("Package", "", IsEdit, txtPackageName);
                        txtPackageName.Focus();
                    }
                }
                else
                {
                    objGlobal.showMessage("Package", "", IsEdit, txtPackageName);
                    txtPackageName.Focus();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.funSave() " + exception.ToString());
            }
        }
        private bool checkValidation()
        {
            this.isValid = true;
            try
            {
                if (this.txtPackageName.Text == "")
                {
                    MessageBox.Show("Please select Country", "Country validation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.isValid = false;
                    this.txtPackageName.Focus();
                }
                if (dgvDetails.RowCount > 0)
                {
                    if (Convert.ToString(dgvDetails[(int)CI.MembershipName, 0].Value) == "")
                    {
                        MessageBox.Show("Please insert Details", "Detials validation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        this.isValid = false;
                        this.dgvDetails.Focus();
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.funSave() " + exception.ToString());
            }
            return isValid;
        }
        public bool SaveDetails(int PackageId)
        {
            try
            {
                if (IsEdit)
                {
                    PackageId = Convert.ToInt32(txtPackageId.Text);
                    strSQL = "Delete from tbl_package_details where Package_Id = " + PackageId;
                    objDb.ExecuteNonQuery(strSQL);
                }
                int Res = 0;
                for (int cnt = 0; cnt < dgvDetails.Rows.Count; cnt++)
                {
                    if (Convert.ToString(dgvDetails[(int)CI.MembershipName, cnt].Value) != "")
                    {
                        string MembershipName = Convert.ToString(dgvDetails[(int)CI.MembershipName, cnt].Value);
                        double Amount = Convert.ToDouble(dgvDetails[(int)CI.Amount, cnt].Value);
                        string Remark = Convert.ToString(dgvDetails[(int)CI.Description, cnt].Value);
                        strSQL = "INSERT INTO tbl_Package_Details (Package_Details_Id,Package_Id,Membership_name,Amount,Remark)VALUES";
                        strSQL += "(" + (cnt + 1) + "," + PackageId + ",'" + MembershipName.Trim() + "'," + Amount + ",'" + Remark + "')";
                        Res = objDb.ExecuteNonQuery(strSQL);
                    }
                }
                if (chkIsDefault.Checked)
                {
                    strSQL = "UPDATE tbl_Package SET IsDefault=0 WHERE Package_Id!=" + PackageId;
                    objDb.ExecuteNonQuery(strSQL);
                }
                if (Res <= 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.SaveDetails() " + exception.ToString());
                return false;
            }
        }

        public void funDelete()
        {
            try
            {
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.funDelete() " + exception.ToString());
            }
        }

        public void funSearch()
        {
            try
            {
                strSQL = "select Package_Id,Package_name as PackageName,";
                strSQL += "(case IsDefault when 1 then 'True' else 'False' end) as IsDefault from tbl_Package order by Package_Id";
                Global.strSearchSqlWidth = "0:200:100";
                Global.strSearchSql = this.strSQL;
                DataView dv = objDb.GetDataView(strSQL);
                this.strCode = this.objGlobal.openSearch(dv);
                IsEdit = false;
                if (this.strCode != "")
                {
                    this.DisplayRecord(this.strCode);
                    ((frmMain)base.MdiParent).setControlState(false, false, this);
                    this.TpLast = ToolbarPositions.eTPDataDisplayed;
                    ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.funSearch() " + exception.ToString());
            }
        }
        private void DisplayRecord(string strCode)
        {
            try
            {
                txtPackageId.Text = strCode;
                this.strSQL = "";
                this.strSQL = " SELECT  * from tbl_Package where Package_Id=" + strCode;
                DataTable dataTable = this.objDb.GetDataTable(this.strSQL);
                if (dataTable.Rows.Count > 0)
                {
                    this.objGlobal.DisplayFields(this, dataTable);
                    GetEntryDetails(strCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmEmailSetting.DisplayRecord() " + ex.ToString());
            }
        }
        public void funReport()
        {

        }

        public void funClear()
        {
            try
            {
                ((frmMain)base.MdiParent).setControlState(false, true, this);
                this.TpLast = ToolbarPositions.eTPOk;
                ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                this.txtPackageName.Focus();
                this.IsEdit = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.funClear() " + exception.ToString());
            }
        }
        private void GetEntryDetails(string Code)
        {
            try
            {
                this.dgvDetails.Rows.Clear();
                strSQL = "select* from tbl_Package_Details where Package_Id=" + Code;
                DataTable dtDetails = objDb.GetDataTable(strSQL);
                if (dtDetails.Rows.Count > 0)
                {
                    dgvDetails.RowCount = dtDetails.Rows.Count;
                    for (int cnt = 0; cnt < dtDetails.Rows.Count; cnt++)
                    {
                        this.dgvDetails[(int)CI.MembershipName, cnt].Value = Convert.ToString(dtDetails.Rows[cnt]["Membership_name"]);
                        this.dgvDetails[(int)CI.Amount, cnt].Value = Convert.ToString(dtDetails.Rows[cnt]["Amount"]);
                        this.dgvDetails[(int)CI.Description, cnt].Value = Convert.ToString(dtDetails.Rows[cnt]["Remark"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                string err = ex.StackTrace;
                string errForm = err.Substring(err.LastIndexOf("\\") + 1);
                string LineNumber = errForm.Substring(errForm.IndexOf(":") + 1);
                objEventLoging.AppErrlog("Error In BussERP." + this.Name + ".GetEntryDetails() " + ex.ToString() + "" + LineNumber);
            }
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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmStateCity.funExit() " + exception.ToString());
            }
        }

        private void frmPackages_Activated(object sender, EventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            objGlobal.FocusColor(this);
        }

        private void frmPackages_Deactivate(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.Disable;
        }

        private void dgvDetails_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (this.dgvDetails.Enabled)
                {
                    this.objGlobal.CalcSrNo(this.dgvDetails);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In BusinessERP." + this.Name + ".dgvDetails_CellBeginEdit() " + ex.ToString());
            }
        }

        private void dgvDetails_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgvDetails.Enabled)
                {
                    this.col = e.ColumnIndex;
                    Global.ControlChange = false;
                    if (this.dgvDetails.CurrentCell.ReadOnly)
                    {
                        SendKeys.Send("{TAB}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In BusinessERP." + this.Name + ".dgvDetails_CellEnter() " + ex.ToString());
            }
        }

        private void dgvDetails_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.dgvDetails.CurrentCell.Style.BackColor = this.dgvDetails.DefaultCellStyle.BackColor;
                this.dgvDetails.CurrentCell.Style.ForeColor = Color.Blue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In BusinessERP." + this.Name + ".dgvDetails_CellLeave() " + ex.ToString());
            }
        }

        private void dgvDetails_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void dgvDetails_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                TextBox box;
                if (this.col == (int)CI.Amount)
                {
                    TextBox control = (TextBox)e.Control;
                    control.ReadOnly = false;
                    control.KeyPress += new KeyPressEventHandler(this.TxtBox_KeyPress);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In BusinessERP." + this.Name + ".dgvDetails_EditingControlShowing() " + ex.ToString());
            }
        }
        private void TxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (this.col == (int)CI.Amount)
                {
                    this.objGlobal.onlyNumber(sender, e, true);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                string err = exception.StackTrace;
                string errForm = err.Substring(err.LastIndexOf("\\") + 1);
                string LineNumber = errForm.Substring(errForm.IndexOf(":") + 1);
                this.objEventLoging.AppErrlog("Error In BussERP.frmProduct.TxtBox_KeyPress" + exception.ToString() + LineNumber);
            }
        }

        private void Delete_Selected_Rows(object sender, EventArgs e)
        {
            try
            {
                this.objGlobal.Delete_Selected_Rows(this.dgvDetails);
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In BusinessERP." + this.Name + ".Delete_Selected_Rows" + exception.ToString());
            }
        }

        private void Insert_Rows_Abvoe(object sender, EventArgs e)
        {
            try
            {
                this.objGlobal.Insert_Rows_Abvoe(this.dgvDetails);
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In BusinessERP." + this.Name + ".Insert_Rows_Abvoe" + exception.ToString());
            }
        }

        private void Insert_Rows_Below(object sender, EventArgs e)
        {
            try
            {
                this.objGlobal.Insert_Rows_Below(this.dgvDetails);
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In BusinessERP." + this.Name + ".Insert_Rows_Below" + exception.ToString());
            }
        }

    }
}
