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
    public partial class frmEmailSetting : Form, ICommonFunctions
    {
        public frmEmailSetting()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.ShowIcon = false;
        }
        dbInteraction objdb = new dbInteraction();
        EventLogging objEventLoging = new EventLogging();
        Global objGlobal = new Global();
        ToolbarPositions TpLast;


        string strMaxId = "";
        string strMasterTable = "tbl_EmailSettings";
        string strSQL = "";
        int Intcout = 0;

        int Record_Exist = 0;
        bool isValid = false;
        bool IsEdit = false;
        string strCode = "";

        private void frmEmailSetting_Load(object sender, EventArgs e)
        {
            try
            {
                this.TpLast = ToolbarPositions.eTPOk;
                ((frmMain)base.MdiParent).setControlState(false, true, this);
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmEmailSetting.frmEmailSetting_Load() " + exception.ToString());
            }
        }

        private void frmEmailSetting_Activated(object sender, EventArgs e)
        {
            try
            {
                ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                this.AutoValidate = AutoValidate.EnableAllowFocusChange;
                objGlobal.FocusColor(this);
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmEmailSetting.frmEmailSetting_Activated() " + exception.ToString());
            }
        }

        private void frmEmailSetting_Deactivate(object sender, EventArgs e)
        {
            try
            {
                this.AutoValidate = AutoValidate.Disable;
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmEmailSetting.frmEmailSetting_Deactivate() " + exception.ToString());
            }
        }

        private void frmEmailSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPNoAction);
                ((frmMain)base.MdiParent).mnuEmailSetting.Enabled = true;
                ((frmMain)base.MdiParent).pnlMain.Visible = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmEmailSetting.frmEmailSetting_FormClosed() " + exception.ToString());
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        public void funAdd()
        {
            try
            {
                ((frmMain)base.MdiParent).setControlState(true, true, this);
                this.AutoValidate = AutoValidate.EnableAllowFocusChange;
                this.TpLast = ToolbarPositions.eTPAdd;
                ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                this.txtFromEmail.Focus();
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmEmailSetting.funAdd() " + exception.ToString());
            }
        }

        public void funClear()
        {
            try
            {
                ((frmMain)base.MdiParent).setControlState(false, true, this);
                this.TpLast = ToolbarPositions.eTPOk;
                ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                this.txtFromEmail.Focus();
                this.IsEdit = false;
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmEmailSetting.funClear() " + exception.ToString());
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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmEmailSetting.funDelete() " + exception.ToString());
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
                txtFromEmail.Focus();
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmEmailSetting.funEdit() " + exception.ToString());
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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmEmailSetting.funExit() " + exception.ToString());
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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmEmailSetting.funReport() " + exception.ToString());
            }
        }

        public void funSave()
        {
            try
            {
                this.objGlobal.strvalues = "";
                this.objGlobal.strfields = "";
                this.objGlobal.strUpdate = "";
                if (ChecckValidation())
                {
                    if (this.IsEdit)
                    {
                        this.objGlobal.UpdateFields(this);
                    }
                    else
                    {
                        this.objGlobal.SaveFields(this);
                    }
                    if (chkIsDefault.Checked)
                    {
                        if (txtEmailSettingId.Text != "")
                        {
                            strSQL = "UPDATE tbl_EmailSettings set IsDefault=0 where EmailSettingId!=" + txtEmailSettingId.Text;
                        }
                        else
                        {
                            strSQL = "UPDATE tbl_EmailSettings set IsDefault=0 ";
                        }
                        objdb.ExecuteNonQuery(strSQL);
                    }
                    this.Intcout = this.objGlobal.SaveMasterRecords(this.strMasterTable, "EmailSettingId", this.txtEmailSettingId.Text, "", this.IsEdit);
                    if (this.Intcout > 0)
                    {
                        //Global.strMasterString = this.txtName.Text;
                        //this.objtransaction2.Commit();
                        this.objGlobal.showMessage("Email Setting", "success", this.IsEdit, this.txtFromEmail);
                        ((frmMain)base.MdiParent).setToolbarPositions(ToolbarPositions.eTPOk);
                        ((frmMain)base.MdiParent).setControlState(false, true, this);
                        this.TpLast = ToolbarPositions.eTPOk;
                        ((frmMain)base.MdiParent).setToolbarPositions(this.TpLast);
                        this.IsEdit = false;
                    }
                    else
                    {
                        //this.objtransaction2.Rollback();
                        this.objGlobal.showMessage("Email Setting", "", this.IsEdit, this.txtFromEmail);
                    }
                }
                else
                {
                    objGlobal.showMessage("Email Setting", "", IsEdit, txtFromEmail);
                    txtFromEmail.Focus();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmEmailSetting.funSave() " + exception.ToString());
            }
        }

        private bool ChecckValidation()
        {
            isValid = true;
            try
            {
                if (txtFromEmail.Text == "")
                {
                    MessageBox.Show("Please Enter FromEmail", "From Email Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isValid = false;
                    txtFromEmail.Focus();
                }
                //if (txtCCEmail.Text=="")
                //{
                //    MessageBox.Show("Please Enter CC Email Address","CC Email Validation",MessageBoxButtons.OK,MessageBoxIcon.Error);
                //    txtFromEmail.Focus();
                //}
                if (txtPassword.Text == "")
                {
                    MessageBox.Show("Please Enter Password", "Password Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isValid = false;
                    txtPassword.Focus();
                }
                if (txtSmtpServer.Text == "")
                {
                    MessageBox.Show("Please Enter SMTP server address", "SMTP Server Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isValid = false;
                    txtSmtpServer.Focus();
                }
                if (txtPort.Text == "")
                {
                    MessageBox.Show("Please Enter Port Number", "Port Number Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isValid = false;
                    txtPort.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmEmailSetting.ChecckValidation() " + ex.ToString());
            }
            return isValid;
        }

        public void funSearch()
        {
            try
            {
                strSQL = "select EmailSettingId,FromEmail,SMTPServer,(CASE IsDefault WHEN 1 then 'True' else 'False' end) as 'Default' from tbl_EmailSettings";
                Global.strSearchSqlWidth = "0:200:200:100";
                Global.strSearchSql = this.strSQL;
                DataView dv = objdb.GetDataView(strSQL);
                this.strCode = this.objGlobal.openSearch(dv);
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
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmEmailSetting.funSearch() " + exception.ToString());
            }
        }

        private void DisplayRecord(string strCode)
        {
            try
            {
                this.strSQL = "";
                this.strSQL = " SELECT  * from tbl_EmailSettings where EmailSettingId=" + strCode;
                DataTable dataTable = this.objdb.GetDataTable(this.strSQL);
                if (dataTable.Rows.Count > 0)
                {
                    this.txtEmailSettingId.Text = strCode;
                    this.objGlobal.DisplayFields(this, dataTable);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.frmEmailSetting.DisplayRecord() " + ex.ToString());
            }
        }

        private void txtSmtpServer_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
