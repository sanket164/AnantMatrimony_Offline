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
    public partial class frmWorkReport : Form, ICommonFunctions
    {
        public frmWorkReport()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
        }

        EventLogging objEventLoging = new EventLogging();
        Global objGlobal = new Global();
        ToolbarPositions TpLast;
        dbInteraction objDb = new dbInteraction();
        string strSql = "";
        bool IsEdit = false, isValid = false;
        string strMasterTable = "tbl_WorkReport";
        int Intcout = 0;

        private void frmWorkReport_Load(object sender, EventArgs e)
        {
            this.TpLast = ToolbarPositions.eTPOk;
            ((frmMain)base.MdiParent).setControlState(false, true, this);
            FillCombo();
        }

        private void frmWorkReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuWorkReport.Enabled = true;
            ((frmMain)base.MdiParent).pnlMain.Visible = true;
        }

        private void frmWorkReport_Activated(object sender, EventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            objGlobal.FocusColor(this);
        }

        public void FillCombo()
        {
            try
            {
                strSql = " SELECT * FROM tbl_EmployeeMaster";
                DataTable dtEmp = objDb.GetDataTable(strSql);
                ddlEmployee.DataSource = dtEmp;
                ddlEmployee.ValueMember = "EmployeeCode";
                ddlEmployee.DisplayMember = "EmployeeName";

                strSql = " SELECT * FROM tbl_WorkType ";
                DataTable dtWT = objDb.GetDataTable(strSql);
                ddlWorkType.DataSource = dtWT;
                ddlWorkType.ValueMember = "WorkTypeCode";
                ddlWorkType.DisplayMember = "WorkType";

                txtDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                dtpEntryDate.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmWorkReport_Deactivate(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.Disable;
        }

        public void funAdd()
        {
            try
            {
                ((frmMain)base.MdiParent).setControlState(true, true, this);
                this.AutoValidate = AutoValidate.EnableAllowFocusChange;
                this.TpLast = ToolbarPositions.eTPAdd;
                ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                this.ddlEmployee.Focus();
                txtDate.Text = DateTime.Now.ToString("dd-MM-yyyy");
                dtpEntryDate.Value = DateTime.Now;
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.funAdd() " + exception.ToString());
            }
        }

        public void funClear()
        {
            try
            {
                ((frmMain)base.MdiParent).setControlState(false, true, this);
                this.TpLast = ToolbarPositions.eTPOk;
                ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                this.ddlEmployee.Focus();
                this.IsEdit = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.funClear() " + exception.ToString());
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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.funDelete() " + exception.ToString());
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
                ddlEmployee.Focus();
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.funEdit() " + exception.ToString());
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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.funExit() " + exception.ToString());
            }
        }

        public void funReport()
        {
            try
            {
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.funReport() " + exception.ToString());
            }
        }

        public void funSave()
        {
            try
            {
                dtpEntryDate.Value = DateTime.Now;
                this.objGlobal.strvalues = "";
                this.objGlobal.strfields = "";
                this.objGlobal.strUpdate = "";
                if (checkValidation())
                {
                    this.objGlobal.SaveFields(this);
                }
                this.Intcout = this.objGlobal.SaveMasterRecords(this.strMasterTable, "WorkReportId", this.txtWorkReportId.Text, "", this.IsEdit);
                if (this.Intcout > 0)
                {
                    MessageBox.Show("Work Report Save", "Work Report save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPOk);
                    ((frmMain)base.MdiParent).setControlState(false, true, this);
                    this.TpLast = ToolbarPositions.eTPOk;
                    ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.funSave() " + exception.ToString());
            }
        }

        public void funSearch()
        {
            try
            {
                //DataSet ds = GetSaveList();
                //DataView dvSearch = ds.Tables[0].DefaultView;
                //Global.strSearchSqlWidth = " 0:200 ";
                //strCode = objGlobal.openSearch(dvSearch);
                //if (strCode != "")
                //{
                //    DisplayRecord(strCode, dvSearch);
                //    ((frmMain)this.MdiParent).setControlState(false, false, this);
                //    TpLast = ToolbarPositions.eTPDataDisplayed;
                //    ((frmMain)this.MdiParent).setToolbarPositions(TpLast);
                //}
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.funSearch() " + exception.ToString());
            }
        }

        private bool checkValidation()
        {
            this.isValid = true;
            try
            {
                if (txtProfileId.Text != "")
                {
                    strSql = "SELECT COUNT(*) FROM tbl_MemberMaster WHERE profileid='" + txtProfileId.Text + "'";
                    int Cnt = Convert.ToInt32(objDb.ExecuteScalar(strSql));
                    if (Cnt <= 0)
                    {
                        MessageBox.Show("Please Enter valid ProfileID", "ProfileId validation ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isValid = false;
                        return isValid;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.funSave() " + exception.ToString());
            }
            return isValid;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                funSave();
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.btnSubmit_Click() " + exception.ToString());
            }
        }

        private void txtProfileId_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (txtProfileId.Text != "")
                {
                    strSql = "SELECT COUNT(*) FROM tbl_MemberMaster WHERE profileid='" + txtProfileId.Text + "'";
                    int Cnt = Convert.ToInt32(objDb.ExecuteScalar(strSql));
                    if (Cnt <= 0)
                    {
                        MessageBox.Show("Please Enter valid ProfileID", "ProfileId validation ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtProfileId.Focus();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmCommonMaster.txtProfileId_Validating() " + ex.ToString());
            }
        }

    }
}
