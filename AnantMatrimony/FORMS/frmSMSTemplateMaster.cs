using AnantMatrimony.MatrimonyDAL;
using AnantMatrimony.UD_CLASS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnantMatrimony.FORMS
{
    public partial class frmSMSTemplateMaster : Form, ICommonFunctions
    {
        public frmSMSTemplateMaster()
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

        string strMaxId = "";
        string strMasterTable = "tbl_Template_Master";
        string strSQL = "";
        int Intcout = 0;

        int Record_Exist = 0;
        bool isValid = false;
        bool IsEdit = false;
        string strCode = "";

        private void frmSMSTemplateMaster_Load(object sender, EventArgs e)
        {
            this.TpLast = ToolbarPositions.eTPOk;
            ((frmMain)base.MdiParent).setControlState(false, true, this);
        }

        private void frmSMSTemplateMaster_Activated(object sender, EventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            objGlobal.FocusColor(this);
        }

        private void frmSMSTemplateMaster_Deactivate(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.Disable;
        }

        private void frmSMSTemplateMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
            ((frmMain)base.MdiParent).mnuSMSTemplateMaster.Enabled = true;
        }

        public void funAdd()
        {
            try
            {
                ((frmMain)base.MdiParent).setControlState(true, true, this);
                this.AutoValidate = AutoValidate.EnableAllowFocusChange;
                this.TpLast = ToolbarPositions.eTPAdd;
                ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                this.txtTemplateName.Focus();
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSMSTemplateMaster.funAdd() " + exception.ToString());
            }
        }

        public void funClear()
        {
            try
            {
                ((frmMain)base.MdiParent).setControlState(false, true, this);
                this.TpLast = ToolbarPositions.eTPOk;
                ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                this.txtTemplateName.Focus();
                this.IsEdit = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSMSTemplateMaster.funClear() " + exception.ToString());
            }
        }

        public void funDelete()
        {
            try
            {
                strSQL = "Delete from " + strMasterTable + " where Template_Id =" + txtTemplateId.Text;
                Intcout = objDb.ExecuteNonQuery(strSQL);
                if (this.Intcout > 0)
                {
                    this.objGlobal.showMessage("Template", "success", this.IsEdit, this.txtTemplateName);
                    ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPOk);
                    ((frmMain)base.MdiParent).setControlState(false, true, this);
                    this.TpLast = ToolbarPositions.eTPOk;
                    ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                    this.IsEdit = false;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSMSTemplateMaster.funDelete() " + exception.ToString());
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
                txtTemplateName.Focus();
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSMSTemplateMaster.funEdit() " + exception.ToString());
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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSMSTemplateMaster.funExit() " + exception.ToString());
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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSMSTemplateMaster.funReport() " + exception.ToString());
            }
        }

        public void funSave()
        {
            try
            {
                this.objGlobal.strvalues = "";
                this.objGlobal.strfields = "";
                this.objGlobal.strUpdate = "";
                if (checkValidation())
                {
                    if (this.IsEdit)
                    {
                        this.objGlobal.UpdateFields(this);
                    }
                    else
                    {
                        this.objGlobal.SaveFields(this);
                    }
                    //this.objtransaction2 = Global.objConnection.BeginTransaction();                    
                    this.Intcout = this.objGlobal.SaveMasterRecords(this.strMasterTable, "Template_Id", this.txtTemplateId.Text, "", this.IsEdit);
                    if (this.Intcout > 0)
                    {
                        //Global.strMasterString = this.txtName.Text;
                        //this.objtransaction2.Commit();
                        this.objGlobal.showMessage("Template ", "success", this.IsEdit, this.txtTemplateName);
                        ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPOk);
                        ((frmMain)base.MdiParent).setControlState(false, true, this);
                        this.TpLast = ToolbarPositions.eTPOk;
                        ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                        this.IsEdit = false;
                    }
                    else
                    {
                        //this.objtransaction2.Rollback();
                        this.objGlobal.showMessage("Template ", "", this.IsEdit, this.txtTemplateName);
                    }
                }
                else
                {
                    objGlobal.showMessage("Template ", "", IsEdit, txtTemplateName);
                    txtTemplateName.Focus();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSMSTemplateMaster.funSave() " + exception.ToString());
            }
        }

        public void funSearch()
        {
            try
            {
                strSQL = " Select template_id,TemplateName from " + strMasterTable;
                Global.strSearchSql = this.strSQL;
                Global.strSearchSqlWidth = " 0:400 ";
                DataView dvSearch = objDb.GetDataView(strSQL);
                strCode = objGlobal.openSearch(dvSearch);
                if (strCode != "")
                {
                    DisplayRecord(strCode, dvSearch);
                    txtTemplateId.Text = strCode;
                    ((frmMain)this.MdiParent).setControlState(false, false, this);
                    TpLast = ToolbarPositions.eTPDataDisplayed;
                    ((frmMain)this.MdiParent).setToolbarPositions(TpLast);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSMSTemplateMaster.funSearch() " + exception.ToString());
            }
        }

        private void DisplayRecord(string Code, DataView dvSearch)
        {
            try
            {
                strSQL = " Select * from " + strMasterTable + " where template_id=" + Code;
                DataTable dataTable = objDb.GetDataTable(strSQL);
                if (dvSearch.Count > 0)
                {
                    this.objGlobal.DisplayFields(this, dataTable);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSMSTemplateMaster.DisplayRecord() " + exception.ToString());
            }
        }

        private bool checkValidation()
        {
            this.isValid = true;
            try
            {
                if (txtTemplateMessage.Text == "")
                {
                    MessageBox.Show("Please Insert TemplateMessage", "TemplateMessage validation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.isValid = false;
                    this.txtTemplateMessage.Focus();
                }
                if (txtTemplateName.Text == "")
                {
                    MessageBox.Show("Please Insert TemplateName", "TemplateName validation", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    this.isValid = false;
                    this.txtTemplateName.Focus();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmSMSTemplateMaster.checkValidation() " + exception.ToString());
            }
            return isValid;
        }
    }
}
