using AnantMatrimony.UD_CLASS;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnantMatrimony.FORMS
{
    public partial class frmMain : Form
    {
        Global objGlobal = new Global();
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
            {
                // #2
                MdiClient client = control as MdiClient;
                if (!(client == null))
                {
                    // #3
                    client.BackColor = Color.White;
                    // 4#
                    break;
                }
            }

            stbrDate.Text = "Date : - " + DateTime.Today.Date.ToString("dd -MM - yyyy");
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = "Version : " + fvi.FileVersion;
            lblVersion.Text = version;

            lblUser.Text = "User :" + Global.intUserId; ;
            setToolbarPositions(ToolbarPositions.eTPNoAction);

            RegisteredAccount();
            NewRegisteredAccount();
            UpdatedProfile();
            DoneProfile();
            BlockProfile();
            UnreadMessage();
        }

        private void frfMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (this.ActiveMdiChild != null)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.Enter:
                            if (this.ActiveMdiChild.ActiveControl != null)
                            {
                                if (this.ActiveMdiChild.ActiveControl.AccessibilityObject.Role.ToString() == "ComboBox" && this.ActiveMdiChild.ActiveControl.Text == "" && Global.bolCombo)
                                {
                                    ComboBox cmb = new ComboBox();
                                    cmb = (ComboBox)this.ActiveMdiChild.ActiveControl;
                                    cmb.DroppedDown = true;
                                }
                                else if (this.ActiveMdiChild.GetNextControl(this.ActiveMdiChild.ActiveControl, true) != null)
                                {
                                    SendKeys.Send("{TAB}");
                                }
                            }
                            break;
                        case Keys.F1: //To Add
                            //IActiveChild.funAdd();
                            this.btnToolAdd_Click(sender, e);
                            break;
                        case Keys.F3: //To Search
                            //IActiveChild.funSearch();
                            this.btnToolSearch_Click(sender, e);
                            break;
                        case Keys.F4: //To Edit
                            //IActiveChild.funEdit();
                            this.btnToolEdit_Click(sender, e);
                            break;
                        case Keys.F5: //To Save
                            //IActiveChild.funSave();
                            this.btnToolSave_Click(sender, e);
                            break;
                        case Keys.F6: //To Delete
                            //IActiveChild.funDelete();
                            this.btnToolDelete_Click(sender, e);
                            break;
                        case Keys.F7: //To Clear
                            //IActiveChild.funClear();
                            this.btnToolClear_Click(sender, e);
                            break;
                        case Keys.F8: //To Show Report
                            //IActiveChild.funReport();
                            this.btnToolReport_Click(sender, e);
                            break;
                        case Keys.Escape:
                            if (this.ActiveMdiChild.ActiveControl != null)
                            {
                                if (this.ActiveMdiChild.ActiveControl.GetType().Name.ToString() == "HScrollBar" || this.ActiveMdiChild.ActiveControl.GetType().Name.ToString() == "DataGridViewTextBoxEditingControl")
                                {
                                    Global.ControlChange = true;
                                    this.ActiveMdiChild.GetNextControl(this.ActiveMdiChild, true).Focus();
                                    // SendKeys.Send("{TAB}");
                                }
                                else if (this.ActiveMdiChild.ActiveControl.GetType().Name.ToString() == "ComboBox")
                                {
                                    this.btnToolExit_Click(sender, e);
                                }
                                else
                                {
                                    this.btnToolExit_Click(sender, e);
                                }
                            }
                            else
                            {
                                this.btnToolExit_Click(sender, e);
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In VasyERP.MDIMain.MDIMain_KeyDown() " + ex.ToString());
            }
        }

        EventLogging objEventLoging = new EventLogging();
        bool bolExit = false;
        public void ShowForm(Form frm, ToolStripMenuItem tsm)
        {
            try
            {
                pnlMain.Visible = false;
                frm.MdiParent = this;
                frm.Show();
                tsm.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ShowReportForm(Form frm, ToolStripMenuItem tsm)
        {
            try
            {
                pnlMain.Visible = false;
                frm.MdiParent = this;
                frm.Show();
                if (tsm != null)
                {
                    tsm.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void setToolbarPositions(ToolbarPositions TP)
        {
            try
            {
                //this.ActiveMdiChild.AutoValidate = AutoValidate.EnableAllowFocusChange;
                switch (TP)
                {
                    case ToolbarPositions.eTPNoAction:  //NoAction 
                        this.btnToolAdd.Enabled = false;
                        this.btnToolEdit.Enabled = false;
                        this.btnToolSave.Enabled = false;
                        this.btnToolDelete.Enabled = false;
                        this.btnToolSearch.Enabled = false;
                        this.btnToolClear.Enabled = false;
                        this.btnToolReport.Enabled = false;
                        break;
                    case ToolbarPositions.eTPAdd: //Add
                        this.btnToolAdd.Enabled = false;
                        this.btnToolEdit.Enabled = false;
                        this.btnToolSave.Enabled = true;
                        this.btnToolDelete.Enabled = false;
                        this.btnToolSearch.Enabled = false;
                        this.btnToolClear.Enabled = true;
                        this.btnToolReport.Enabled = false;
                        break;
                    case ToolbarPositions.eTPEdit: //Edit
                        this.btnToolAdd.Enabled = false;
                        this.btnToolEdit.Enabled = false;
                        this.btnToolSave.Enabled = true;
                        this.btnToolDelete.Enabled = false;
                        this.btnToolSearch.Enabled = false;
                        this.btnToolClear.Enabled = true;
                        this.btnToolReport.Enabled = false;
                        break;
                    case ToolbarPositions.eTPDataDisplayed: //Data Displayed
                        this.btnToolAdd.Enabled = true;
                        this.btnToolEdit.Enabled = true;
                        this.btnToolSave.Enabled = false;
                        this.btnToolDelete.Enabled = true;
                        this.btnToolSearch.Enabled = true;
                        this.btnToolClear.Enabled = true;
                        this.btnToolReport.Enabled = true;
                        break;
                    case ToolbarPositions.eTPOk: //Ok
                        this.btnToolAdd.Enabled = true;
                        this.btnToolEdit.Enabled = false;
                        this.btnToolSave.Enabled = false;
                        this.btnToolDelete.Enabled = false;
                        this.btnToolSearch.Enabled = true;
                        this.btnToolClear.Enabled = true;
                        this.btnToolReport.Enabled = false;
                        break;
                    case ToolbarPositions.eTPDelete: // Delete
                        this.btnToolAdd.Enabled = true;
                        this.btnToolEdit.Enabled = false;
                        this.btnToolSave.Enabled = false;
                        this.btnToolDelete.Enabled = false;
                        this.btnToolSearch.Enabled = true;
                        this.btnToolClear.Enabled = true;
                        this.btnToolReport.Enabled = false;
                        break;
                }
                if (this.ActiveMdiChild != null)
                {
                    if (Convert.ToString(this.ActiveMdiChild.Tag) != "")
                    {
                        this.btnToolAdd.Enabled = Convert.ToBoolean(Convert.ToByte(this.ActiveMdiChild.Tag.ToString().Substring(0, 1)));
                        this.btnToolEdit.Enabled = Convert.ToBoolean(Convert.ToByte(this.ActiveMdiChild.Tag.ToString().Substring(2, 1)));
                        this.btnToolDelete.Enabled = Convert.ToBoolean(Convert.ToByte(this.ActiveMdiChild.Tag.ToString().Substring(4, 1)));
                        this.btnToolSearch.Enabled = Convert.ToBoolean(Convert.ToByte(this.ActiveMdiChild.Tag.ToString().Substring(6, 1)));
                        this.btnToolReport.Enabled = Convert.ToBoolean(Convert.ToByte(this.ActiveMdiChild.Tag.ToString().Substring(8, 1)));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In VasyERP.MDIMain.setToolbarPositions() " + ex.ToString());
            }
        }
        public void setControlState(bool Enable, bool Clear, Control cntl)
        {
            CheckBox chkBox;
            DataGridView dgv;
            RadioButton rdobtn;
            try
            {
                // Loop through all controls on the child form.
                foreach (Control cnt in cntl.Controls)
                {
                    if (cnt is TextBox || cnt is ComboBox || cnt is MaskedTextBox)
                    {
                        //((TextBox)frm.Controls[i]).ReadOnly = bLock;
                        cnt.Enabled = Enable;
                        // Clear the contents of the control since it is a TextBox.
                        if (Clear == true)
                        {
                            cnt.Text = "";
                        }
                    }
                    else if (cnt is Button)
                    {
                        if (cnt.Name.ToString() == "btnPrevious" || cnt.Name.ToString() == "btnNext")
                        {
                            cnt.Enabled = true;
                        }
                        else
                        {
                            cnt.Enabled = Enable;
                        }
                    }
                    else if (cnt is DataGridView)
                    {
                        dgv = (DataGridView)cnt;
                        Global.ControlChange = true;
                        dgv.Enabled = false;
                        if (Clear == true)
                        {
                            if (dgv.Rows.Count >= 1)
                            {
                                dgv.Rows.Clear();
                                dgv.Rows.Add();
                            }
                        }
                        dgv.Enabled = Enable;
                    }
                    else if (cnt is CheckBox)
                    {
                        chkBox = (CheckBox)cnt;
                        chkBox.Enabled = Enable;
                        if (Clear == true)
                        {
                            chkBox.Checked = false;
                        }
                    }
                    else if (cnt is RadioButton)
                    {
                        rdobtn = (RadioButton)cnt;
                        rdobtn.Enabled = Enable;
                    }
                    else if (cnt.HasChildren == true)
                    {
                        setControlState(Enable, Clear, cnt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In VasyERP.MDIMain.setControlState() " + ex.ToString());
            }
        }

        private void btnToolAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if ((base.ActiveMdiChild != null) && this.btnToolAdd.Enabled)
                {
                    (base.ActiveMdiChild as ICommonFunctions).funAdd();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.btnToolAdd_Click() " + exception.ToString());
            }
        }

        private void btnToolClear_Click(object sender, EventArgs e)
        {
            try
            {
                if ((base.ActiveMdiChild != null) && this.btnToolClear.Enabled)
                {
                    Global.ControlChange = true;
                    base.ActiveMdiChild.AutoValidate = AutoValidate.Disable;
                    (base.ActiveMdiChild as ICommonFunctions).funClear();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.btnToolClear_Click() " + exception.ToString());
            }
        }

        private void btnToolDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (((base.ActiveMdiChild != null) && this.btnToolDelete.Enabled) && (MessageBox.Show("Do you want to Delete the Record?", "Delete Record Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    (base.ActiveMdiChild as ICommonFunctions).funDelete();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.btnToolDelete_Click() " + exception.ToString());
            }
        }

        private void btnToolEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if ((base.ActiveMdiChild != null) && this.btnToolEdit.Enabled)
                {
                    base.ActiveMdiChild.AutoValidate = AutoValidate.EnablePreventFocusChange;
                    (base.ActiveMdiChild as ICommonFunctions).funEdit();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.btnToolEdit_Click() " + exception.ToString());
            }
        }

        private void btnToolExit_Click(object sender, EventArgs e)
        {
            try
            {
                if ((base.ActiveMdiChild == null) && this.btnToolExit.Enabled)
                {
                    if (MessageBox.Show("Do you want to Close the Application?", "Close Application Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.setToolbarPositions(ToolbarPositions.eTPNoAction);
                        bolExit = true;
                        Application.Exit();
                    }
                }
                else if (MessageBox.Show("Do you want to Close the Form?", "Close Form Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    base.ActiveMdiChild.AutoValidate = AutoValidate.Disable;
                    (base.ActiveMdiChild as ICommonFunctions).funExit();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.btnToolExit_Click() " + exception.ToString());
            }
        }

        private void btnToolReport_Click(object sender, EventArgs e)
        {
            try
            {
                if ((base.ActiveMdiChild != null) && this.btnToolReport.Enabled)
                {
                    (base.ActiveMdiChild as ICommonFunctions).funReport();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.btnToolReport_Click() " + exception.ToString());
            }
        }

        private void btnToolSave_Click(object sender, EventArgs e)
        {
            try
            {
                if ((base.ActiveMdiChild != null) && this.btnToolSave.Enabled)
                {
                    (base.ActiveMdiChild as ICommonFunctions).funSave();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.btnToolSave_Click() " + exception.ToString());
            }
        }

        private void btnToolSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if ((base.ActiveMdiChild != null) && this.btnToolSearch.Enabled)
                {
                    Global.ControlChange = true;
                    (base.ActiveMdiChild as ICommonFunctions).funSearch();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(Convert.ToString(exception.Message));
                this.objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.btnToolSearch_Click() " + exception.ToString());
            }
        }

        private void mnuCaste_Click(object sender, EventArgs e)
        {
            try
            {
                if (pnlMain.Visible)
                {
                    pnlMain.Visible = false;
                }
                Global.strMasterName = Global.fCaste;
                frmCommonMaster objfrm = new frmCommonMaster();
                pnlMain.Visible = false;
                ShowForm(objfrm, mnuCaste);
                //frmCaste objfrm = new frmCaste();
                //ShowForm(objfrm, mnuCaste);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.mnuCaste_Click() " + ex.ToString());
            }
        }

        private void mnuMemberMaster_Click(object sender, EventArgs e)
        {
            try
            {
                //frmMemberMaster objfrm = new frmMemberMaster();
                //ShowForm(objfrm, mnuMemberMaster);
                frmMemberMasterList objfrm = new frmMemberMasterList();
                pnlMain.Visible = false;
                ShowReportForm(objfrm, mnuMemberMaster);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.mnuCaste_Click() " + ex.ToString());
            }
        }

        private void mnuSubCaste_Click(object sender, EventArgs e)
        {
            try
            {
                frmSubCaste objfrm = new frmSubCaste();
                ShowForm(objfrm, mnuSubCaste);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.mnuSubCaste_Click() " + ex.ToString());
            }
        }

        private void mnuCountry_Click(object sender, EventArgs e)
        {
            try
            {
                //frmCountry objfrm = new frmCountry();
                //ShowForm(objfrm, mnuCountry);
                Global.strMasterName = Global.fCountry;
                frmCommonMaster objfrm = new frmCommonMaster();
                ShowForm(objfrm, mnuCountry);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.mnuCountry_Click() " + ex.ToString());
            }
        }

        private void mnuVisaCountry_Click(object sender, EventArgs e)
        {
            try
            {
                //frmCountry objfrm = new frmCountry();
                //ShowForm(objfrm, mnuVisaCountry);
                //Global.strMasterName = Global.fCaste;
                //frmCommonMaster objfrm = new frmCommonMaster();
                //ShowForm(objfrm, mnuVisaCountry);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.mnuVisaCountry_Click() " + ex.ToString());
            }
        }

        private void mnuStateCity_Click(object sender, EventArgs e)
        {
            try
            {
                frmStateCity objfrm = new frmStateCity();
                ShowForm(objfrm, mnuStateCity);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.mnuStateCity_Click() " + ex.ToString());
            }
        }

        private void mnuProfileCreatedBy_Click(object sender, EventArgs e)
        {
            try
            {
                //frmProfileCreatedBy objfrm = new frmProfileCreatedBy();
                //ShowForm(objfrm, mnuProfileCreatedBy);
                Global.strMasterName = Global.fProfileCreatedBy;
                frmCommonMaster objfrm = new frmCommonMaster();
                ShowForm(objfrm, mnuProfileCreatedBy);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.mnuProfileCreatedBy_Click() " + ex.ToString());
            }
        }

        private void mnuAnnualIncomeCurrency_Click(object sender, EventArgs e)
        {
            try
            {
                //frmAnnualIncomeCurrency objfrm = new frmAnnualIncomeCurrency();
                //ShowForm(objfrm, mnuAnnualIncomeCurrency);
                Global.strMasterName = Global.fAnnualIncomeCurrency;
                frmCommonMaster objfrm = new frmCommonMaster();
                ShowForm(objfrm, mnuAnnualIncomeCurrency);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.mnuAnnualIncomeCurrency_Click() " + ex.ToString());
            }
        }

        private void mnuAnnualIncome_Click(object sender, EventArgs e)
        {
            try
            {
                //frmAnnualIncome objfrm = new frmAnnualIncome();
                //ShowForm(objfrm, mnuAnnualIncome);
                Global.strMasterName = Global.fAnnualIncome;
                frmCommonMaster objfrm = new frmCommonMaster();
                ShowForm(objfrm, mnuAnnualIncome);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.mnuAnnualIncome_Click() " + ex.ToString());
            }
        }

        private void mnuEducation_Click(object sender, EventArgs e)
        {
            try
            {
                //frmEducation objfrm = new frmEducation();
                //ShowForm(objfrm, mnuEducation);
                Global.strMasterName = Global.fEducation;
                frmCommonMaster objfrm = new frmCommonMaster();
                ShowForm(objfrm, mnuEducation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.mnuEducation_Click() " + ex.ToString());
            }
        }

        private void mnuOccupation_Click(object sender, EventArgs e)
        {
            try
            {
                //frmOccupation objfrm = new frmOccupation();
                //ShowForm(objfrm, mnuOccupation);
                Global.strMasterName = Global.fOccupation;
                frmCommonMaster objfrm = new frmCommonMaster();
                ShowForm(objfrm, mnuOccupation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.mnuOccupation_Click() " + ex.ToString());
            }
        }

        private void mnuVisaStatus_Click(object sender, EventArgs e)
        {
            try
            {
                //frmVisaStatus objfrm = new frmVisaStatus();
                //ShowForm(objfrm, mnuVisaStatus);
                Global.strMasterName = Global.fVisaStatus;
                frmCommonMaster objfrm = new frmCommonMaster();
                ShowForm(objfrm, mnuVisaStatus);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.mnuVisaStatus_Click() " + ex.ToString());
            }
        }

        private void mnuWorkingAs_Click(object sender, EventArgs e)
        {
            try
            {
                //frmWorkingAs objfrm = new frmWorkingAs();
                //ShowForm(objfrm, mnuWorkingAs);
                Global.strMasterName = Global.fWorkingAs;
                frmCommonMaster objfrm = new frmCommonMaster();
                ShowForm(objfrm, mnuWorkingAs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.mnuWorkingAs_Click() " + ex.ToString());
            }
        }

        private void mnuWorkingWith_Click(object sender, EventArgs e)
        {
            try
            {
                //frmWorkingWith objfrm = new frmWorkingWith();
                //ShowForm(objfrm, mnuWorkingWith);
                Global.strMasterName = Global.fWorkingWith;
                frmCommonMaster objfrm = new frmCommonMaster();
                ShowForm(objfrm, mnuWorkingWith);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.mnuWorkingWith_Click() " + ex.ToString());
            }
        }

        private void mnuBloodGroup_Click(object sender, EventArgs e)
        {
            try
            {
                //frmBloodGroup objfrm = new frmBloodGroup();
                //ShowForm(objfrm, mnuBloodGroup);
                Global.strMasterName = Global.fBloodGroup;
                frmCommonMaster objfrm = new frmCommonMaster();
                ShowForm(objfrm, mnuBloodGroup);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.mnuBloodGroup_Click() " + ex.ToString());
            }
        }

        private void mnuMembershipType_Click(object sender, EventArgs e)
        {
            try
            {
                //frmMembershipType objfrm = new frmMembershipType();
                //ShowForm(objfrm, mnuMembershipType);
                Global.strMasterName = Global.fMembershipType;
                frmCommonMaster objfrm = new frmCommonMaster();
                ShowForm(objfrm, mnuMembershipType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.mnuMembershipType_Click() " + ex.ToString());
            }
        }

        private void mnuFacilityDetail_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.mnuFacilityDetail_Click() " + ex.ToString());
            }
        }

        private void mnuQueryMessage_Click(object sender, EventArgs e)
        {
            try
            {
                frmMessageList objfrm = new frmMessageList();
                ShowForm(objfrm, mnuQueryMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.mnuQueryMessage_Click() " + ex.ToString());
            }
        }

        private void mnuEmailSetting_Click(object sender, EventArgs e)
        {
            try
            {
                frmEmailSetting objfrm = new frmEmailSetting();
                ShowReportForm(objfrm, mnuEmailSetting);
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex.Message));
                objEventLoging.AppErrlog("Error In AnantMatrimony.MDIMain.mnuEmailSetting_Click() " + ex.ToString());
            }
        }

        private void cccToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RegisteredAccount();
            NewRegisteredAccount();
            UpdatedProfile();
            DoneProfile();
            BlockProfile();
            UnreadMessage();
        }

        private void RegisteredAccount()
        {
            try
            {
                tbl_MemberMasterProp objtbl_MemberMasterProp = new tbl_MemberMasterProp();
                objtbl_MemberMasterProp.isActive = 1;

                tbl_MemberMasterBAL objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                DataSet dsData = objtbl_MemberMasterBAL.Profile_Summary(objtbl_MemberMasterProp);
                lnkRegisterAccount.Text = "Total Records ( " + Convert.ToString(dsData.Tables[0].Rows[0]["MemCount"]).PadLeft(3, '0') + " )";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NewRegisteredAccount()
        {
            try
            {
                tbl_MemberMasterProp objtbl_MemberMasterProp = new tbl_MemberMasterProp();
                objtbl_MemberMasterProp.isActive = 0;

                tbl_MemberMasterBAL objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                DataSet dsData = objtbl_MemberMasterBAL.Profile_Summary(objtbl_MemberMasterProp);
                lnkNewRegistered.Text = "New/Unapproved Records ( " + Convert.ToString(dsData.Tables[0].Rows[0]["MemCount"]).PadLeft(3, '0') + " )";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdatedProfile()
        {
            try
            {
                tbl_MemberMasterProp objtbl_MemberMasterProp = new tbl_MemberMasterProp();
                objtbl_MemberMasterProp.isActive = 2;

                tbl_MemberMasterBAL objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                DataSet dsData = objtbl_MemberMasterBAL.Profile_Summary(objtbl_MemberMasterProp);
                lnkUpdatedProfile.Text = "Updated Records ( " + Convert.ToString(dsData.Tables[0].Rows[0]["MemCount"]).PadLeft(3, '0') + " )";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DoneProfile()
        {
            try
            {
                tbl_MemberMasterProp objtbl_MemberMasterProp = new tbl_MemberMasterProp();
                objtbl_MemberMasterProp.isActive = 3;

                tbl_MemberMasterBAL objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                DataSet dsData = objtbl_MemberMasterBAL.Profile_Summary(objtbl_MemberMasterProp);
                lnkDoneProfile.Text = "Done Profile Records ( " + Convert.ToString(dsData.Tables[0].Rows[0]["MemCount"]).PadLeft(3, '0') + " )";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BlockProfile()
        {
            try
            {
                tbl_MemberMasterProp objtbl_MemberMasterProp = new tbl_MemberMasterProp();
                objtbl_MemberMasterProp.isActive = 4;

                tbl_MemberMasterBAL objtbl_MemberMasterBAL = new tbl_MemberMasterBAL();
                DataSet dsData = objtbl_MemberMasterBAL.Profile_Summary(objtbl_MemberMasterProp);
                lnkBlockedProfile.Text = "Blocked Profile Records ( " + Convert.ToString(dsData.Tables[0].Rows[0]["MemCount"]).PadLeft(3, '0') + " )";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UnreadMessage()
        {
            tbl_QueryProp objtbl_QueryProp = new tbl_QueryProp();

            tbl_QueryBAL objtbl_QueryBAL = new tbl_QueryBAL();
            DataSet dsData = objtbl_QueryBAL.CountUnreadMessage(objtbl_QueryProp);
            lnkQueryMessage.Text = "Unread Message ( " + Convert.ToString(dsData.Tables[0].Rows[0]["messCode"]) + " )";

        }



        private void lnkRegisterAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmMemberMasterList objfrm = new frmMemberMasterList();
                objfrm.sSearchType = "";
                objfrm.sSearchVal = "";
                pnlMain.Visible = false;
                ShowReportForm(objfrm, mnuMemberMaster);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lnkUpdatedProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmMemberMasterList objfrm = new frmMemberMasterList();
                objfrm.sSearchType = "isActive";
                objfrm.sSearchVal = "2";
                pnlMain.Visible = false;
                ShowReportForm(objfrm, mnuMemberMaster);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lnkDoneProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmMemberMasterList objfrm = new frmMemberMasterList();
                objfrm.sSearchType = "isActive";
                objfrm.sSearchVal = "3";
                pnlMain.Visible = false;
                ShowReportForm(objfrm, mnuMemberMaster);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lnkBlockedProfile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                frmMemberMasterList objfrm = new frmMemberMasterList();
                objfrm.sSearchType = "isActive";
                objfrm.sSearchVal = "4";
                pnlMain.Visible = false;
                ShowReportForm(objfrm, mnuMemberMaster);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuMainReport_Click(object sender, EventArgs e)
        {
            rfrmHeadingWiseReport objrpt = new rfrmHeadingWiseReport();
            pnlMain.Visible = false;
            ShowReportForm(objrpt, mnuMainReport);
        }

        private void lnkNewRegistered_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmMemberMasterList objfrm = new frmMemberMasterList();
            objfrm.sSearchType = "isActive";
            objfrm.sSearchVal = "0";
            pnlMain.Visible = false;
            ShowReportForm(objfrm, mnuMemberMaster);
        }

        private void btnProfileSearch_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void mnuQuickPrint_Click(object sender, EventArgs e)
        {
            try
            {
                rfrmQuickReport objfrm = new rfrmQuickReport();
                ShowReportForm(objfrm, mnuQueryMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuAdvanceMainReport_Click(object sender, EventArgs e)
        {
            try
            {
                rfrmAdvMainReport objfrm = new rfrmAdvMainReport();
                ShowReportForm(objfrm, mnuAdvanceMainReport);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuPaidMembership_Click(object sender, EventArgs e)
        {
            try
            {
                rfrmPaidMembership objfrm = new rfrmPaidMembership();
                ShowReportForm(objfrm, mnuPaidMembership);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuExpiredMembership_Click(object sender, EventArgs e)
        {
            try
            {
                rfrmExpiredMembership objfrm = new rfrmExpiredMembership();
                ShowReportForm(objfrm, mnuExpiredMembership);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuSendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                frmSendSMS objfrm = new frmSendSMS();
                ShowReportForm(objfrm, mnuSendMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuMobileNoUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                frmMobileNoUpdate objfrm = new frmMobileNoUpdate();
                ShowReportForm(objfrm, mnuMobileNoUpdate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuRegistrationReport_Click(object sender, EventArgs e)
        {
            try
            {
                rfrmRegistrationReports objfrm = new rfrmRegistrationReports();
                ShowReportForm(objfrm, mnuRegistrationReport);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuPhotoUploadSMSEmail_Click(object sender, EventArgs e)
        {
            try
            {
                frmPhotosUploadInfo objfrm = new frmPhotosUploadInfo();
                ShowReportForm(objfrm, mnuPhotoUploadSMSEmail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuFirstPageEmail_Click(object sender, EventArgs e)
        {
            try
            {
                frmFirstPageEmail objfrm = new frmFirstPageEmail();
                ShowReportForm(objfrm, mnuFirstPageEmail);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuMarriedConfirmation_Click(object sender, EventArgs e)
        {
            try
            {
                frmMarriedConfirmation objfrm = new frmMarriedConfirmation();
                ShowReportForm(objfrm, mnuMarriedConfirmation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuPhotoDelete_Click(object sender, EventArgs e)
        {
            try
            {
                frmDeletePhotos objfrm = new frmDeletePhotos();
                ShowReportForm(objfrm, mnuPhotoDelete);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuMasterList_Click(object sender, EventArgs e)
        {
            try
            {
                frmMasterListWithIds objfrm = new frmMasterListWithIds();
                ShowReportForm(objfrm, mnuMasterList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuLoginLog_Click(object sender, EventArgs e)
        {
            try
            {
                LogInLog objfrm = new LogInLog();
                ShowReportForm(objfrm, mnuLoginLog);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuMaritalStatus_Click(object sender, EventArgs e)
        {
            Global.strMasterName = Global.fMaritalStatus;
            frmCommonMaster objfrm = new frmCommonMaster();
            //ShowForm(objfrm, mnuMaritalStatus);
        }

        private void mnuExpireMembershipSMS_Click(object sender, EventArgs e)
        {
            frmExpireNoti objfrm = new frmExpireNoti();
            ShowReportForm(objfrm, mnuExpireMembershipSMS);
        }

        private void mnuProfileVisitLog_Click(object sender, EventArgs e)
        {
            frmProfileVisitLog objfrm = new frmProfileVisitLog();
            ShowReportForm(objfrm, mnuProfileVisitLog);
        }

        private void mnuEmployeeMaster_Click(object sender, EventArgs e)
        {
            Global.strMasterName = Global.fEmployeeMaster;
            frmCommonMaster objfrm = new frmCommonMaster();
            ShowForm(objfrm, mnuEmployeeMaster);
        }

        private void mnuWorkType_Click(object sender, EventArgs e)
        {
            Global.strMasterName = Global.fWorkType;
            frmCommonMaster objfrm = new frmCommonMaster();
            ShowForm(objfrm, mnuWorkType);
        }

        private void mnuWorkReport_Click(object sender, EventArgs e)
        {
            frmWorkReport objfrm = new frmWorkReport();
            ShowForm(objfrm, mnuWorkReport);
        }

        private void mnuWorkReportView_Click(object sender, EventArgs e)
        {
            frmWorkReportView objfrm = new frmWorkReportView();
            ShowReportForm(objfrm, mnuWorkReportView);
        }

        private void mnuMemberSetting_Click(object sender, EventArgs e)
        {
            frmSetting objfrm = new frmSetting();
            ShowReportForm(objfrm, mnuMemberSetting);
        }

        private void mnuSendProfileSMS_Click(object sender, EventArgs e)
        {
            frmSendProfileSMS objfrm = new frmSendProfileSMS();
            ShowReportForm(objfrm, mnuSendProfileSMS);
        }

        private void lnkQueryMessage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmMessageList objfrm = new frmMessageList();
            ShowForm(objfrm, mnuQueryMessage);
        }

        private void mnuSMSTemplateMaster_Click(object sender, EventArgs e)
        {
            frmSMSTemplateMaster objfrm = new frmSMSTemplateMaster();
            ShowForm(objfrm, mnuSMSTemplateMaster);
        }

        private void mnuFirstPageSMS_Click(object sender, EventArgs e)
        {
            frmFirstPageSMS objfrm = new frmFirstPageSMS();
            ShowReportForm(objfrm, mnuFirstPageSMS);
        }

        private void lnkFirstPageSMS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmFirstPageSMS objfrm = new frmFirstPageSMS();
            ShowReportForm(objfrm, mnuFirstPageSMS);
        }

        private void mnuBookmarkLogs_Click(object sender, EventArgs e)
        {
            frmBookmarkLog objfrm = new frmBookmarkLog();
            ShowForm(objfrm, mnuBookmarkLogs);
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //TimeSpan start = new TimeSpan(16, 0, 0); //4:00pm o'clock
            //TimeSpan end = new TimeSpan(20, 0, 0); //8:00pm
            //TimeSpan now = DateTime.Now.TimeOfDay;
            //if ((now > start) && (now < end))
            //{
                MessageBox.Show("Make sure you take backup today", "Backup information ", MessageBoxButtons.OK, MessageBoxIcon.Hand);    
            //}
        }

        private void mnuMemberSearchLog_Click(object sender, EventArgs e)
        {
            rfrmMemberSearchLog objfrm = new rfrmMemberSearchLog();
            ShowReportForm(objfrm, mnuMemberSearchLog);
        }

        private void lnkPrintBlank_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmReportViewer objReportViewer = new frmReportViewer();
            ReportDocument cryRpt = new ReportDocument();
            string strPath = Application.StartupPath + @"\REPORTS\MemberMaster_Blank.rpt";
            cryRpt.Load(strPath);
            //DataSet dstest = new DataSet();

            //dstest.Tables.Add(dsMemberMaster.Tables[0].Copy());
            //dstest.Tables.Add(dsMemberPhotos.Tables[0].Copy());
            //cryRpt.Subreports["Sibbling"].SetDataSource(dsSibbling.Tables[0]);
            //cryRpt.Subreports["MemberPhotos"].SetDataSource(dsMemberPhotos.Tables[0]);

            //cryRpt.SetDataSource(dstest);

            objReportViewer.RptViewer.ReportSource = cryRpt;
            objReportViewer.RptViewer.Refresh();
            objReportViewer.ShowDialog();
            objReportViewer.Focus();
        }

        private void mnuManagePackage_Click(object sender, EventArgs e)
        {
            frmPackages objfrm = new frmPackages();
            ShowForm(objfrm, mnuManagePackage);
        }



    }
}
